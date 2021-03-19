#include <Unity/Runtime.h>

#include <dlfcn.h>
#include <unistd.h>
#include <stdio.h>
#include <math.h>
#include <time.h>
#include <vector>
#include <mutex>
#include <IOSWrapper.h>
#include "IOSSensors.h"

static bool shouldClose = false;
static int windowW = 0;
static int windowH = 0;
static int screenW = 0;
static int screenH = 0;
static int deviceOrientation;
static int screenOrientation;
static void* nativeWindow = NULL;
static UIViewController* tinyViewController;
// input
static std::vector<int> touch_info_stream;
static std::mutex touch_stream_lock;
// c# delegates
static bool (*raf)(double) = 0;
static void (*pausef)(int) = 0;
static void (*destroyf)() = 0;
static void (*device_orientationf)(int) = 0;

void setResolution(int width, int height);
bool setOrientationMask(int orientationMask);
void rotateToDeviceOrientation();
void rotateToAllowedOrientation();
void rotateToOrientation(int orientation);

DOTS_EXPORT(bool)
init_ios() {
    printf("IOSWrapper: iOS C Init\n");
    return true;
}

DOTS_EXPORT(void)
getWindowSize_ios(int *width, int *height) {
    *width = windowW;
    *height = windowH;
}

DOTS_EXPORT(void)
setWindowSize_ios(int width, int height) {
    if (windowW != width || windowH != height)
    {
        if (screenW != width || screenH != height)
        {
            setResolution(width, height);
        }
        windowW = width;
        windowH = height;
    }
}

DOTS_EXPORT(void)
getScreenSize_ios(int *width, int *height) {
    *width = screenW;
    *height = screenH;
}

DOTS_EXPORT(void)
getScreenOrientation_ios(int *orientation) {
    *orientation = screenOrientation;
}

DOTS_EXPORT(void)
shutdown_ios(int exitCode) {
    // TODO: call something to kill app
    raf = 0;
}

DOTS_EXPORT(bool)
messagePump_ios() {
    return !shouldClose;
}

DOTS_EXPORT(double)
time_ios() {
    static double start_time = -1;
    struct timespec res;
    clock_gettime(CLOCK_REALTIME, &res);
    double t = res.tv_sec + (double) res.tv_nsec / 1e9;
    if (start_time < 0) {
        start_time = t;
    }
    return t - start_time;
}

DOTS_EXPORT(bool)
rafcallbackinit_ios(bool (*func)(double)) {
    if (raf)
        return false;
    raf = func;
    return true;
}

DOTS_EXPORT(bool)
pausecallbackinit_ios(void (*func)(int)) {
    if (pausef)
        return false;
    pausef = func;
    return true;
}

DOTS_EXPORT(bool)
destroycallbackinit_ios(void (*func)()) {
    if (destroyf)
        return false;
    destroyf = func;
    return true;
}

DOTS_EXPORT(bool)
device_orientationcallbackinit_ios(void (*func)(int)) {
    if (device_orientationf)
        return false;
    device_orientationf = func;
    if (device_orientationf)
        device_orientationf(deviceOrientation);
    return true;
}

DOTS_EXPORT(void)
input_streams_lock_ios(bool lock)
{
    if (lock)
    {
        touch_stream_lock.lock();
    }
    else
    {
        touch_stream_lock.unlock();
    }
}

DOTS_EXPORT(const int*)
get_touch_info_stream_ios(int *len) {
    if (len == NULL)
        return NULL;
    *len = (int)touch_info_stream.size();
    return touch_info_stream.data();
}

DOTS_EXPORT(void)
reset_input_ios()
{
    touch_info_stream.clear();
    m_iOSSensors.ResetSensorsData();
}

DOTS_EXPORT(void*)
get_native_window_ios() {
    return nativeWindow ;
}

DOTS_EXPORT(bool)
available_sensor_ios(int type)
{
    return m_iOSSensors.AvailableSensor((iOSSensorType)type);
}

DOTS_EXPORT(bool)
enable_sensor_ios(int type, bool enable)
{
    return m_iOSSensors.EnableSensor((iOSSensorType)type, enable);
}

DOTS_EXPORT(const double*)
get_sensor_stream_ios(int type, int *len)
{
    if (len == NULL)
        return NULL;
    return m_iOSSensors.GetSensorData((iOSSensorType)type, len);
}

DOTS_EXPORT(void)
set_sensor_frequency_ios(int type, int rate)
{
    m_iOSSensors.SetSamplingFrequency((iOSSensorType)type, rate);
}

DOTS_EXPORT(int)
get_sensor_frequency_ios(int type)
{
    return m_iOSSensors.GetSamplingFrequency((iOSSensorType)type);
}

DOTS_EXPORT(bool)
setOrientationMask_ios(int orientationMask)
{
    return setOrientationMask(orientationMask);
}

DOTS_EXPORT(void)
rotateToDeviceOrientation_ios()
{
    rotateToDeviceOrientation();
}

DOTS_EXPORT(void)
rotateToAllowedOrientation_ios()
{
    rotateToAllowedOrientation();
}

extern "C" void start();
DOTS_EXPORT(void)
startapp_ios()
{
    m_iOSSensors.InitializeSensors();
    start();
}

DOTS_EXPORT(void)
set_viewcontroller_ios(UIViewController *viewController)
{
    tinyViewController = viewController;
}

DOTS_EXPORT(UIViewController*)
get_viewcontroller()
{
    return tinyViewController;
}

DOTS_EXPORT(UIViewController*)
Unity_Get_ViewController()
{
    return tinyViewController;
}

DOTS_EXPORT(void)
init_window_ios(void *nwh, int width, int height, int orientation)
{
    printf("init %d x %d\n", width, height);
    screenW = width;
    screenH = height;
    if (windowW == 0)
    {
        windowW = width;
        windowH = height;
    }
    screenOrientation = orientation;
    nativeWindow = nwh;
}

DOTS_EXPORT(void)
step_ios(double timestamp)
{
    if (raf && !raf(timestamp))
        shutdown_ios(2);
}

DOTS_EXPORT(void)
pauseapp_ios(int paused)
{
    if (pausef)
        pausef(paused);
}

DOTS_EXPORT(void)
destroyapp_ios()
{
    m_iOSSensors.ShutdownSensors();
    if (destroyf)
        destroyf();
}

DOTS_EXPORT(void)
touchevent_ios(int id, int action, int xpos, int ypos)
{
    std::lock_guard<std::mutex> lock(touch_stream_lock);
    touch_info_stream.push_back((int)id);
    touch_info_stream.push_back((int)action);
    touch_info_stream.push_back((int)xpos * windowW / screenW);
    touch_info_stream.push_back(windowH - 1 - (int)ypos * windowH / screenH);
}

DOTS_EXPORT(void)
deviceOrientationChanged_ios(int orientation)
{
    deviceOrientation = orientation;
    if (device_orientationf)
        device_orientationf(orientation);
}

#if UNITY_DOTSRUNTIME_IL2CPP_WAIT_FOR_MANAGED_DEBUGGER

typedef void(*BroadcastFunction)();
void ShowDebuggerAttachDialogImpl(const char* message, BroadcastFunction broadcast);

bool waitForManagedDebugger = true;

DOTS_EXPORT(void)
ShowDebuggerAttachDialog(const char* message, BroadcastFunction broadcast)
{
    ShowDebuggerAttachDialogImpl(message, broadcast);
}
#else

bool waitForManagedDebugger = false;

#endif // UNITY_DOTSRUNTIME_IL2CPP_WAIT_FOR_MANAGED_DEBUGGER
