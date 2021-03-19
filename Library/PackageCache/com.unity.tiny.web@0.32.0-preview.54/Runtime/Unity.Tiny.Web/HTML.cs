using System;
using System.Diagnostics;
using Unity.Entities;
using System.Runtime.InteropServices;
using Unity.Mathematics;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Platforms;

namespace Unity.Tiny.Web
{
    [UpdateInGroup(typeof(InitializationSystemGroup))]
    public class HTMLWindowSystem : WindowSystem
    {
        private static HTMLWindowSystem sWindowSystem;
        public HTMLWindowSystem()
        {
            sWindowSystem = this;
        }

        public override void DebugReadbackImage(out int w, out int h, out NativeArray<byte> pixels)
        {
            var displayInfo = GetSingleton<DisplayInfo>();
            pixels = new NativeArray<byte>(displayInfo.framebufferWidth * displayInfo.framebufferHeight * 4, Allocator.Persistent);
            unsafe
            {
                HTMLNativeCalls.debugReadback(displayInfo.framebufferWidth, displayInfo.framebufferHeight, pixels.GetUnsafePtr());
            }

            w = displayInfo.framebufferWidth;
            h = displayInfo.framebufferHeight;
        }

        IntPtr m_PlatformCanvasName;
        public override IntPtr GetPlatformWindowHandle()
        {
            if (m_PlatformCanvasName == IntPtr.Zero)
            {
                m_PlatformCanvasName = Marshal.StringToCoTaskMemAnsi("#UT_CANVAS");
            }
            return m_PlatformCanvasName;
        }

        internal class MonoPInvokeCallbackAttribute : Attribute
        {
        }

        [MonoPInvokeCallbackAttribute]
        static void ManagedOnPauseCallback(int pause)
        {
            PlatformEvents.SendSuspendResumeEvent(sWindowSystem, new SuspendResumeEvent(pause != 0));
        }

        [MonoPInvokeCallbackAttribute]
        static void ManagedOnDestroyCallback()
        {
            PlatformEvents.SendQuitEvent(sWindowSystem, new QuitEvent());
        }

        private void SetCallbacks()
        {
            HTMLNativeCalls.setDestroyCallback(Marshal.GetFunctionPointerForDelegate((Action)ManagedOnDestroyCallback));
            HTMLNativeCalls.setPauseCallback(Marshal.GetFunctionPointerForDelegate((Action<int>)ManagedOnPauseCallback));
        }

        protected override void OnStartRunning()
        {
            base.OnStartRunning();

            // The actual init() call is in DotsRuntime.Initialize().
            //
            // The test cases run without ever running any Systems,
            // so this code in System.OnStartRunning() may never get called
            // by the test suite.
            //
            // That's why the JS init() is run early (in DotsRuntime.Initialize())
            // but additional tasks can be done here.
#if DEBUG
            Debug.Log("HTML Window init.");
#endif
            SetCallbacks();
            UpdateDisplayInfo(firstTime: true);
        }

        protected override void OnDestroy()
        {
            // close window
            Console.WriteLine("HTML Window shutdown.");
            HTMLNativeCalls.shutdown(0);
            base.OnDestroy();
        }

        protected override void OnUpdate()
        {
            UpdateDisplayInfo(firstTime: false);
        }

        private void UpdateDisplayInfo(bool firstTime)
        {
            var di = GetSingleton<DisplayInfo>();

            // TODO DOTSR-994 -- screenDpiScale is being used as both user configuration and information here
            if (di.screenDpiScale == 0.0f)
                di.screenDpiScale = HTMLNativeCalls.getDPIScale();

            HTMLNativeCalls.getScreenSize(ref di.screenWidth, ref di.screenHeight);
            HTMLNativeCalls.getFrameSize(ref di.frameWidth, ref di.frameHeight);

            int wCanvas = 0, hCanvas = 0;
            if (firstTime)
            {
                // TODO DOTSR-994 -- this is a case where we're using width/height as read/write instead of as explicit read or write only
                wCanvas = di.width;
                hCanvas = di.height;
            }
            else
            {
                HTMLNativeCalls.getCanvasSize(ref wCanvas, ref hCanvas);
            }

            if (di.autoSizeToFrame)
            {
                di.width = (int)(di.frameWidth * di.screenDpiScale);
                di.height = (int)(di.frameHeight * di.screenDpiScale);
                wCanvas = di.frameWidth;
                hCanvas = di.frameHeight;
            }
            else if (firstTime)
            {
                di.width = (int)(di.width * di.screenDpiScale);
                di.height = (int)(di.height * di.screenDpiScale);
            }

            di.framebufferWidth = di.width;
            di.framebufferHeight = di.height;

            unsafe
            {
                if (firstTime || UnsafeUtility.MemCmp(UnsafeUtility.AddressOf(ref di), UnsafeUtility.AddressOf(ref lastDisplayInfo), sizeof(DisplayInfo)) != 0)
                {
                    // Only do this if it's the first time, or if the struct values actually changed from the last time we set it
#if DEBUG
                    Debug.Log($"setCanvasSize {firstTime} {wCanvas}px {hCanvas}px (backing {di.framebufferWidth} {di.framebufferHeight}, dpi scale {di.screenDpiScale})");
#endif
                    HTMLNativeCalls.setCanvasSize(wCanvas, hCanvas, di.framebufferWidth, di.framebufferHeight);
                    SetSingleton(di);
                    lastDisplayInfo = di;
                }
            }
        }

        protected DisplayInfo lastDisplayInfo;
    }

    static class HTMLNativeCalls
    {
        [DllImport("lib_unity_tiny_web", EntryPoint = "shutdown_html")]
        public static extern void shutdown(int exitCode);

        [DllImport("lib_unity_tiny_web", EntryPoint = "destroycallbackinit_html")]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool setDestroyCallback(IntPtr func);

        [DllImport("lib_unity_tiny_web", EntryPoint = "pausecallbackinit_html")]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool setPauseCallback(IntPtr func);

        // calls to HTMLWrapper.js directly
        [DllImport("lib_unity_tiny_web", EntryPoint = "js_html_setCanvasSize")]
        public static extern int setCanvasSize(int cssWidth, int cssHeight, int fbWidth, int fbHeight);

        [DllImport("lib_unity_tiny_web", EntryPoint = "js_html_debugReadback")]
        public static unsafe extern void debugReadback(int w, int h, void *pixels);

        [DllImport("lib_unity_tiny_web", EntryPoint = "js_html_getCanvasSize")]
        public static extern void getCanvasSize(ref int w, ref int h);

        [DllImport("lib_unity_tiny_web", EntryPoint = "js_html_getFrameSize")]
        public static extern void getFrameSize(ref int w, ref int h);

        [DllImport("lib_unity_tiny_web", EntryPoint = "js_html_getScreenSize")]
        public static extern void getScreenSize(ref int w, ref int h);

        [DllImport("lib_unity_tiny_web", EntryPoint = "js_html_getDPIScale")]
        public static extern float getDPIScale();
    }
}
