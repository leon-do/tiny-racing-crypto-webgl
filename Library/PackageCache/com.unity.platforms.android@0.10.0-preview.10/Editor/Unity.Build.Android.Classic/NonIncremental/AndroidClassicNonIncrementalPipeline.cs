using System;
using System.IO;
using Unity.Build;
using Unity.Build.Classic;
using Unity.Build.Classic.Private;
using Unity.Build.Common;
using UnityEditor;

#if UNITY_ANDROID
using UnityEditor.Android;
#endif

namespace Unity.Build.Android.Classic
{
    sealed class AndroidClassicNonIncrementalPipeline : ClassicNonIncrementalPipelineBase
    {
        public override Platform Platform => Platform.Android;

        public override BuildStepCollection BuildSteps { get; } = new[]
        {
            typeof(SaveScenesAndAssetsStep),
            typeof(ApplyUnitySettingsStep),
            typeof(AndroidApplySettingsStep), // Note: Must go after ApplyUnitySettingsStep !!
            typeof(SwitchPlatfomStep),
            typeof(AndroidCalculateLocationPathStep),
            // Note: BuildPlayerStep always produces a gradle project
            typeof(BuildPlayerStep),
            typeof(CopyAdditionallyProvidedFilesStep),
            typeof(AndroidBuildGradleProject)
        };

        protected override void PrepareContext(BuildContext context)
        {
            base.PrepareContext(context);
            var androidNonIncrementalData = new AndroidNonIncrementalData(context);
            context.SetValue(androidNonIncrementalData);

            var classicData = context.GetValue<ClassicSharedData>();
            classicData.StreamingAssetsDirectory = Path.Combine(androidNonIncrementalData.GradleOuputDirectory, "unityLibrary/src/main/assets");

            // TODO: External\Android\NonRedistributable\ndk\builds\platforms doesn't contain android-16, which is used as default in Burst
            if (Unsupported.IsSourceBuild())
            {
#if UNITY_2019_3_OR_NEWER
                Environment.SetEnvironmentVariable("BURST_ANDROID_MIN_API_LEVEL", $"{21}");
#endif
            }
        }

        protected override BoolResult OnCanRun(RunContext context)
        {
#if UNITY_ANDROID
            var artifact = context.GetBuildArtifact<AndroidArtifact>();
            if (artifact == null)
            {
                return BoolResult.False($"Could not retrieve build artifact '{nameof(AndroidArtifact)}'. Are you exporting a gradle project? Running gradleproject is not supported.");
            }

            if (artifact.OutputTargetFile == null)
            {
                return BoolResult.False($"{nameof(AndroidArtifact.OutputTargetFile)} is null.");
            }

            return BoolResult.True();
#else
            return BoolResult.False("Active Editor platform has to be set to Android.");
#endif
        }

        protected override RunResult OnRun(RunContext context)
        {
            AndroidClassicPipelineShared.SetupPlayerConnection(context);

#if UNITY_ANDROID
            var artifact = context.GetBuildArtifact<AndroidArtifact>();
            var fileName = artifact.OutputTargetFile.FullName;
            if (Path.GetExtension(fileName) != ".apk")
                return context.Failure($"Expected .apk in path, but got '{fileName}'.");

            var path = $"\"{Path.GetFullPath(fileName)}\"";
            var adb = ADB.GetInstance();
            try
            {
                EditorUtility.DisplayProgressBar("Installing", $"Installing {path}", 0.3f);
                adb.Run(new[] { "install", "-r", "-d", path }, $"Failed to install '{fileName}'");
            }
            catch (Exception ex)
            {
                return context.Failure(ex);
            }
            finally
            {
                EditorUtility.ClearProgressBar();
            }
            UnityEngine.Debug.Log($"{path} successfully installed.");

            var applicationIdentifier = context.GetComponentOrDefault<ApplicationIdentifier>();
            var runTarget = $"\"{applicationIdentifier.PackageName}/com.unity3d.player.UnityPlayerActivity\"";
            try
            {
                EditorUtility.DisplayProgressBar("Launching", $"Launching {runTarget}", 0.6f);
                adb.Run(new[]
                {
                    "shell", "am", "start",
                    "-a", "android.intent.action.MAIN",
                    "-c", "android.intent.category.LAUNCHER",
                    "-f", "0x10200000",
                    "-S",
                    "-n", runTarget
                }, $"Failed to launch {runTarget}");
            }
            catch (Exception ex)
            {
                return context.Failure(ex);
            }
            finally
            {
                EditorUtility.ClearProgressBar();
            }
            UnityEngine.Debug.Log($"{runTarget} successfully launched.");

            return context.Success(new AndroidRunInstance());
#else
            return context.Failure("Active Editor platform has to be set to Android.");
#endif
        }

        public override DirectoryInfo GetOutputBuildDirectory(BuildConfiguration config)
        {
            if (config.HasComponent<InstallInBuildFolder>())
            {
                var path = UnityEditor.BuildPipeline.GetPlaybackEngineDirectory(BuildTarget.Android, BuildOptions.None);
                path = Path.Combine(path, "SourceBuild", config.GetComponentOrDefault<GeneralSettings>().ProductName);
                return new DirectoryInfo(path);
            }
            else
            {
                return base.GetOutputBuildDirectory(config);
            }
        }
    }
}
