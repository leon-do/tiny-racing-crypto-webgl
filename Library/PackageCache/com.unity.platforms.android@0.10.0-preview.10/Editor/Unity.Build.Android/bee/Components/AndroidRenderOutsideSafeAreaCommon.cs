using System;
using Unity.Properties;

namespace Unity.Build.Android
{
    internal sealed partial class AndroidRenderOutsideSafeArea
    {
        public static string CutoutMode(bool on)
        {
            return on ? "shortEdges" : "never";
        }

        // Xiaomi specific
        public static string NotchConfig(bool on)
        {
            return on ? "portrait|landscape" : "none";
        }

        // Huawei specific
        public static string NotchSupport(bool on)
        {
            return on ? "true" : "false";
        }
    }
}
