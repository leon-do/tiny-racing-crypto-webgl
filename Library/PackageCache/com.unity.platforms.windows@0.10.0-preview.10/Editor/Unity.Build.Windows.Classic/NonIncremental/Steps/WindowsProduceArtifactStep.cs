using System.IO;
using BuildReport = UnityEditor.Build.Reporting.BuildReport;

namespace Unity.Build.Windows.Classic
{
    [BuildStep(Description = "Producing Windows Artifacts")]
    sealed class WindowsProduceArtifactStep : BuildStepBase
    {
        public override BuildResult Run(BuildContext context)
        {
            var report = context.GetValue<BuildReport>();
            if (report == null)
            {
                return context.Failure($"Could not retrieve {nameof(BuildReport)} from build context.");
            }

            var artifact = context.GetOrCreateBuildArtifact<WindowsArtifact>();
            artifact.OutputTargetFile = new FileInfo(report.summary.outputPath);
            return context.Success();
        }
    }
}
