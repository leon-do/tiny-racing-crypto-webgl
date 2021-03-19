using System;
using Unity.Properties;
using UnityEngine;

namespace Unity.Build.iOS
{
    internal enum iOSSdkVersion
    {
        // Device SDK
        DeviceSDK = 988,
        // Simulator SDK
        SimulatorSDK = 989
    }

    internal enum iOSTargetDevice
    {
        // iPhone/iPod Only
        [InspectorName("iPhone only")]
        iPhoneOnly = 0,

        // iPad Only
        [InspectorName("iPad only")]
        iPadOnly = 1,

        // Universal : iPhone/iPod + iPad
        [InspectorName("iPhone + iPad")]
        iPhoneAndiPad = 2,
    }

    internal sealed partial class iOSTargetSettings
    {
        [CreateProperty] public System.Version TargetVersion { set; get; } = new System.Version(10, 0);
        [CreateProperty] public iOSSdkVersion SdkVersion { set; get; } = iOSSdkVersion.DeviceSDK;
        [CreateProperty] public iOSTargetDevice TargetDevice { set; get; } = iOSTargetDevice.iPhoneAndiPad;

        public string GetTargetDeviceFamily()
        {
            if (TargetDevice == iOSTargetDevice.iPhoneAndiPad)
                return "1,2";
            if (TargetDevice == iOSTargetDevice.iPhoneOnly)
                return "1";
            if (TargetDevice == iOSTargetDevice.iPadOnly)
                return "2";
            throw new Exception("Wrong target device family");
        }

        public string GetTargetArchitecture()
        {
            return SdkVersion == iOSSdkVersion.SimulatorSDK ? "x86_64" : "arm64";
        }
    }
}
