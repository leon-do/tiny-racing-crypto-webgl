using Unity.Properties;

namespace Unity.Build.Android
{
    internal enum Requirement
    {
        Required,
        Optional
    }

    internal sealed partial class ARCoreSettings
    {
        [CreateProperty]
        public Requirement Requirement { set; get; } = Requirement.Required;

        [CreateProperty]
        public Requirement DepthSupport { set; get; } = Requirement.Optional;
    }
}
