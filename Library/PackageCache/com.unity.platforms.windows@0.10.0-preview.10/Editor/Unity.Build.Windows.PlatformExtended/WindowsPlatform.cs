namespace Unity.Build.Windows
{
    /// <summary>
    /// Windows platform.
    /// </summary>
    public sealed class WindowsPlatform : Platform
    {
        public WindowsPlatform() : base(KnownPlatforms.Windows.PlatformInfo) { }
    }
}

namespace Unity.Build
{
    public abstract partial class Platform
    {
        public static Platform Windows { get; } = new Unity.Build.Windows.WindowsPlatform();
    }
}
