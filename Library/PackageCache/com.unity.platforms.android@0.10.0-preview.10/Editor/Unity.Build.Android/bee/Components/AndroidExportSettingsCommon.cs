using Unity.Properties;

namespace Unity.Build.Android
{
    internal enum AndroidBuildSystem
    {
        Gradle,
        VisualStudio
    }

    internal enum AndroidTargetType
    {
        AndroidPackage,
        AndroidAppBundle
    }

    internal sealed partial class AndroidExportSettings
    {
        [CreateProperty] public AndroidTargetType TargetType { set; get; } = AndroidTargetType.AndroidPackage;
        [CreateProperty] public bool ExportProject { set; get; } = false;
        [CreateProperty] public AndroidBuildSystem BuildSystem { set; get; } = AndroidBuildSystem.Gradle;
    }
}
