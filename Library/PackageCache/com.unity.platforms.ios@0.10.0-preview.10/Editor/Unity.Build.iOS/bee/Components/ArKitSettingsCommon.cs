using Unity.Properties;

namespace Unity.Build.iOS
{
    internal enum Requirement
    {
        Required,
        Optional
    }

    internal sealed partial class ARKitSettings
    {
        [CreateProperty]
        public Requirement Requirement { set; get; } = Requirement.Required;

        [CreateProperty]
        public bool FaceTrackingSupport { set; get; } = false;

        public const string FaceTrackingDefine = "UNITY_XR_IOS_ARKIT_FACETRACKING_ENABLED";
    }
}
