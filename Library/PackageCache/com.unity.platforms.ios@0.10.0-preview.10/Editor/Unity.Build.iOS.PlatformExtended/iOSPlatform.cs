namespace Unity.Build.iOS
{
    /// <summary>
    /// iOS platform.
    /// </summary>
    public sealed class iOSPlatform : Platform
    {
        public iOSPlatform() : base(KnownPlatforms.iOS.PlatformInfo) { }
    }
}

namespace Unity.Build
{
    public abstract partial class Platform
    {
        public static Platform iOS { get; } = new Unity.Build.iOS.iOSPlatform();
    }
}
