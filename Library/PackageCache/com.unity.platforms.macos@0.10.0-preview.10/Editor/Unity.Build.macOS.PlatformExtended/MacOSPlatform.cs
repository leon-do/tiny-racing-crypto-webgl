namespace Unity.Build.macOS
{
    /// <summary>
    /// macOS platform.
    /// </summary>
    public sealed class macOSPlatform : Platform
    {
        public macOSPlatform() : base(KnownPlatforms.macOS.PlatformInfo) { }
    }
}

namespace Unity.Build
{
    public abstract partial class Platform
    {
        public static Platform macOS { get; } = new Unity.Build.macOS.macOSPlatform();
    }
}
