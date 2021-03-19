#include <Unity/Runtime.h>
#include <Baselib.h>
#include <C/Baselib_Memory.h>
#include <C/Baselib_Thread.h>
#include <baselibext.h>
#include <allocators.h>

#include <GLFW/glfw3.h>
#if defined(WIN32)
#define GLFW_EXPOSE_NATIVE_WIN32
#define WINDOW_ON_THREAD 1  // needed in windows for main message spam in some cases
#elif defined(__APPLE__)
#define GLFW_EXPOSE_NATIVE_COCOA
//#define WINDOW_ON_THREAD 1  // macos must have the window created on main thread
#elif defined(__EMSCRIPTEN__)
#error Should not be here for Emscripten
#else
#define GLFW_EXPOSE_NATIVE_X11
//#define WINDOW_ON_THREAD 1  // X11 doesn't message spam, keep off main thread for safety
#endif
#include <GLFW/glfw3native.h>
#include <stdio.h>
#include <math.h>
#include <vector>
#include <stdlib.h>

using namespace Unity::LowLevel;

template <class T>
class ScopedBuffer
{
public:
    ScopedBuffer() = default;
    ~ScopedBuffer()
    {
        if (m_Buffer)
        {
            unsafeutility_free(m_Buffer, Allocator::Persistent);
            m_Buffer = nullptr;
            m_Size = 0;
            m_Capacity = 0;
        }
    }

    void push_back(T data)
    {
        if (m_Size == m_Capacity)
        {
            m_Capacity = m_Capacity ? m_Capacity * 2 : 16;
            m_Buffer = unsafeutility_realloc(m_Buffer, m_Capacity * sizeof(T), 0, Allocator::Persistent);
        }

        reinterpret_cast<T*>(m_Buffer)[m_Size] = data;
        m_Size++;
    }

    void clear() { m_Size = 0; }

    size_t size() { return m_Size; }

    T* data() { return reinterpret_cast<T*>(m_Buffer); }

private:
    void* m_Buffer{ nullptr };
    size_t m_Size{ 0 };
    size_t m_Capacity{ 0 };
};



// Main thread only
static bool initialized = false;

// TODO: could keep array of windows, window class etc.
// for now one static window is perfectly fine

// Shared data
// We need to protect this data from being modified by the message pump thread
// while it is being consumed by the main thread during polling. When resetting values
// such as in the input streams, we want to of course avoid contention between both threads.
#ifdef WINDOW_ON_THREAD
static Baselib_Thread* messageThread = nullptr;
static baselib::Lock dataMutex;
static bool requestDestroyWindow = false;
#endif
static GLFWwindow* mainWindow = nullptr;
static bool shouldClose = false;
static bool lostFocus = false;
static bool gotFocus = false;
static ScopedBuffer<int> mouse_pos_stream;
static ScopedBuffer<int> mouse_button_stream;
static ScopedBuffer<float> mouse_scroll_stream;
static ScopedBuffer<int> key_stream;
static int windowW = 0;
static int windowH = 0;
static int mouseCursorMode = GLFW_CURSOR_NORMAL;

//-----------------------------------------------------------------------------------------------------------
// Message/Event thread

// callbacks
static void
window_size_callback(GLFWwindow* window, int width, int height)
{
#ifdef WINDOW_ON_THREAD
    BaselibLock lock(dataMutex);
#endif
    //printf ( "GLFW resize %i, %i\n", width, height);
    windowW = width;
    windowH = height;
}

static void
window_close_callback(GLFWwindow* window)
{
#ifdef WINDOW_ON_THREAD
    BaselibLock lock(dataMutex);
#endif

    shouldClose = true;
}

static void
window_focus_callback(GLFWwindow* window, int focused)
{
#ifdef WINDOW_ON_THREAD
    BaselibLock lock(dataMutex);
#endif

    lostFocus = !focused;
    gotFocus = focused;
}

static void
cursor_position_callback(GLFWwindow* window, double xpos, double ypos)
{
#ifdef WINDOW_ON_THREAD
    BaselibLock lock(dataMutex);
#endif

    //printf ( "GLFW C mouse pos %f, %f\n", (float)xpos, (float)ypos);
    mouse_pos_stream.push_back((int)xpos);
    mouse_pos_stream.push_back(windowH - 1 - (int)ypos);
}


static void
mouse_button_callback(GLFWwindow* window, int button, int action, int mods)
{
#ifdef WINDOW_ON_THREAD
    BaselibLock lock(dataMutex);
#endif

    //printf ( "GLFW C mouse button %i, %i, %i\n", button, action, mods);
    mouse_button_stream.push_back(button);
    mouse_button_stream.push_back(action);
    mouse_button_stream.push_back(mods);
}

static void
window_scroll_callback(GLFWwindow* window, double xoffset, double yoffset)
{
#ifdef WINDOW_ON_THREAD
    BaselibLock lock(dataMutex);
#endif

    mouse_scroll_stream.push_back((float)xoffset);
    mouse_scroll_stream.push_back((float)yoffset);
}

static void
key_callback(GLFWwindow* window, int key, int scancode, int action, int mods)
{
#ifdef WINDOW_ON_THREAD
    BaselibLock lock(dataMutex);
#endif

    //printf ( "GLFW C key %i, %i, %i, %i\n", key, scancode, action, mods);
    key_stream.push_back(key);
    key_stream.push_back(scancode);
    key_stream.push_back(action);
    key_stream.push_back(mods);
}

static int
create_window_glfw_internal()
{
#ifdef WINDOW_ON_THREAD
    BaselibLock lock(dataMutex);
#endif

    // Create window on another thread so event polling can occur on the other thread
    // for all supported desktop platforms - that way we don't block on resize and move
    if (!mainWindow)
    {
        glfwWindowHint(GLFW_CLIENT_API, GLFW_NO_API);
        mainWindow = glfwCreateWindow(windowW, windowH, "Unity - DOTS Project", NULL, NULL);
        if (!mainWindow) {
            printf("GLFW window creation failed.\n");
            return 0;
        }

        glfwSetWindowCloseCallback(mainWindow, window_close_callback);
        glfwSetWindowSizeCallback(mainWindow, window_size_callback);

        glfwSetInputMode(mainWindow, GLFW_CURSOR, mouseCursorMode);

#ifdef WINDOW_ON_THREAD
        requestDestroyWindow = false;
#endif

        if (!mainWindow)
            return 0;
    }
    else {
        // this is fine, window already exists
        glfwSetWindowSize(mainWindow, windowW, windowH);

        return 2;
    }

    return 1;
}

#ifdef WINDOW_ON_THREAD
static void
windowEventThreadFunc(void* user)
{
    while (!messageThread)
        Baselib_Thread_YieldExecution();

    switch (create_window_glfw_internal())
    {
    case 0:  // failed
        messageThread = nullptr;
        return;
    case 1:  // success
        break;
    case 2:  // already exists
        return;
    }

    // The goal is to not block on polling, so we only block when handling
    // specified events which we have assigned callbacks for.
    while (!requestDestroyWindow)
    {
        glfwPollEvents();
        Baselib_Thread_YieldExecution();
    }

    glfwDestroyWindow(mainWindow);
    mainWindow = nullptr;
    messageThread = nullptr;
}
#endif


//-----------------------------------------------------------------------------------------------------------
// Main thread calls/Bindings API

static void
error_callback(int error, const char* description)
{
    printf("GLFW error %d : %s\n", error, description);
}

// exports to c#
DOTS_EXPORT(int)
init_glfw()
{
    if (initialized)
        return 1;

    glfwSetErrorCallback(error_callback);

    if (!glfwInit()) {
        printf("GLFW init failed.\n");
        return 0;
    }

    initialized = true;
    return 1;
}

DOTS_EXPORT(void)
shutdown_glfw(int exitCode)
{
    initialized = false;
    glfwTerminate();
}

DOTS_EXPORT(int)
create_window_glfw(int width, int height)
{
    if (!initialized)
    {
        printf("Not initialized!");
        return 0;
    }

#ifdef WINDOW_ON_THREAD
    {
        BaselibLock lock(dataMutex);

        windowW = width;
        windowH = height;

        Baselib_Thread_Config threadInfo{ 0 };
        threadInfo.name = "Window Event Thread";
        threadInfo.entryPoint = &windowEventThreadFunc;
        threadInfo.entryPointArgument = nullptr;

        Baselib_ErrorState err{ 0 };
        messageThread = Baselib_Thread_Create(threadInfo, &err);
        if (!messageThread || err.code != Baselib_ErrorCode_Success)
            return 0;
    }

    // Wait for the window to be created
    while (!mainWindow && messageThread)
        Baselib_Thread_YieldExecution();

    if (!mainWindow)
        return 0;
#else
    windowW = width;
    windowH = height;

    if (create_window_glfw_internal() == 0)
        return 0;
#endif

    return 1;
}

DOTS_EXPORT(void)
show_window_glfw(int show)
{
#ifdef WINDOW_ON_THREAD
    BaselibLock lock(dataMutex);
#endif

    if (!mainWindow)
        return;

    if (show)
        glfwShowWindow(mainWindow);
    else
        glfwHideWindow(mainWindow);
}

DOTS_EXPORT(GLFWwindow*)
getwindow_glfw()
{
    return mainWindow;
}

DOTS_EXPORT(void)
getWindowSize_glfw(int* width, int* height)
{
#ifdef WINDOW_ON_THREAD
    BaselibLock lock(dataMutex);
#endif

    if (!mainWindow)
    {
        *width = 0;
        *height = 0;
        return;
    }
    glfwGetWindowSize(mainWindow, width, height);
    windowW = *width;
    windowH = *height;
}

DOTS_EXPORT(void)
getWindowFrameSize_glfw(int* left, int* top, int* right, int* bottom)
{
#ifdef WINDOW_ON_THREAD
    BaselibLock lock(dataMutex);
#endif

    if (!mainWindow)
    {
        *left = 0;
        *top = 0;
        *right = 0;
        *bottom = 0;
        return;
    }
    glfwGetWindowFrameSize(mainWindow, left, top, right, bottom);
}

DOTS_EXPORT(void)
getScreenSize_glfw(int* width, int* height)
{
#ifdef WINDOW_ON_THREAD
    BaselibLock lock(dataMutex);
#endif

    if (!mainWindow)
    {
        *width = 0;
        *height = 0;
        return;
    }
    GLFWmonitor* monitor = glfwGetWindowMonitor(mainWindow);
    if (!monitor)
        monitor = glfwGetPrimaryMonitor();
    const GLFWvidmode* mode = glfwGetVideoMode(monitor);
    *width = mode->width;
    *height = mode->height;
}

DOTS_EXPORT(void)
getFramebufferSize_glfw(int* width, int* height)
{
#ifdef WINDOW_ON_THREAD
    BaselibLock lock(dataMutex);
#endif

    if (!mainWindow)
    {
        *width = 0;
        *height = 0;
        return;
    }
    glfwGetWindowSize(mainWindow, width, height);
}

DOTS_EXPORT(void)
destroy_window_glfw()
{
#ifdef WINDOW_ON_THREAD
    if (mainWindow)
    {
        requestDestroyWindow = true;
        Baselib_ErrorState err{ 0 };
        Baselib_Thread_Join(messageThread, 0xffffffff, &err);
    }
#else
    glfwDestroyWindow(mainWindow);
    mainWindow = nullptr;
#endif

    shouldClose = false;
}

DOTS_EXPORT(void)
resize_glfw(int width, int height)
{
#ifdef WINDOW_ON_THREAD
    BaselibLock lock(dataMutex);
#endif

    windowW = width;
    windowH = height;
    glfwSetWindowSize(mainWindow, width, height);
}

DOTS_EXPORT(int)
get_lost_focus_glfw()
{
    return lostFocus ? 1 : 0;
}

DOTS_EXPORT(int)
get_got_focus_glfw()
{
    return gotFocus ? 1 : 0;
}

DOTS_EXPORT(int)
get_should_close_glfw()
{
#ifndef WINDOW_ON_THREAD
    if (!mainWindow || shouldClose)
        return 1;

    glfwPollEvents();
#endif
    return shouldClose ? 1 : 0;
}

// exports to c#
DOTS_EXPORT(int)
init_glfw_input()
{
#ifdef WINDOW_ON_THREAD
    BaselibLock lock(dataMutex);
#endif

    if (!mainWindow) {
        printf("GLFW main window not created.\n");
        return 0;
    }
    glfwSetKeyCallback(mainWindow, key_callback);
    glfwSetCursorPosCallback(mainWindow, cursor_position_callback);
    glfwSetMouseButtonCallback(mainWindow, mouse_button_callback);
    glfwSetWindowFocusCallback(mainWindow, window_focus_callback);
    glfwSetScrollCallback(mainWindow, window_scroll_callback);
    return 1;
}

DOTS_EXPORT(void)
lock_glfw_input()
{
#ifdef WINDOW_ON_THREAD
    dataMutex.Acquire();
#endif
}

DOTS_EXPORT(void)
unlock_and_reset_glfw_input()
{
    lostFocus = false;
    gotFocus = false;
    mouse_pos_stream.clear();
    mouse_button_stream.clear();
    mouse_scroll_stream.clear();
    key_stream.clear();
#ifdef WINDOW_ON_THREAD
    dataMutex.Release();
#endif
}

DOTS_EXPORT(void)
set_mouse_mode(int mode)
{
#ifdef WINDOW_ON_THREAD
    BaselibLock lock(dataMutex);
#endif

    mouseCursorMode = mode;

    if (mainWindow)
        glfwSetInputMode(mainWindow, GLFW_CURSOR, mode);
}

DOTS_EXPORT(const int*)
get_mouse_pos_stream_glfw_input(int* len)
{
    *len = (int)mouse_pos_stream.size();
    return mouse_pos_stream.data();
}

DOTS_EXPORT(const int*)
get_mouse_button_stream_glfw_input(int* len)
{
    *len = (int)mouse_button_stream.size();
    return mouse_button_stream.data();
}

DOTS_EXPORT(const float*)
get_mouse_scroll_stream_glfw_input(int* len) {
    *len = (int)mouse_scroll_stream.size();
    return mouse_scroll_stream.data();
}

DOTS_EXPORT(const int*)
get_key_stream_glfw_input(int* len)
{
    *len = (int)key_stream.size();
    return key_stream.data();
}

DOTS_EXPORT(void*)
glfw_get_platform_window_handle()
{
#if defined(WIN32)
    return (void*) glfwGetWin32Window(mainWindow);
#elif defined(__APPLE__)
    return (void*) glfwGetCocoaWindow(mainWindow);
#else
    return (void*) glfwGetX11Window(mainWindow);
#endif
}


