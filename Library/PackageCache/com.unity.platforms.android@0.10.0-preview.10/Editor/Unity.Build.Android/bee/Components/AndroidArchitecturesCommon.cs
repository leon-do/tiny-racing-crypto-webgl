using Unity.Properties;

namespace Unity.Build.Android
{
    internal sealed partial class AndroidArchitectures
    {
        [CreateProperty]
        public AndroidArchitecture Architectures { get; set; } = AndroidArchitecture.ARMv7 | AndroidArchitecture.ARM64;
    }
}
