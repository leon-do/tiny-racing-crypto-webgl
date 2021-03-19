namespace Unity.Build.Linux
{
    /// <summary>
    /// Linux platform.
    /// </summary>
    public sealed class LinuxPlatform : Platform
    {
        public LinuxPlatform() : base(KnownPlatforms.Linux.PlatformInfo) { }
    }
}

namespace Unity.Build
{
    public abstract partial class Platform
    {
        public static Platform Linux { get; } = new Unity.Build.Linux.LinuxPlatform();
    }
}
