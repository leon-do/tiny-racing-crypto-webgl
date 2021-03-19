
using System.IO;
using Unity.Build.Classic.Private;

namespace Unity.Build.Android.Classic
{
    class AndroidNonIncrementalData
    {
        private string m_GradleOutputDirectory;

        internal AndroidNonIncrementalData(BuildContext buildContext)
        {
            // We don't want to add subdirectory if we're exporting a project
            if (buildContext.GetComponentOrDefault<AndroidExportSettings>().ExportProject)
                m_GradleOutputDirectory = buildContext.GetOutputBuildDirectory();
            else
            {
                var nonIncrementalClassicData = buildContext.GetValue<NonIncrementalClassicSharedData>();
                m_GradleOutputDirectory = Path.Combine(nonIncrementalClassicData.TemporaryDirectory, "gradleOut");
            }
        }

        internal string GradleOuputDirectory => m_GradleOutputDirectory;
    }
}
