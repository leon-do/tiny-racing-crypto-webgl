using System;

namespace Unity.Build.Android
{
    // Supported Android SDK versions
    public enum AndroidSdkVersions
    {
        // Set target API level to latest installed
        AndroidApiLevelAuto = 0,

        // Android 4.1, "Jelly Bean", API level 16
        [Obsolete("Minimum supported Android API level is 19 (Android 4.4 KitKat). Please use AndroidApiLevel19 or higher", true)]
        AndroidApiLevel16 = 16,

        // Android 4.2, "Jelly Bean", API level 17
        [Obsolete("Minimum supported Android API level is 19 (Android 4.4 KitKat). Please use AndroidApiLevel19 or higher", true)]
        AndroidApiLevel17 = 17,

        // Android 4.3, "Jelly Bean", API level 18
        [Obsolete("Minimum supported Android API level is 19 (Android 4.4 KitKat). Please use AndroidApiLevel19 or higher", true)]
        AndroidApiLevel18 = 18,

        // Android 4.4, "KitKat", API level 19
        AndroidApiLevel19 = 19,

        // Android 5.0, "Lollipop", API level 21
        AndroidApiLevel21 = 21,

        // Android 5.1, "Lollipop", API level 22
        AndroidApiLevel22 = 22,

        // Android 6.0, "Marshmallow", API level 23
        AndroidApiLevel23 = 23,

        // Android 7.0, "Nougat", API level 24
        AndroidApiLevel24 = 24,

        // Android 7.1, "Nougat", API level 25
        AndroidApiLevel25 = 25,

        // Android 8.0, "Oreo", API level 26
        AndroidApiLevel26 = 26,

        // Android 8.1, "Oreo", API level 27
        AndroidApiLevel27 = 27,

        // Android 9.0, "Pie", API level 28
        AndroidApiLevel28 = 28,

        // Android 10.0, API level 29
        AndroidApiLevel29 = 29,
    }
}
