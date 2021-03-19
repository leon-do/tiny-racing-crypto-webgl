using System;
using System.IO;
using System.Linq;
using Unity.Build.Common;
using Unity.Build.DotsRuntime;
using Unity.Build.Internals;
using UnityEngine;

namespace Unity.Build.iOS.DotsRuntime
{
    public class iOSBuildTarget : BuildTarget
    {
        protected static readonly Texture2D s_Icon = LoadIcon("Icons", "BuildSettings.iPhone");

        public override bool CanBuild => UnityEngine.Application.platform == UnityEngine.RuntimePlatform.OSXEditor;
        public override bool CanRun => !ExportProject && TargetSettings?.SdkVersion == iOSSdkVersion.DeviceSDK;
        public override string DisplayName => "iOS";
        public override string BeeTargetName => "ios";
        public override string ExecutableExtension => ExportProject ? "" : ".app";
        public override string UnityPlatformName => nameof(UnityEditor.BuildTarget.iOS);
        public override bool UsesIL2CPP => true;
        public override Texture2D Icon => s_Icon;

        public override Type[] UsedComponents { get; } =
        {
            typeof(GeneralSettings),
            typeof(ApplicationIdentifier),
            typeof(iOSBuildNumber),
            typeof(iOSSigningSettings),
            typeof(iOSExportProject),
            typeof(iOSTargetSettings),
            typeof(ScreenOrientations),
            typeof(iOSIcons),
            typeof(ARKitSettings)
        };

        public override Type[] DefaultComponents { get; } =
        {
            typeof(ScreenOrientations),
            typeof(ApplicationIdentifier),
            typeof(iOSExportProject),
        };

        public override bool ShouldCreateBuildTargetByDefault => true;
        public override string DefaultAssetFileName => "iOS";

        ApplicationIdentifier Identifier { get; set; }
        iOSTargetSettings TargetSettings { get; set; }
        bool ExportProject { get; set; }

        public override bool Run(FileInfo buildTarget)
        {
            try
            {
                var runTargets = new Pram().Discover(new[] { "appledevice" });

                // if any devices were found, only pick first
                if (runTargets.Any())
                    runTargets = new[] { runTargets.First() };

                if (!runTargets.Any())
                    throw new Exception("No iOS devices available");

                var applicationId = Identifier?.PackageName;
                foreach (var device in runTargets)
                {
                    UnityEditor.EditorUtility.DisplayProgressBar("Installing Application", $"Installing {applicationId} to {device.DisplayName}", 0.2f);
                    device.Deploy(applicationId, buildTarget.FullName);

                    UnityEditor.EditorUtility.DisplayProgressBar("Starting Application", $"Starting {applicationId} on {device.DisplayName}", 0.8f);
                    device.ForceStop(applicationId);
                    device.Start(applicationId);
                }
            }
            catch (Exception ex)
            {
                UnityEngine.Debug.LogError(ex.ToString());
                return false;
            }
            return true;
        }

        /// <summary>
        ///     iOS deploy is required in order to install and launch the app in test mode
        ///     to install it simply run
        ///     brew install ios-deploy
        ///     https://github.com/ios-control/ios-deploy
        /// </summary>
        private const string iOSDeployFolder = "/usr/local/Cellar/ios-deploy";

        private static string FindIOSDeploy()
        {
            var shellArgs = new ShellProcessArguments
            {
                Executable = "ls",
                Arguments = new[]
                {
                    iOSDeployFolder
                },
                ThrowOnError = false
            };
            var output = ShellProcess.Run(shellArgs);

            var versionStr = "0.0.0";
            if (output.ExitCode == 0)
            {
                var versions = output.FullOutput.Split('\n');
                foreach (var v in versions)
                {
                    if (v.Length > 0 && (new System.Version(v)).CompareTo(new System.Version(versionStr)) > 0)
                    {
                        versionStr = v;
                    }
                }
            }
            if (versionStr == "0.0.0")
            {
                throw new Exception($"iOS deploy is required in order to install and launch the app, to install it simply run \"brew install ios-deploy\"");
            }
            return $"{iOSDeployFolder}/{versionStr}/bin/ios-deploy";
        }

        internal override ShellProcessOutput RunTestMode(string exeName, string workingDirPath, int timeout)
        {
            var app = $"{workingDirPath}/{exeName}{ExecutableExtension}";
            if (!Directory.Exists(app))
            {
                throw new Exception($"Couldn't find iOS app at: {app} ");
            }
            using (var progress = new BuildProgress("Running the iOS app", "Please wait..."))
            {
                var shellArgs = new ShellProcessArguments
                {
                    Executable = FindIOSDeploy(),
                    Arguments = new[]
                    {
                        "--noninteractive",
                        "--debug",
                        "--uninstall",
                        "--bundle",
                        app
                    },
                    WorkingDirectory = new DirectoryInfo(workingDirPath)
                };
                if (timeout > 0)
                {
                    shellArgs.MaxIdleTimeInMilliseconds = timeout;
                    shellArgs.MaxIdleKillIsAnError = false;
                }

                return ShellProcess.Run(shellArgs);
            }
        }

        public override void WriteBuildConfiguration(BuildContext context, string path)
        {
            if (context.HasComponent<iOSSigningSettings>())
            {
                var signingSettings = context.GetComponentOrDefault<iOSSigningSettings>();
                signingSettings.UpdateCodeSignIdentityValue();
                context.SetComponent(signingSettings);
            }
            Identifier = context.GetComponentOrDefault<ApplicationIdentifier>();
            TargetSettings = context.GetComponentOrDefault<iOSTargetSettings>();
            ExportProject = context.HasComponent<iOSExportProject>();
            base.WriteBuildConfiguration(context, path);
        }
    }
}
