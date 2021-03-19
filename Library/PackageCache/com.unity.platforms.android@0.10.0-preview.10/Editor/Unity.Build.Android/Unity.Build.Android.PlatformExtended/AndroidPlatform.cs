namespace Unity.Build.Android
{
    /// <summary>
    /// Android platform.
    /// </summary>
    public sealed class AndroidPlatform : Platform
    {
        public AndroidPlatform() : base(KnownPlatforms.Android.PlatformInfo) { }
    }
}

namespace Unity.Build
{
    public abstract partial class Platform
    {
        public static Platform Android { get; } = new Unity.Build.Android.AndroidPlatform();
    }
}
