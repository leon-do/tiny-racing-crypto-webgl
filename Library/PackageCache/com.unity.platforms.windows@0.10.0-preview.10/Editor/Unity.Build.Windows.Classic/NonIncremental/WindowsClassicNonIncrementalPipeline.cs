using System.IO;
using Unity.Build.Classic.Private;
using Unity.Build.Common;

namespace Unity.Build.Windows.Classic
{
    sealed class WindowsClassicNonIncrementalPipeline : ClassicNonIncrementalPipelineBase
    {
        public override Platform Platform => Platform.Windows;

        public override BuildStepCollection BuildSteps { get; } = new[]
        {
            typeof(SaveScenesAndAssetsStep),
            typeof(ApplyUnitySettingsStep),
            typeof(SwitchPlatfomStep),
            typeof(BuildPlayerStep),
            typeof(CopyAdditionallyProvidedFilesStep),
            typeof(WindowsProduceArtifactStep)
        };

        protected override BoolResult OnCanRun(RunContext context)
        {
            var artifact = context.GetBuildArtifact<WindowsArtifact>();
            if (artifact == null)
            {
                return BoolResult.False($"Could not retrieve build artifact '{nameof(WindowsArtifact)}'.");
            }

            if (artifact.OutputTargetFile == null)
            {
                return BoolResult.False($"{nameof(WindowsArtifact.OutputTargetFile)} is null.");
            }

            if (!File.Exists(artifact.OutputTargetFile.FullName))
            {
                return BoolResult.False($"Output target file '{artifact.OutputTargetFile.FullName}' not found.");
            }

            return BoolResult.True();
        }

        protected override RunResult OnRun(RunContext context)
        {
            return WindowsRunInstance.Create(context);
        }

        protected override void PrepareContext(BuildContext context)
        {
            base.PrepareContext(context);
            var classicData = context.GetValue<ClassicSharedData>();
            classicData.StreamingAssetsDirectory = $"{context.GetOutputBuildDirectory()}/{context.GetComponentOrDefault<GeneralSettings>().ProductName}_Data/StreamingAssets";
        }
    }
}
