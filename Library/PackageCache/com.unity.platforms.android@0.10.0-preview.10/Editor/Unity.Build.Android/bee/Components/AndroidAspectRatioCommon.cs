using System.Globalization;
using Unity.Properties;

namespace Unity.Build.Android
{
    internal enum AspectRatioMode
    {
        LegacyWideScreen,
        SuperWideScreen,
        Custom
    }

    internal sealed partial class AndroidAspectRatio
    {
        [CreateProperty]
        public AspectRatioMode AspectRatioMode { set; get; } = AspectRatioMode.SuperWideScreen;

        [CreateProperty]
        public float CustomAspectRatio { set; get; } = 2.1f;

        public string GetMaxAspectRatio(AndroidSdkVersions targetSdkVersion)
        {
            if (AspectRatioMode == AspectRatioMode.Custom)
                return CustomAspectRatio.ToString(CultureInfo.InvariantCulture);

            if (targetSdkVersion < AndroidSdkVersions.AndroidApiLevel26)
            {
                // in API level 25 and lower the default maximum aspect ratio is 1.86
                // return 2.1 if super wide screen aspect ratio should be supported
                if (AspectRatioMode == AspectRatioMode.SuperWideScreen)
                    return "2.1";
            }
            else
            {
                // since API level 26 the default maximum aspect ratio is the native aspect ratio of the device
                // return 1.86 if only regular wide screen aspect ratio should be supported
                if (AspectRatioMode == AspectRatioMode.LegacyWideScreen)
                    return "1.86";
            }

            // don't specify max aspect ratio, use default value for the API level
            return "";
        }
    }
}
