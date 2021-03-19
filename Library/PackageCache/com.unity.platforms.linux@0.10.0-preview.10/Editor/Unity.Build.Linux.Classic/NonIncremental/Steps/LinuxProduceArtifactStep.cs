using System.IO;
using BuildReport = UnityEditor.Build.Reporting.BuildReport;

namespace Unity.Build.Linux.Classic
{
    [BuildStep(Description = "Producing Linux Artifacts")]
    sealed class LinuxProduceArtifactStep : BuildStepBase
    {
        public override BuildResult Run(BuildContext context)
        {
            var report = context.GetValue<BuildReport>();
            if (report == null)
            {
                return context.Failure($"Could not retrieve {nameof(BuildReport)} from build context.");
            }

            var artifact = context.GetOrCreateValue<LinuxArtifact>();
            artifact.OutputTargetFile = new FileInfo(report.summary.outputPath);
            return context.Success();
        }
    }
}
