using System.Diagnostics;
using System.IO;
using Unity.Build.Classic;
using Unity.Build.Classic.Private;
using Unity.Build.Common;
using UnityEditor;

namespace Unity.Build.Linux.Classic
{
    sealed class LinuxClassicNonIncrementalPipeline : ClassicNonIncrementalPipelineBase
    {
        public override Platform Platform => Platform.Linux;

        public override BuildStepCollection BuildSteps { get; } = new[]
        {
            typeof(SaveScenesAndAssetsStep),
            typeof(ApplyUnitySettingsStep),
            typeof(SwitchPlatfomStep),
            typeof(BuildPlayerStep),
            typeof(CopyAdditionallyProvidedFilesStep),
            typeof(LinuxProduceArtifactStep)
        };

        protected override BoolResult OnCanRun(RunContext context)
        {
            var artifact = context.GetBuildArtifact<LinuxArtifact>();
            if (artifact == null)
            {
                return BoolResult.False($"Could not retrieve build artifact '{nameof(LinuxArtifact)}'.");
            }

            if (artifact.OutputTargetFile == null)
            {
                return BoolResult.False($"{nameof(LinuxArtifact.OutputTargetFile)} is null.");
            }

            if (!File.Exists(artifact.OutputTargetFile.FullName))
            {
                return BoolResult.False($"Output target file '{artifact.OutputTargetFile.FullName}' not found.");
            }

            return BoolResult.True();
        }

        protected override RunResult OnRun(RunContext context)
        {
            return LinuxRunInstance.Create(context);
        }

        protected override void PrepareContext(BuildContext context)
        {
            base.PrepareContext(context);
            var classicData = context.GetValue<ClassicSharedData>();
            classicData.StreamingAssetsDirectory = $"{context.GetOutputBuildDirectory()}/{context.GetComponentOrDefault<GeneralSettings>().ProductName}_Data/StreamingAssets";
        }
    }
}
