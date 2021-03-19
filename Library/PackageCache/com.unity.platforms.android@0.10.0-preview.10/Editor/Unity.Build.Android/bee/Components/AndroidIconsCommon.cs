using Unity.Properties;

namespace Unity.Build.Android
{
    internal enum ScreenDPI
    {
        MDPI = 0,
        HDPI,
        XHDPI,
        XXHDPI,
        XXXHDPI
    }

    internal sealed class IconsSet
    {
        [CreateProperty]
        public string Foreground { get; set; } = string.Empty;

        [CreateProperty]
        public string Background { get; set; } = string.Empty;

        [CreateProperty]
        public string Legacy { get; set; } = string.Empty;
    }

    internal sealed partial class AndroidIcons
    {
        public static int DPICount => System.Enum.GetValues(typeof(ScreenDPI)).Length;

        [CreateProperty]
        public ScreenDPI ScreenDPI { get; set; }

        [CreateProperty]
        public IconsSet[] Icons { get; set; } = new IconsSet[DPICount];
    }
}
