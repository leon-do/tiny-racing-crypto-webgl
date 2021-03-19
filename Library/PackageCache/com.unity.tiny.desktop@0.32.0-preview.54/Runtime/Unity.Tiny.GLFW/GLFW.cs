using System;
using System.Runtime.CompilerServices;
using Unity.Entities;
using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Platforms;

[assembly: InternalsVisibleTo("Unity.Tiny.Input.GLFW")]

namespace Unity.Tiny.GLFW
{
    [UpdateInGroup(typeof(InitializationSystemGroup))]
    public class GLFWWindowSystem : WindowSystem
    {
        protected bool initialized;
        protected bool windowOpen;

        public GLFWWindowSystem()
        {
            initialized = false;
            windowOpen = false;
        }

        public override IntPtr GetPlatformWindowHandle()
        {
            if (!windowOpen)
                return IntPtr.Zero;
            return GLFWNativeCalls.getPlatformWindowHandle();
        }

#if UNITY_MACOSX
        protected IntPtr macMetalLayer;

        public unsafe IntPtr GetMacMetalLayerHandle()
        {
            if (macMetalLayer == IntPtr.Zero)
            {
                var nwh = GetPlatformWindowHandle();
                if (!GLFWNativeCalls.create_metal_layer_for_window(nwh, out macMetalLayer))
                    macMetalLayer = IntPtr.Zero;
            }
            return macMetalLayer;
        }

#endif

        public override void DebugReadbackImage(out int w, out int h, out NativeArray<byte> pixels)
        {
            throw new InvalidOperationException("Can no longer read-back from window use BGFX instead.");
        }

        protected override void OnCreate()
        {
            base.OnCreate();

            try
            {
                initialized = GLFWNativeCalls.init() != 0 ? true : false;
            }
            catch (Exception)
            {
                Debug.LogWarning("GLFW support unable to initialize; likely missing lib_unity_tiny_glfw.dll");
            }
        }

        protected override void OnStartRunning()
        {
            base.OnStartRunning();

            if (!initialized)
                throw new InvalidOperationException("GLFW wasn't initialized");

            // setup window
            var displayInfo = GetSingleton<DisplayInfo>();

            if (displayInfo.width <= 0 || displayInfo.height <= 0)
            {
                Debug.LogError($"GLFW: configuration entity DisplayInfo has width or height <= 0! ({displayInfo.width} {displayInfo.height}).  Is it being created properly?");
                throw new InvalidOperationException("Bad DisplayInfo, window can't be opened");
            }

            // no-op if the window is already created
            if (GLFWNativeCalls.create_window(displayInfo.width, displayInfo.height) == 0)
                throw new InvalidOperationException("Failed to Open GLFW Window!");
            GLFWNativeCalls.show_window(1);

            GLFWNativeCalls.getWindowSize(out int winw, out int winh);
            GLFWNativeCalls.getScreenSize(out int sw, out int sh);
            displayInfo.focused = true;
            displayInfo.visible = true;
            displayInfo.orientation = winw >= winh ? ScreenOrientation.Landscape : ScreenOrientation.Portrait;
            displayInfo.frameWidth = winw;
            displayInfo.frameHeight = winh;
            displayInfo.screenWidth = sw;
            displayInfo.screenHeight = sh;
            displayInfo.width = winw;
            displayInfo.height = winh;
            displayInfo.framebufferWidth = winw;
            displayInfo.framebufferHeight = winh;
            displayInfo.screenDpiScale = 1.0f;
            SetSingleton(displayInfo);

            windowOpen = true;
        }

        protected override void OnDestroy()
        {
            // close window
            if (windowOpen)
            {
                GLFWNativeCalls.destroy_window();
                windowOpen = false;
            }

            if (initialized)
            {
                GLFWNativeCalls.shutdown(0);
                initialized = false;
            }

            base.OnDestroy();
        }

        protected override void OnUpdate()
        {
            if (!windowOpen)
                return;

            var displayInfo = GetSingleton<DisplayInfo>();
            GLFWNativeCalls.getWindowSize(out int winw, out int winh);
            if (winw != displayInfo.width || winh != displayInfo.height)
            {
                if (displayInfo.autoSizeToFrame)
                {
                    displayInfo.width = winw;
                    displayInfo.height = winh;
                    displayInfo.frameWidth = winw;
                    displayInfo.frameHeight = winh;
                    displayInfo.framebufferWidth = winw;
                    displayInfo.framebufferHeight = winh;
                    SetSingleton(displayInfo);
                }
                else
                {
                    GLFWNativeCalls.resize(displayInfo.width, displayInfo.height);
                }
            }
            if (GLFWNativeCalls.getWindowShouldClose() == 1)
            {
                World.QuitUpdate = true;
                return;
            }
        }
    }

    internal static class GLFWNativeCalls
    {
        [DllImport("lib_unity_tiny_glfw", EntryPoint = "init_glfw")]
        public static extern int init();

        [DllImport("lib_unity_tiny_glfw", EntryPoint = "create_window_glfw")]
        public static extern int create_window(int width, int height);

        [DllImport("lib_unity_tiny_glfw", EntryPoint = "show_window_glfw")]
        public static extern void show_window(int show);

        [DllImport("lib_unity_tiny_glfw", EntryPoint = "destroy_window_glfw")]
        public static extern void destroy_window();

        [DllImport("lib_unity_tiny_glfw", EntryPoint = "getWindowSize_glfw")]
        public static extern void getWindowSize(out int width, out int height);

        [DllImport("lib_unity_tiny_glfw", EntryPoint = "getScreenSize_glfw")]
        public static extern void getScreenSize(out int width, out int height);

        [DllImport("lib_unity_tiny_glfw", EntryPoint = "getWindowFrameSize_glfw")]
        public static extern void getWindowFrameSize(out int left, out int top, out int right, out int bottom);

        [DllImport("lib_unity_tiny_glfw", EntryPoint = "get_got_focus_glfw")]
        public static extern int getWindowGotFocus();

        [DllImport("lib_unity_tiny_glfw", EntryPoint = "get_lost_focus_glfw")]
        public static extern int getWindowLostFocus();

        [DllImport("lib_unity_tiny_glfw", EntryPoint = "shutdown_glfw")]
        public static extern void shutdown(int exitCode);

        [DllImport("lib_unity_tiny_glfw", EntryPoint = "resize_glfw")]
        public static extern void resize(int width, int height);

        [DllImport("lib_unity_tiny_glfw", EntryPoint = "get_should_close_glfw")]
        public static extern int getWindowShouldClose();

        [DllImport("lib_unity_tiny_glfw", EntryPoint = "getwindow_glfw")]
        public static extern unsafe void *getWindow();

        [DllImport("lib_unity_tiny_glfw", EntryPoint = "get_key_stream_glfw_input")]
        public static extern unsafe int * getKeyStream(ref int len);

        [DllImport("lib_unity_tiny_glfw", EntryPoint = "get_mouse_pos_stream_glfw_input")]
        public static extern unsafe int * getMousePosStream(ref int len);

        [DllImport("lib_unity_tiny_glfw", EntryPoint = "get_mouse_button_stream_glfw_input")]
        public static extern unsafe int * getMouseButtonStream(ref int len);

        [DllImport("lib_unity_tiny_glfw", EntryPoint = "get_mouse_scroll_stream_glfw_input")]
        public static extern unsafe float * getMouseScrollStream(ref int len);

        [DllImport("lib_unity_tiny_glfw", EntryPoint = "init_glfw_input")]
        public static extern bool init_input();

        [DllImport("lib_unity_tiny_glfw", EntryPoint = "set_mouse_mode")]
        public static extern void setMouseMode(int mode);

        [DllImport("lib_unity_tiny_glfw", EntryPoint = "lock_glfw_input")]
        public static extern unsafe void lockStreams();

        [DllImport("lib_unity_tiny_glfw", EntryPoint = "unlock_and_reset_glfw_input")]
        public static extern void unlockAndResetStreams();

        [DllImport("lib_unity_tiny_glfw", EntryPoint = "glfw_get_platform_window_handle")]
        public static extern IntPtr getPlatformWindowHandle();

#if UNITY_MACOSX
        [DllImport("lib_unity_tiny_glfw", EntryPoint = "create_metal_layer_for_window")]
        [return : MarshalAs(UnmanagedType.I1)]
        public static extern bool create_metal_layer_for_window(IntPtr nsWindow, out IntPtr metalLayerOut);
#endif
    }
}
