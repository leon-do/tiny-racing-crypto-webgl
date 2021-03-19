using System;
using System.Diagnostics;
using Unity.Entities;
using System.Runtime.InteropServices;
using Unity.Assertions;
using Unity.Mathematics;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Platforms;

namespace Unity.Tiny.iOS
{
    [UpdateInGroup(typeof(InitializationSystemGroup))]
    public class iOSWindowSystem : WindowSystem
    {
        private static iOSWindowSystem sWindowSystem;
        public iOSWindowSystem()
        {
            m_initialized = false;
            sWindowSystem = this;
        }

        public override IntPtr GetPlatformWindowHandle()
        {
            unsafe {
                return (IntPtr)iOSNativeCalls.getNativeWindow();
            }
        }

        internal class MonoPInvokeCallbackAttribute : Attribute
        {
        }

        [MonoPInvokeCallbackAttribute]
        static void ManagedOnPauseCallback(int pause)
        {
            PlatformEvents.SendSuspendResumeEvent(sWindowSystem, new SuspendResumeEvent(pause != 0));
        }

        public void SetOnPauseCallback()
        {
            iOSNativeCalls.set_pause_callback(Marshal.GetFunctionPointerForDelegate((Action<int>)ManagedOnPauseCallback));
        }

        [MonoPInvokeCallbackAttribute]
        static void ManagedOnDestroyCallback()
        {
            PlatformEvents.SendQuitEvent(sWindowSystem, new QuitEvent());
        }

        public void SetOnDestroyCallback()
        {
            iOSNativeCalls.set_destroy_callback(Marshal.GetFunctionPointerForDelegate((Action)ManagedOnDestroyCallback));
        }

        [MonoPInvokeCallbackAttribute]
        static void ManagedOnDeviceOrientationChangedCallback(int orientation)
        {
            sWindowSystem.OnDeviceOrientationChanged(orientation);
        }

        public void SetOnDeviceOrientationChangedCallback()
        {
            iOSNativeCalls.set_device_orientation_callback(Marshal.GetFunctionPointerForDelegate((Action<int>)ManagedOnDeviceOrientationChangedCallback));
        }

        private void SetCallbacks()
        {
            SetOnPauseCallback();
            SetOnDestroyCallback();
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
            Console.WriteLine("IOS Window init.");

            try
            {
                m_initialized = iOSNativeCalls.init();
            } catch
            {
                Console.WriteLine("  Exception during initialization.");
                m_initialized = false;
            }
            if (!m_initialized)
            {
                Console.WriteLine("  Failed.");
                World.QuitUpdate = true;
                return;
            }

            SetCallbacks();

            UpdateDisplayInfo(true);

            iOSNativeCalls.set_orientation_mask(ConvertToiOSOrientationMask(m_screenOrientationMask));
            iOSNativeCalls.rotate_to_allowed_orientation();
        }

        protected override void OnDestroy()
        {
            // close window
            if (m_initialized)
            {
                Console.WriteLine("iOS Window shutdown.");
                iOSNativeCalls.shutdown(0);
                m_initialized = false;
            }
        }

        protected override void OnUpdate()
        {
            if (!m_initialized)
                return;

            UpdateDisplayInfo(false);
            if (!iOSNativeCalls.messagePump())
            {
                Console.WriteLine("iOS message pump exit.");
                iOSNativeCalls.shutdown(1);
                World.QuitUpdate = true;
                m_initialized = false;
                return;
            }
        }

        private void UpdateDisplayInfo(bool firstTime)
        {
            int screenOrientation = 0;
            iOSNativeCalls.getScreenOrientation(ref screenOrientation);
            m_screenOrientation = ConvertFromiOSOrientation(screenOrientation);
            var config = GetSingleton<DisplayInfo>();
            if (firstTime)
            {
                config.focused = true;
                config.visible = true;
                config.screenDpiScale = 1.0f;
                config.orientation = m_screenOrientation;
            }
            int sw = 0, sh = 0;
            iOSNativeCalls.getScreenSize(ref sw, ref sh);
            int winw = 0, winh = 0;
            iOSNativeCalls.getWindowSize(ref winw, ref winh);
            if (firstTime || m_screenOrientation != config.orientation ||
                sw != config.screenWidth || sh != config.screenHeight ||
                winw != config.width || winh != config.height ||
                config.framebufferWidth != config.width || config.framebufferHeight != config.height)
            {
                Console.WriteLine($"iOS Window update, screen size {sw} x {sh}, window size {winw} x {winh}, orientation {(int)m_screenOrientation}");
                if (config.orientation != m_screenOrientation)
                {
                    PlatformEvents.SendScreenOrientationEvent(this, new ScreenOrientationEvent((int)m_screenOrientation));
                    config.orientation = m_screenOrientation;
                }
                config.screenWidth = sw;
                config.screenHeight = sh;
                if (config.autoSizeToFrame)
                {
                    config.width = sw;
                    config.height = sh;
                }
                iOSNativeCalls.setWindowSize(config.width, config.height);
                config.frameWidth = config.width;
                config.frameHeight = config.height;
                config.framebufferWidth = config.width;
                config.framebufferHeight = config.height;
                SetSingleton(config);
            }
        }

        // taken from iOS SDK (UIDevice.h)
        enum UIDeviceOrientation
        {
            UIDeviceOrientationUnknown,
            UIDeviceOrientationPortrait,            // Device oriented vertically, home button on the bottom
            UIDeviceOrientationPortraitUpsideDown,  // Device oriented vertically, home button on the top
            UIDeviceOrientationLandscapeLeft,       // Device oriented horizontally, home button on the right
            UIDeviceOrientationLandscapeRight,      // Device oriented horizontally, home button on the left
            UIDeviceOrientationFaceUp,              // Device oriented flat, face up
            UIDeviceOrientationFaceDown             // Device oriented flat, face down
        }

        // taken from iOS SDK (UIApplication.h)
        // Note that UIInterfaceOrientationLandscapeLeft is equal to UIDeviceOrientationLandscapeRight (and vice versa).
        // This is because rotating the device to the left requires rotating the content to the right.
        enum UIInterfaceOrientation {
            UIInterfaceOrientationUnknown            = UIDeviceOrientation.UIDeviceOrientationUnknown,
            UIInterfaceOrientationPortrait           = UIDeviceOrientation.UIDeviceOrientationPortrait,
            UIInterfaceOrientationPortraitUpsideDown = UIDeviceOrientation.UIDeviceOrientationPortraitUpsideDown,
            UIInterfaceOrientationLandscapeLeft      = UIDeviceOrientation.UIDeviceOrientationLandscapeRight,
            UIInterfaceOrientationLandscapeRight     = UIDeviceOrientation.UIDeviceOrientationLandscapeLeft
        }

        private ScreenOrientation ConvertFromiOSOrientation(int/*UIDeviceOrientation*/ orientation)
        {
            // for consistency in Tiny for both device and screen orientations we're using Interface orientation based values
            switch (orientation)
            {
                case (int)UIDeviceOrientation.UIDeviceOrientationPortrait : return ScreenOrientation.Portrait;
                case (int)UIDeviceOrientation.UIDeviceOrientationLandscapeLeft : return ScreenOrientation.Landscape;
                case (int)UIDeviceOrientation.UIDeviceOrientationPortraitUpsideDown : return ScreenOrientation.ReversePortrait;
                case (int)UIDeviceOrientation.UIDeviceOrientationLandscapeRight : return ScreenOrientation.ReverseLandscape;
            }
            // returning unknown orientation for Unknown, FaceUp and FaceDown
            return ScreenOrientation.Unknown; 
        }

        private int ConvertToiOSOrientationMask(ScreenOrientation orientation)
        {
            int ret = 0;
            if ((orientation & ScreenOrientation.Portrait) != 0) ret |= (1 << (int)UIInterfaceOrientation.UIInterfaceOrientationPortrait);
            if ((orientation & ScreenOrientation.ReversePortrait) != 0) ret |= (1 << (int)UIInterfaceOrientation.UIInterfaceOrientationPortraitUpsideDown);
            if ((orientation & ScreenOrientation.Landscape) != 0) ret |= (1 << (int)UIInterfaceOrientation.UIInterfaceOrientationLandscapeRight);
            if ((orientation & ScreenOrientation.ReverseLandscape) != 0) ret |= (1 << (int)UIInterfaceOrientation.UIInterfaceOrientationLandscapeLeft);
            return ret;
        }

        public override void SetOrientationMask(ScreenOrientation orientation)
        {
            Assert.IsTrue(orientation != ScreenOrientation.Unknown, "Orientation mask cannot be 0");
            if (!iOSNativeCalls.set_orientation_mask(ConvertToiOSOrientationMask(orientation)))
            {
                Console.WriteLine($"Orientation mask {(int)orientation} is not allowed for this device or disabled in project settings");
                return;
            }
            m_screenOrientationMask = orientation;
            var screenOrientation = GetOrientation();
            if (m_deviceOrientation != screenOrientation && (m_deviceOrientation & m_screenOrientationMask) != 0)
            {
                // it is possible to set screen orientation based on current device orientation
                iOSNativeCalls.rotate_to_device_orientation();
            }
            else if ((screenOrientation & m_screenOrientationMask) == 0)
            {
                // current orientation is not allowed amymore
                // let iOS rotate to allowed orientation based on new mask
                iOSNativeCalls.rotate_to_allowed_orientation();
            }
        }

        public override ScreenOrientation GetOrientationMask()
        {
            return m_screenOrientationMask;
        }

        private void OnDeviceOrientationChanged(int orientation)
        {
            var deviceOrientation = ConvertFromiOSOrientation(orientation);
            if (deviceOrientation != m_deviceOrientation)
            {
                PlatformEvents.SendDeviceOrientationEvent(this, new DeviceOrientationEvent((int)deviceOrientation));
                m_deviceOrientation = deviceOrientation;
            }
        }

        private ScreenOrientation m_deviceOrientation = ScreenOrientation.Unknown;
        private ScreenOrientation m_screenOrientation = ScreenOrientation.Unknown;
        private ScreenOrientation m_screenOrientationMask = ScreenOrientation.AutoRotation;

        private bool m_initialized;
    }

    public static class iOSNativeCalls
    {
        [DllImport("lib_unity_tiny_ios", EntryPoint = "init_ios")]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool init();

        [DllImport("lib_unity_tiny_ios", EntryPoint = "getWindowSize_ios")]
        public static extern void getWindowSize(ref int w, ref int h);

        [DllImport("lib_unity_tiny_ios", EntryPoint = "setWindowSize_ios")]
        public static extern bool setWindowSize(int width, int height);

        [DllImport("lib_unity_tiny_ios", EntryPoint = "getScreenSize_ios")]
        public static extern void getScreenSize(ref int w, ref int h);

        [DllImport("lib_unity_tiny_ios", EntryPoint = "getScreenOrientation_ios")]
        public static extern void getScreenOrientation(ref int orientation);

        [DllImport("lib_unity_tiny_ios", EntryPoint = "shutdown_ios")]
        public static extern void shutdown(int exitCode);

        [DllImport("lib_unity_tiny_ios", EntryPoint = "messagePump_ios")]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool messagePump();

        [DllImport("lib_unity_tiny_ios", EntryPoint = "pausecallbackinit_ios")]
        public static extern bool set_pause_callback(IntPtr func);

        [DllImport("lib_unity_tiny_ios", EntryPoint = "destroycallbackinit_ios")]
        public static extern bool set_destroy_callback(IntPtr func);

        [DllImport("lib_unity_tiny_ios", EntryPoint = "device_orientationcallbackinit_ios")]
        public static extern bool set_device_orientation_callback(IntPtr func);

        [DllImport("lib_unity_tiny_ios", EntryPoint = "input_streams_lock_ios")]
        public static extern void inputStreamsLock(bool lck);

        [DllImport("lib_unity_tiny_ios", EntryPoint = "get_touch_info_stream_ios")]
        public static extern unsafe int * getTouchInfoStream(ref int len);

        [DllImport("lib_unity_tiny_ios", EntryPoint = "get_native_window_ios")]
        public static extern unsafe void * getNativeWindow();

        [DllImport("lib_unity_tiny_ios", EntryPoint = "reset_input_ios")]
        public static extern void resetStreams();

        [DllImport("lib_unity_tiny_ios", EntryPoint = "available_sensor_ios")]
        public static extern bool availableSensor(int type);

        [DllImport("lib_unity_tiny_ios", EntryPoint = "enable_sensor_ios")]
        public static extern bool enableSensor(int type, bool enable);

        [DllImport("lib_unity_tiny_ios", EntryPoint = "set_sensor_frequency_ios")]
        public static extern void setSensorFrequency(int type, int rate);

        [DllImport("lib_unity_tiny_ios", EntryPoint = "get_sensor_frequency_ios")]
        public static extern int getSensorFrequency(int type);

        [DllImport("lib_unity_tiny_ios", EntryPoint = "get_sensor_stream_ios")]
        public static extern unsafe double * getSensorStream(int type, ref int len);

        [DllImport("lib_unity_tiny_ios", EntryPoint = "setOrientationMask_ios")]
        public static extern bool set_orientation_mask(int orientation);

        [DllImport("lib_unity_tiny_ios", EntryPoint = "rotateToDeviceOrientation_ios")]
        public static extern bool rotate_to_device_orientation();

        [DllImport("lib_unity_tiny_ios", EntryPoint = "rotateToAllowedOrientation_ios")]
        public static extern bool rotate_to_allowed_orientation();

    }

}

