using System;
using Unity.Properties;

namespace Unity.Build.Android
{
    internal sealed partial class AndroidAPILevels
    {
        const AndroidSdkVersions kMinAPILevel = AndroidSdkVersions.AndroidApiLevel19;
        const AndroidSdkVersions kMaxAPILevel = AndroidSdkVersions.AndroidApiLevel29;
        AndroidSdkVersions m_MinAPILevel = kMinAPILevel;
        AndroidSdkVersions m_TargetAPILevel = AndroidSdkVersions.AndroidApiLevelAuto;

        [CreateProperty]
        public AndroidSdkVersions MinAPILevel
        {
            get
            {
                if (m_MinAPILevel == AndroidSdkVersions.AndroidApiLevelAuto)
                    return kMinAPILevel;
                if (m_TargetAPILevel == AndroidSdkVersions.AndroidApiLevelAuto)
                    return m_MinAPILevel;

                // Min Level cannot be higher than target level
                return (AndroidSdkVersions)Math.Min((int)m_MinAPILevel, (int)m_TargetAPILevel);
            }

            set => m_MinAPILevel = value;
        }

        [CreateProperty]
        public AndroidSdkVersions TargetAPILevel
        {
            get => m_TargetAPILevel;
            set => m_TargetAPILevel = value;
        }

        public AndroidSdkVersions ResolvedTargetAPILevel
        {
            get
            {
                // TODO this is wrong, user can set custom SDK, which might have higher target API installed
                if (m_TargetAPILevel == AndroidSdkVersions.AndroidApiLevelAuto)
                    return kMaxAPILevel;
                return m_TargetAPILevel;
            }
        }

        public bool TargetSDKSupportsAdaptiveIcons => (int)ResolvedTargetAPILevel >= 26;
    }
}
