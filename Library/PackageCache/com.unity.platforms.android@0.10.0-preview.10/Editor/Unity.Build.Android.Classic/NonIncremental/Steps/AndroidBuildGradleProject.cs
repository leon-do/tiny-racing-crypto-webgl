using System.Diagnostics;
using System.IO;
using System.Text;
using Unity.Build.Classic;
using Unity.Build.Classic.Private;
using Unity.Build.Common;
using UnityEngine;

#if UNITY_ANDROID
using UnityEditor.Android;
#endif

namespace Unity.Build.Android.Classic
{
    sealed class AndroidBuildGradleProject : BuildStepBase
    {
        public override bool IsEnabled(BuildContext context)
        {
            return context.GetComponentOrDefault<AndroidExportSettings>().ExportProject == false &&
                 context.HasComponent<InstallInBuildFolder>() == false;
        }

        public override BuildResult Run(BuildContext context)
        {
            var exportSettings = context.GetComponentOrDefault<AndroidExportSettings>();
            var isAppBundle = exportSettings.TargetType == AndroidTargetType.AndroidAppBundle;
            var classicData = context.GetValue<ClassicSharedData>();
            var nonIncrementalClassicData = context.GetValue<NonIncrementalClassicSharedData>();
            var gradleJarFile = GradleTools.GetGradleLauncherJar(classicData.BuildToolsDirectory);
            var gradleTask = GradleTools.GetGradleTask(classicData.DevelopmentPlayer, isAppBundle);
            var gradleOuputDirectory = Path.Combine(nonIncrementalClassicData.TemporaryDirectory, "gradleOut");
            var gradleFile = Path.Combine(gradleOuputDirectory, "build.gradle");
#if UNITY_ANDROID
            var jdkPath = AndroidExternalToolsSettings.jdkRootPath;
#else
            var jdkPath = "";
#endif

            var fileName = Path.Combine(jdkPath, "bin", "java" + (Application.platform == RuntimePlatform.WindowsEditor ? ".exe" : ""));
            var args = string.Join(" ",
                new[]
                {
                    "-classpath",
                    $"\"{gradleJarFile}\"",
                    "org.gradle.launcher.GradleMain",
                    "-b",
                     $"\"{gradleFile}\"",
                    $"\"{gradleTask}\""
                });


            Process process = new Process();
            process.StartInfo.FileName = fileName;
            process.StartInfo.Arguments = args;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.CreateNoWindow = true;
            var output = new StringBuilder();
            process.OutputDataReceived += new DataReceivedEventHandler((sender, e) =>
            {
                if (!string.IsNullOrEmpty(e.Data))
                {
                    output.AppendLine(e.Data);
                }
            });

            var error = new StringBuilder();
            process.ErrorDataReceived += new DataReceivedEventHandler((sender, e) =>
            {
                if (!string.IsNullOrEmpty(e.Data))
                {
                    error.AppendLine(e.Data);
                }
            });

            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            process.WaitForExit();

            BuildResult result;
            if (process.ExitCode == 0)
            {
                var outputPath = Path.Combine(gradleOuputDirectory, GradleTools.GetGradleOutputPath(classicData.DevelopmentPlayer, isAppBundle));
                var finalPath = Path.Combine(context.GetOutputBuildDirectory(), context.GetComponentOrDefault<GeneralSettings>().ProductName + Path.GetExtension(outputPath));
                File.Copy(outputPath, finalPath, true);

                var artifact = context.GetOrCreateBuildArtifact<AndroidArtifact>();
                artifact.OutputTargetFile = new FileInfo(finalPath);

                result = context.Success();
            }
            else
            {
                result = context.Failure(output.ToString() + error.ToString());
            }

            process.Close();

            return result;
        }
    }
}
