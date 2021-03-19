using System;
using System.IO;
using Unity.Build.Common;
using Unity.Build.DotsRuntime;
using Unity.Build.Internals;
using UnityEngine;
using BuildTarget = Unity.Build.DotsRuntime.BuildTarget;

namespace Unity.Build.Android.DotsRuntime
{
    public class AndroidBuildTarget : BuildTarget
    {
        protected static readonly Texture2D s_Icon = LoadIcon("Icons", "BuildSettings.Android");

        public override string DisplayName => "Android";
        public override string BeeTargetName => "android_armv7";
        public override bool CanBuild => true;
        public override bool CanRun => ExportSettings?.ExportProject != true;
        public override string ExecutableExtension => ExportSettings?.ExportProject == true ? "" :
                                                      (ExportSettings?.TargetType == AndroidTargetType.AndroidAppBundle ? ".aab" : ".apk");
        public override string UnityPlatformName => nameof(UnityEditor.BuildTarget.Android);
        public override bool UsesIL2CPP => true;
        public override Texture2D Icon => s_Icon;

        public override Type[] UsedComponents { get; } =
        {
            typeof(ApplicationIdentifier),
            typeof(AndroidBundleVersionCode),
            typeof(ScreenOrientations),
            typeof(AndroidAPILevels),
            typeof(AndroidArchitectures),
            typeof(AndroidExternalTools),
            typeof(AndroidExportSettings),
            typeof(AndroidInstallLocation),
            typeof(AndroidRenderOutsideSafeArea),
            typeof(AndroidAspectRatio),
            typeof(AndroidIcons),
            typeof(AndroidKeystore),
            typeof(ARCoreSettings)
        };

        public override Type[] DefaultComponents { get; } =
        {
            typeof(ScreenOrientations),
            typeof(ApplicationIdentifier),
            typeof(AndroidArchitectures)
        };

        public override string DefaultAssetFileName => "Android";
        public override bool ShouldCreateBuildTargetByDefault => true;
        string PackageName { get; set; }
        AndroidExternalTools ExternalTools { get; set; }
        AndroidExportSettings ExportSettings { get; set; }
        bool UseKeystore { get; set; }
        AndroidKeystore Keystore { get; set; }

        string m_BundleToolJar;
        string BundleToolJar
        {
            get
            {
                if (!string.IsNullOrEmpty(m_BundleToolJar))
                {
                    return m_BundleToolJar;
                }
                //TODO revisit this later, probably use AndroidBuildContext to get bundletool path
                var androidEngine = UnityEditor.BuildPipeline.GetPlaybackEngineDirectory(UnityEditor.BuildTarget.Android, UnityEditor.BuildOptions.None);
                var androidTools = Path.Combine(androidEngine, "Tools");
                var bundleToolFiles = Directory.GetFiles(androidTools, "bundletool-all-*.jar");
                if (bundleToolFiles.Length != 1)
                    throw new Exception($"Failed to find bundletool in {androidTools}");
                m_BundleToolJar = bundleToolFiles[0];
                return m_BundleToolJar;
            }
        }

        private ShellProcessOutput UninstallApp(string apkName, string buildDir)
        {
            // checking that app is already installed
            var result = ShellProcess.Run(new ShellProcessArguments()
            {
                ThrowOnError = false,
                Executable = AdbPath,
                Arguments = new string[] { "shell", "pm", "list", "packages", PackageName },
                WorkingDirectory = new DirectoryInfo(buildDir)
            });
            if (result.FullOutput.Contains(PackageName))
            {
                // uninstall previous version, it may be signed with different key, so re-installing is not possible
                result = ShellProcess.Run(new ShellProcessArguments()
                {
                    ThrowOnError = false,
                    Executable = AdbPath,
                    Arguments = new string[] { "uninstall", PackageName },
                    WorkingDirectory = new DirectoryInfo(buildDir)
                });
            }
            return result;
        }

        private ShellProcessOutput InstallApk(string apkName, string buildDir)
        {
            return ShellProcess.Run(new ShellProcessArguments()
            {
                ThrowOnError = false,
                Executable = AdbPath,
                Arguments = new string[] { "install", "\"" + apkName + "\"" },
                WorkingDirectory = new DirectoryInfo(buildDir)
            });
        }

        static string GetApksName(string buildDir)
        {
            return Path.Combine(buildDir, "bundle.apks");
        }

        private ShellProcessOutput BuildApks(string aabName, string buildDir)
        {
            var apksName = GetApksName(buildDir);
            //TODO check for mutliple device installing

            string keystorePassFile = null;
            string keyaliasPassFile = null;
            if (UseKeystore)
            {
                keystorePassFile = Path.Combine(buildDir, "keystore.pass");
                keyaliasPassFile = Path.Combine(buildDir, "keyalias.pass");
                File.WriteAllText(keystorePassFile, Keystore.KeystorePass);
                File.WriteAllText(keyaliasPassFile, Keystore.KeyaliasPass);
            }
            var result = ShellProcess.Run(new ShellProcessArguments()
            {
                ThrowOnError = false,
                Executable = JavaPath,
                Arguments = new string[] {
                    "-jar",
                    $"\"{BundleToolJar}\"",
                    "build-apks",
                    $"--bundle=\"{aabName}\"",
                    $"--output=\"{apksName}\"",
                    "--overwrite",
                    (UseKeystore ? $"--ks=\"{Keystore.KeystoreFullPath}\" --ks-pass=file:\"{keystorePassFile}\" --ks-key-alias=\"{Keystore.KeyaliasName}\" --key-pass=file:\"{keyaliasPassFile}\"" : "")
                },
                WorkingDirectory = new DirectoryInfo(buildDir)
            });
            if (UseKeystore)
            {
                File.Delete(keystorePassFile);
                File.Delete(keyaliasPassFile);
            }
            return result;
        }

        private ShellProcessOutput InstallApks(string buildDir)
        {
            var apksName = GetApksName(buildDir);
            return ShellProcess.Run(new ShellProcessArguments()
            {
                ThrowOnError = false,
                Executable = JavaPath,
                Arguments = new string[] {
                    "-jar",
                    $"\"{BundleToolJar}\"",
                    "install-apks",
                    $"--apks=\"{apksName}\"",
                    $"--adb=\"{AdbPath}\""
                },
                WorkingDirectory = new DirectoryInfo(buildDir)
            });
        }

        private ShellProcessOutput LaunchApp(string buildDir)
        {
            return ShellProcess.Run(new ShellProcessArguments()
            {
                ThrowOnError = false,
                Executable = AdbPath,
                Arguments = new string[] {
                        "shell", "am", "start",
                        "-a", "android.intent.action.MAIN",
                        "-c", "android.intent.category.LAUNCHER",
                        "-f", "0x10200000",
                        "-S",
                        "-n", $"{PackageName}/com.unity3d.tinyplayer.UnityTinyActivity"
                },
                WorkingDirectory = new DirectoryInfo(buildDir)
            });
        }

        public override bool Run(FileInfo buildTarget)
        {
            var buildDir = buildTarget.Directory.FullName;

            var result = UninstallApp(buildTarget.FullName, buildDir);
            if (ExportSettings?.TargetType == AndroidTargetType.AndroidAppBundle)
            {
                result = BuildApks(buildTarget.FullName, buildDir);
                // bundletool might write to stderr even if there are no errors
                if (result.ExitCode != 0)
                {
                    throw new Exception($"Cannot build APKS : {result.FullOutput}");
                }
                result = InstallApks(buildDir);
                if (result.ExitCode != 0)
                {
                    throw new Exception($"Cannot install APKS : {result.FullOutput}");
                }
            }
            else
            {
                result = InstallApk(buildTarget.FullName, buildDir);
                if (!result.FullOutput.Contains("Success"))
                {
                    throw new Exception($"Cannot install APK : {result.FullOutput}");
                }
            }
            result = LaunchApp(buildDir);
            // killing adb to unlock build folder
            ShellProcess.Run(new ShellProcessArguments()
            {
                ThrowOnError = false,
                Executable = AdbPath,
                Arguments = new string[] { "kill-server" }
            });
            if (result.Succeeded)
            {
                return true;
            }
            else
            {
                throw new Exception($"Cannot launch APK : {result.FullOutput}");
            }
        }

        internal override ShellProcessOutput RunTestMode(string exeName, string workingDirPath, int timeout)
        {
            var executable = $"{workingDirPath}/{exeName}{ExecutableExtension}";
            var output = UninstallApp(executable, workingDirPath);
            if (ExportSettings?.TargetType == AndroidTargetType.AndroidAppBundle)
            {
                output = BuildApks(executable, workingDirPath);
                // bundletool might write to stderr even if there are no errors
                if (output.ExitCode != 0)
                {
                    return output;
                }
                output = InstallApks(workingDirPath);
                if (output.ExitCode != 0)
                {
                    return output;
                }
            }
            else
            {
                output = InstallApk(executable, workingDirPath);
                if (!output.FullOutput.Contains("Success"))
                {
                    return output;
                }
            }

            // clear logcat
            ShellProcess.Run(new ShellProcessArguments()
            {
                ThrowOnError = false,
                Executable = AdbPath,
                Arguments = new string[] {
                        "logcat", "-c"
                },
                WorkingDirectory = new DirectoryInfo(workingDirPath)
            });

            output = LaunchApp(workingDirPath);

            System.Threading.Thread.Sleep(timeout == 0 ? 2000 : timeout); // to kill process anyway,
                                                                          // should be rewritten to support tests which quits after execution

            // killing on timeout
            ShellProcess.Run(new ShellProcessArguments()
            {
                ThrowOnError = false,
                Executable = AdbPath,
                Arguments = new string[] {
                        "shell", "am", "force-stop",
                        PackageName
                },
                WorkingDirectory = new DirectoryInfo(workingDirPath)
            });

            // get logcat
            output = ShellProcess.Run(new ShellProcessArguments()
            {
                ThrowOnError = false,
                Executable = AdbPath,
                Arguments = new string[] {
                        "logcat", "-d"
                },
                WorkingDirectory = new DirectoryInfo(workingDirPath)
            });
            if (timeout == 0) // non-sample test, TODO invent something better
            {
                output.Succeeded = output.FullOutput.Contains("Test suite: SUCCESS");
            }
            return output;
        }

        public override void WriteBuildConfiguration(BuildContext context, string path)
        {
            base.WriteBuildConfiguration(context, path);
            var appId = context.GetComponentOrDefault<ApplicationIdentifier>();
            PackageName = appId.PackageName;
            ExternalTools = context.GetComponentOrDefault<AndroidExternalTools>();
            ExportSettings = context.GetComponentOrDefault<AndroidExportSettings>();
            UseKeystore = context.HasComponent<AndroidKeystore>();
            Keystore = context.GetComponentOrDefault<AndroidKeystore>();
        }

        private static string AdbName
        {
            get
            {
#if UNITY_EDITOR_WIN
                return "adb.exe";
#elif UNITY_EDITOR_OSX
                return "adb";
#else
                return "adb";
#endif
            }
        }

        private static string JavaName
        {
            get
            {
#if UNITY_EDITOR_WIN
                return "java.exe";
#elif UNITY_EDITOR_OSX
                return "java";
#else
                return "java";
#endif
            }
        }

        private string AdbPath
        {
            get
            {
                if (string.IsNullOrEmpty(ExternalTools.SdkPath))
                {
                    throw new Exception("ADB is not found");
                }
                return Path.Combine(ExternalTools.SdkPath, "platform-tools", AdbName);
            }
        }

        private string JavaPath
        {
            get
            {
                if (string.IsNullOrEmpty(ExternalTools.JavaPath))
                {
                    throw new Exception("JDK is not found");
                }
                return Path.Combine(ExternalTools.JavaPath, "bin", JavaName);
            }
        }
    }
}
