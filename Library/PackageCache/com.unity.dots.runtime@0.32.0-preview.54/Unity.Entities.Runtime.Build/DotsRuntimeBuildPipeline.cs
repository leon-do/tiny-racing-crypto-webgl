using System;
using System.IO;
using System.Linq;
using Unity.Build;
using Unity.Build.Common;
using Unity.Build.DotsRuntime;

namespace Unity.Entities.Runtime.Build
{
    sealed class DotsRuntimeBuildPipeline : DotsRuntimeBuildPipelineBase
    {
        public DotsRuntimeBuildPipeline()
        {
        }

        // @TODO: Remove this override entirely, and fix in each BuildTarget instead
        public override Type[] UsedComponents =>
            base.UsedComponents.Concat(new[]
            {
                typeof(GeneralSettings)
            }).Distinct().ToArray();

        public override BuildStepCollection BuildSteps { get; } = new[]
        {
            typeof(BuildStepExportScenes),
            typeof(BuildStepExportConfiguration),
            typeof(BuildStepGenerateBeeFiles),
            typeof(BuildStepRunBee)
        };

        protected override CleanResult OnClean(CleanContext context)
        {
            var artifacts = context.GetBuildArtifact<DotsRuntimeBuildArtifact>();
            if (artifacts == null)
                return context.Success();

            var buildDirectory = artifacts.OutputTargetFile.Directory;
            if (buildDirectory.Exists)
                buildDirectory.Delete(true);
            return context.Success();
        }

        protected override BuildResult OnBuild(BuildContext context)
        {
            return BuildSteps.Run(context);
        }

        protected override BoolResult OnCanRun(RunContext context)
        {
            if (!Target.CanRun)
            {
                return BoolResult.False("Run is not supported with current build settings");
            }

            var artifact = context.GetBuildArtifact<DotsRuntimeBuildArtifact>();
            if (artifact == null)
            {
                return BoolResult.False($"Could not retrieve build artifact '{nameof(DotsRuntimeBuildArtifact)}'.");
            }

            if (artifact.OutputTargetFile == null)
            {
                return BoolResult.False($"{nameof(DotsRuntimeBuildArtifact.OutputTargetFile)} is null.");
            }

            if (!File.Exists(artifact.OutputTargetFile.FullName) && !Directory.Exists(artifact.OutputTargetFile.FullName))
            {
                return BoolResult.False($"Output target file '{artifact.OutputTargetFile.FullName}' not found.");
            }

            if (!context.TryGetComponent<DotsRuntimeBuildProfile>(out var profile))
            {
                return BoolResult.False($"Could not retrieve component '{nameof(DotsRuntimeBuildProfile)}'.");
            }

            if (profile.Target == null)
            {
                return BoolResult.False($"{nameof(DotsRuntimeBuildProfile)} target is null.");
            }

            return BoolResult.True();
        }

        protected override RunResult OnRun(RunContext context)
        {
            var artifact = context.GetBuildArtifact<DotsRuntimeBuildArtifact>();
            var profile = context.GetComponentOrDefault<DotsRuntimeBuildProfile>();

            if (!profile.Target.Run(artifact.OutputTargetFile))
            {
                return context.Failure($"Failed to start build target {profile.Target.DisplayName} at '{artifact.OutputTargetFile.FullName}'.");
            }

            //@TODO: BuildTarget.Run should return the process, so we can store it in DotsRuntimeRunInstance
            return context.Success(new DotsRuntimeRunInstance());
        }

        public override DirectoryInfo GetOutputBuildDirectory(BuildConfiguration config)
        {
            var artifact = config.GetBuildArtifact<DotsRuntimeBuildArtifact>();
            return artifact.OutputTargetFile.Directory;
        }
    }
}
