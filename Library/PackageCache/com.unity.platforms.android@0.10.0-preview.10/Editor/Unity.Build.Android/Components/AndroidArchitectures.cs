using Unity.Build.Classic.Private;
using Unity.Serialization;
using UnityEditor;

namespace Unity.Build.Android
{
    [FormerName("Unity.Platforms.Android.Build.AndroidArchitectures, Unity.Platforms.Android.Build")]
    internal sealed partial class AndroidArchitectures : IBuildComponent, IBuildComponentInitialize
    {
        public void Initialize(BuildConfiguration.ReadOnly config)
        {
            if (!(config.GetBuildPipeline() is ClassicPipelineBase))
                return;

            Architectures = (AndroidArchitecture)UnityEditor.PlayerSettings.Android.targetArchitectures;
        }
    }
}
