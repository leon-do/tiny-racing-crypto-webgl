using System;
using System.Diagnostics;
using Unity.Entities;
using System.Runtime.InteropServices;
using Unity.Assertions;
using Unity.Mathematics;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Platforms;

namespace Unity.Tiny.Android
{
    [UpdateInGroup(typeof(InitializationSystemGroup))]
    public class AndroidWindowSystem : WindowSystem
    {
        private static AndroidWindowSystem sWindowSystem;
        public AndroidWindowSystem()
        {
            m_Initialized = false;
            sWindowSystem = this;
        }

        public override IntPtr GetPlatformWindowHandle()
        {
            return (IntPtr)AndroidNativeCalls.getNativeWindow();
        }

        internal class MonoPInvokeCallbackAttribute : Attribute
        {
        }

        [MonoPInvokeCallbackAttribute]
        static void ManagedOnPauseCallback(int pause)
        {
            PlatformEvents.SendSuspendResumeEvent(sWindowSystem, new SuspendResumeEvent(pause != 0));
        }

        private void SetOnPauseCallback()
        {
            AndroidNativeCalls.set_pause_callback(Marshal.GetFunctionPointerForDelegate((Action<int>)ManagedOnPauseCallback));
        }

        [MonoPInvokeCallbackAttribute]
        static void ManagedOnDestroyCallback()
        {
            PlatformEvents.SendQuitEvent(sWindowSystem, new QuitEvent());
        }

        private void SetOnDestroyCallback()
        {
            AndroidNativeCalls.set_destroy_callback(Marshal.GetFunctionPointerForDelegate((Action)ManagedOnDestroyCallback));
        }

        [MonoPInvokeCallbackAttribute]
        static void ManagedOnScreenOrientationChangedCallback(int orientation)
        {
            sWindowSystem.OnScreenOrientationChanged(orientation);
        }

        private void SetOnScreenOrientationChangedCallback()
        {
            AndroidNativeCalls.set_screen_orientation_callback(Marshal.GetFunctionPointerForDelegate((Action<int>)ManagedOnScreenOrientationChangedCallback));
        }

        [MonoPInvokeCallbackAttribute]
        static void ManagedOnDeviceOrientationChangedCallback(int angle)
        {
            sWindowSystem.OnDeviceOrientationChanged(angle);
        }

        private void SetOnDeviceOrientationChangedCallback()
        {
            AndroidNativeCalls.set_device_orientation_callback(Marshal.GetFunctionPointerForDelegate((Action<int>)ManagedOnDeviceOrientationChangedCallback));
        }

        private void SetCallbacks()
        {
            SetOnPauseCallback();
            SetOnDestroyCallback();
            SetOnScreenOrientationChangedCallback();
            SetOnDeviceOrientationChangedCallback();
        }

        public override void DebugReadbackImage(out int w, out int h, out NativeArray<byte> pixels)
        {
            throw new InvalidOperationException("Can no longer read-back from window use BGFX instead.");
        }

        protected override void OnStartRunning()
        {
            base.OnStartRunning();

            // setup window
            Console.WriteLine("Android Window init.");

            try
            {
                m_Initialized = AndroidNativeCalls.init();
            } catch
            {
                Console.WriteLine("  Exception during initialization.");
                m_Initialized = false;
            }
            if (!m_Initialized)
            {
                Console.WriteLine("  Failed.");
                World.QuitUpdate = true;
                return;
            }

            SetCallbacks();

            UpdateDisplayInfo(true);

            CheckAllowedOrientation(ScreenOrientation.Portrait);
            CheckAllowedOrientation(ScreenOrientation.ReversePortrait);
            CheckAllowedOrientation(ScreenOrientation.Landscape);
            CheckAllowedOrientation(ScreenOrientation.ReverseLandscape);
            SetOrientationMask(m_ScreenOrientationMask);
        }

        protected override void OnDestroy()
        {
            // close window
            if (m_Initialized)
            {
                Console.WriteLine("Android Window shutdown.");
                AndroidNativeCalls.shutdown(0);
                m_Initialized = false;
            }
        }

        protected override void OnUpdate()
        {
            if (!m_Initialized)
                return;

            UpdateDisplayInfo(false);
            if (!AndroidNativeCalls.messagePump())
            {
                Console.WriteLine("Android message pump exit.");
                AndroidNativeCalls.shutdown(1);
                World.QuitUpdate = true;
                m_Initialized = false;
                return;
            }
        }

        private void UpdateDisplayInfo(bool firstTime)
        {
            var config = GetSingleton<DisplayInfo>();
            if (firstTime)
            {
                config.focused = true;
                config.visible = true;
                config.screenDpiScale = 1.0f;
                config.orientation = m_ScreenOrientation;
            }
            int sw = 0, sh = 0;
            AndroidNativeCalls.getScreenSize(ref sw, ref sh);
            int winw = 0, winh = 0;
            AndroidNativeCalls.getWindowSize(ref winw, ref winh);
            if (firstTime || m_ScreenOrientation != config.orientation ||
                sw != config.screenWidth || sh != config.screenHeight ||
                winw != config.width || winh != config.height ||
                config.framebufferWidth != config.width || config.framebufferHeight != config.height)
            {
                Console.WriteLine($"Android Window update, screen size {sw} x {sh}, window size {winw} x {winh}, orientation {(int)m_ScreenOrientation}");
                if (config.orientation != m_ScreenOrientation)
                {
                    PlatformEvents.SendScreenOrientationEvent(this, new ScreenOrientationEvent((int)m_ScreenOrientation));
                    config.orientation = m_ScreenOrientation;
                }
                config.screenWidth = sw;
                config.screenHeight = sh;
                if (config.autoSizeToFrame)
                {
                    config.width = sw;
                    config.height = sh;
                }
                else
                {
                    AndroidNativeCalls.setResolution(config.width, config.height);
                }
                config.frameWidth = config.width;
                config.frameHeight = config.height;
                config.framebufferWidth = config.width;
                config.framebufferHeight = config.height;
                SetSingleton(config);
            }
        }

        // taken from Android SDK android.content.pm.ActivityInfo class
        private enum AndroidScreenOrientation
        {
            SCREEN_ORIENTATION_LANDSCAPE = 0,
            SCREEN_ORIENTATION_PORTRAIT = 1,
            SCREEN_ORIENTATION_REVERSE_LANDSCAPE = 8,
            SCREEN_ORIENTATION_REVERSE_PORTRAIT = 9
        }

        private AndroidScreenOrientation ConvertToAndroidOrientation(ScreenOrientation orientation)
        {
            switch (orientation)
            {
                case ScreenOrientation.Portrait: return AndroidScreenOrientation.SCREEN_ORIENTATION_PORTRAIT;
                case ScreenOrientation.Landscape: return AndroidScreenOrientation.SCREEN_ORIENTATION_LANDSCAPE;
                case ScreenOrientation.ReversePortrait: return AndroidScreenOrientation.SCREEN_ORIENTATION_REVERSE_PORTRAIT;
                case ScreenOrientation.ReverseLandscape: return AndroidScreenOrientation.SCREEN_ORIENTATION_REVERSE_LANDSCAPE;
            }
            return AndroidScreenOrientation.SCREEN_ORIENTATION_PORTRAIT; // shouldn't happen
        }

        private ScreenOrientation ConvertFromAndroidOrientation(int/*AndroidScreenOrientation*/ orientation)
        {
            switch (orientation)
            {
                case (int)AndroidScreenOrientation.SCREEN_ORIENTATION_PORTRAIT: return ScreenOrientation.Portrait;
                case (int)AndroidScreenOrientation.SCREEN_ORIENTATION_LANDSCAPE: return ScreenOrientation.Landscape;
                case (int)AndroidScreenOrientation.SCREEN_ORIENTATION_REVERSE_PORTRAIT: return ScreenOrientation.ReversePortrait;
                case (int)AndroidScreenOrientation.SCREEN_ORIENTATION_REVERSE_LANDSCAPE: return ScreenOrientation.ReverseLandscape;
            }
            return ScreenOrientation.Portrait;
        }

        private void CheckAllowedOrientation(ScreenOrientation orientation)
        {
            if (AndroidNativeCalls.isOrientationAllowed((int)ConvertToAndroidOrientation(orientation)))
            {
                m_AllowedOrientations |= orientation;
            }
        }

        public override void SetOrientationMask(ScreenOrientation orientation)
        {
            Assert.IsTrue(orientation != ScreenOrientation.Unknown, "Orientation mask cannot be 0");
            var allowedOrientationMask = orientation & m_AllowedOrientations;
            if (allowedOrientationMask == 0)
            {
                Console.WriteLine($"Orientation mask {(int)orientation} is disabled in project settings");
                return;
            }
            m_ScreenOrientationMask = orientation;
            var screenOrientation = GetOrientation();
            if (m_DeviceOrientation != screenOrientation && (m_DeviceOrientation & allowedOrientationMask) != 0)
            {
                // it is possible to set screen orientation based on current device orientation
                if (AndroidNativeCalls.setOrientation((int)ConvertToAndroidOrientation(m_DeviceOrientation)))
                {
                    m_ScreenOrientation = m_DeviceOrientation;
                }
            }
            else if ((screenOrientation & allowedOrientationMask) == 0)
            {
                // current orientation is not allowed anymore, trying to find the "best" possibile enabled variant
                var newOrientation = ScreenOrientation.Portrait;
                if (screenOrientation == ScreenOrientation.Portrait && (ScreenOrientation.ReversePortrait & allowedOrientationMask) != 0)
                {
                    newOrientation = ScreenOrientation.ReversePortrait;
                }
                else if (screenOrientation == ScreenOrientation.ReversePortrait && (ScreenOrientation.Portrait & allowedOrientationMask) != 0)
                {
                    newOrientation = ScreenOrientation.Portrait;
                }
                else if (screenOrientation == ScreenOrientation.Landscape && (ScreenOrientation.ReverseLandscape & allowedOrientationMask) != 0)
                {
                    newOrientation = ScreenOrientation.ReverseLandscape;
                }
                else if (screenOrientation == ScreenOrientation.ReverseLandscape && (ScreenOrientation.Landscape & allowedOrientationMask) != 0)
                {
                    newOrientation = ScreenOrientation.Landscape;
                }
                else if ((ScreenOrientation.Portrait & allowedOrientationMask) != 0)
                {
                    newOrientation = ScreenOrientation.Portrait;
                }
                else if ((ScreenOrientation.Landscape & allowedOrientationMask) != 0)
                {
                    newOrientation = ScreenOrientation.Landscape;
                }
                else if ((ScreenOrientation.ReversePortrait & allowedOrientationMask) != 0)
                {
                    newOrientation = ScreenOrientation.ReversePortrait;
                }
                else if ((ScreenOrientation.ReverseLandscape & allowedOrientationMask) != 0)
                {
                    newOrientation = ScreenOrientation.ReverseLandscape;
                }
                else
                {
                    Assert.IsTrue(false, "Unexpected orientation mask {(int)m_ScreenOrientationMask}");
                }
                if (AndroidNativeCalls.setOrientation((int)ConvertToAndroidOrientation(newOrientation)))
                {
                    m_ScreenOrientation = newOrientation;
                }
            }
        }

        public override ScreenOrientation GetOrientationMask()
        {
            return m_ScreenOrientationMask;
        }

        private void OnScreenOrientationChanged(int orientation)
        {
            m_ScreenOrientation = ConvertFromAndroidOrientation(orientation);
        }

        private void OnDeviceOrientationChanged(int orientation)
        {
            var deviceOrientation = ConvertFromAndroidOrientation(orientation);
            if (deviceOrientation != m_DeviceOrientation)
            {
                PlatformEvents.SendDeviceOrientationEvent(this, new DeviceOrientationEvent((int)deviceOrientation));
                if ((deviceOrientation & m_ScreenOrientationMask) != 0)
                {
                    AndroidNativeCalls.setOrientation(orientation);
                }
                m_DeviceOrientation = deviceOrientation;
            }
        }

        private ScreenOrientation m_DeviceOrientation = ScreenOrientation.Unknown;
        private ScreenOrientation m_ScreenOrientation = ScreenOrientation.Unknown;
        private ScreenOrientation m_ScreenOrientationMask = ScreenOrientation.AutoRotation;
        private ScreenOrientation m_AllowedOrientations = ScreenOrientation.Unknown;

        private bool m_Initialized;
    }

    public static class AndroidNativeCalls
    {
        [DllImport("lib_unity_tiny_android", EntryPoint = "init_android")]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool init();

        [DllImport("lib_unity_tiny_android", EntryPoint = "getWindowSize_android")]
        public static extern void getWindowSize(ref int w, ref int h);

        [DllImport("lib_unity_tiny_android", EntryPoint = "getScreenSize_android")]
        public static extern void getScreenSize(ref int w, ref int h);

        [DllImport("lib_unity_tiny_android", EntryPoint = "shutdown_android")]
        public static extern void shutdown(int exitCode);

        [DllImport("lib_unity_tiny_android", EntryPoint = "resize_android")]
        public static extern void resize(int width, int height);

        [DllImport("lib_unity_tiny_android", EntryPoint = "messagePump_android")]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool messagePump();

        [DllImport("lib_unity_tiny_android", EntryPoint = "pausecallbackinit_android")]
        public static extern bool set_pause_callback(IntPtr func);

        [DllImport("lib_unity_tiny_android", EntryPoint = "destroycallbackinit_android")]
        public static extern bool set_destroy_callback(IntPtr func);

        [DllImport("lib_unity_tiny_android", EntryPoint = "screen_orientationcallbackinit_android")]
        public static extern bool set_screen_orientation_callback(IntPtr func);

        [DllImport("lib_unity_tiny_android", EntryPoint = "device_orientationcallbackinit_android")]
        public static extern bool set_device_orientation_callback(IntPtr func);

        [DllImport("lib_unity_tiny_android", EntryPoint = "get_touch_info_stream_android")]
        public static extern unsafe int * getTouchInfoStream(ref int len);

        [DllImport("lib_unity_tiny_android", EntryPoint = "input_streams_lock_android")]
        public static extern void inputStreamsLock(bool lck);

        [DllImport("lib_unity_tiny_android", EntryPoint = "get_key_stream_android")]
        public static extern unsafe int * getKeyStream(ref int len);

        [DllImport("lib_unity_tiny_android", EntryPoint = "get_native_window_android")]
        public static extern long getNativeWindow();

        [DllImport("lib_unity_tiny_android", EntryPoint = "reset_input_android")]
        public static extern void resetInputStreams();

        [DllImport("lib_unity_tiny_android", EntryPoint = "available_sensor_android")]
        public static extern bool availableSensor(int type);

        [DllImport("lib_unity_tiny_android", EntryPoint = "enable_sensor_android")]
        public static extern bool enableSensor(int type, bool enable, int rate);

        [DllImport("lib_unity_tiny_android", EntryPoint = "get_sensor_stream_android")]
        public static extern unsafe double * getSensorStream(int type, ref int len);

        [DllImport("lib_unity_tiny_android", EntryPoint = "set_resolution_android")]
        public static extern bool setResolution(int width, int height);

        [DllImport("lib_unity_tiny_android", EntryPoint = "set_orientation_android")]
        public static extern bool setOrientation(int orientation);

        [DllImport("lib_unity_tiny_android", EntryPoint = "is_orientation_allowed_android")]
        public static extern bool isOrientationAllowed(int orientation);

        [DllImport("lib_unity_tiny_android", EntryPoint = "get_natural_orientation_android")]
        public static extern int getNaturalOrientation();

        [DllImport("lib_unity_tiny_android", EntryPoint = "show_debug_dialog", CharSet = CharSet.Ansi)]
        public static extern void showDebugDialog([MarshalAs(UnmanagedType.LPStr)]string message);
    }

}

