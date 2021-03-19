using System;
using Unity.Build.Classic.Private;
using Unity.Serialization;
using UnityEditor;

namespace Unity.Build.Android
{
    [FormerName("Unity.Platforms.Android.Build.AndroidAPILevels, Unity.Platforms.Android.Build")]
    internal sealed partial class AndroidAPILevels : IBuildComponent, IBuildComponentInitialize
    {
        public void Initialize(BuildConfiguration.ReadOnly config)
        {
            if (!(config.GetBuildPipeline() is ClassicPipelineBase))
                return;

            m_MinAPILevel = (AndroidSdkVersions)PlayerSettings.Android.minSdkVersion;
            m_TargetAPILevel = (AndroidSdkVersions)PlayerSettings.Android.targetSdkVersion;
        }
    }
}
