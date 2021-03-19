using System;
using System.Diagnostics;
using System.IO;
using Unity.Build.Desktop.DotsRuntime;
using Unity.Build.DotsRuntime;
using Unity.Build.Internals;
using UnityEngine;

namespace Unity.Build.Linux.DotsRuntime
{
    public abstract class LinuxBuildTarget : BuildTarget
    {
        protected static Texture2D s_Icon = LoadIcon("Icons", "BuildSettings.Standalone");

        public override bool CanBuild => UnityEngine.Application.platform == UnityEngine.RuntimePlatform.LinuxEditor;
        public override string UnityPlatformName => nameof(UnityEditor.BuildTarget.StandaloneLinux64);
        public override Texture2D Icon => s_Icon;
    }

    abstract class DotNetLinuxBuildTargetBase : LinuxBuildTarget
    {
        public override string ExecutableExtension => ".exe";
        public override bool UsesIL2CPP => false;

        public override bool Run(FileInfo buildTarget)
        {
            var startInfo = new ProcessStartInfo();
            startInfo.Arguments = $"\"{buildTarget.FullName.Trim('\"')}\"";
            startInfo.FileName = Path.GetFullPath(Path.Combine(UnityEditor.EditorApplication.applicationContentsPath, "MonoBleedingEdge", "bin", "mono"));
            startInfo.WorkingDirectory = buildTarget.Directory.FullName;
            if (!startInfo.EnvironmentVariables.ContainsKey("LD_LIBRARY_PATH"))
                startInfo.EnvironmentVariables.Add("LD_LIBRARY_PATH", ".");

            return new DesktopRun().RunOnThread(startInfo);
        }

        internal override ShellProcessOutput RunTestMode(string exeName, string workingDirPath, int timeout)
        {
            var shellArgs = new ShellProcessArguments
            {
                Executable = Path.GetFullPath(Path.Combine(UnityEditor.EditorApplication.applicationContentsPath, "MonoBleedingEdge", "bin", "mono")),
                Arguments = new[] { $"\"{workingDirPath}/{exeName}{ExecutableExtension}\"" },
            };

            return DesktopRun.RunTestMode(shellArgs, workingDirPath, timeout);
        }
    }

    class DotNetTinyLinuxBuildTarget : DotNetLinuxBuildTargetBase
    {
#if UNITY_EDITOR_LINUX
        protected override bool IsDefaultBuildTarget => true;
#endif

        public override string DisplayName => "Linux .NET - Tiny";
        public override string BeeTargetName => "linux-dotnet";
        public override Type[] DefaultComponents { get; }
        public override string DefaultAssetFileName => "Linux-DotNet";
        public override bool ShouldCreateBuildTargetByDefault => true;
    }

    class DotNetStandard20LinuxBuildTarget : DotNetLinuxBuildTargetBase
    {
        public override string DisplayName => "Linux .NET - .NET Standard 2.0";
        public override string BeeTargetName => "linux-dotnet-ns20";
    }

    class IL2CPPLinuxBuildTarget : LinuxBuildTarget
    {
        public override string DisplayName => "Linux IL2CPP - Tiny";
        public override string BeeTargetName => "linux-il2cpp";
        public override string ExecutableExtension => string.Empty;
        public override bool UsesIL2CPP => true;

        public override bool Run(FileInfo buildTarget)
        {
            var startInfo = new ProcessStartInfo();
            startInfo.FileName = buildTarget.FullName.Trim('.');
            startInfo.WorkingDirectory = buildTarget.Directory.FullName;
            if (!startInfo.EnvironmentVariables.ContainsKey("LD_LIBRARY_PATH"))
                startInfo.EnvironmentVariables.Add("LD_LIBRARY_PATH", ".");

            return new DesktopRun().RunOnThread(startInfo);
        }

        internal override ShellProcessOutput RunTestMode(string exeName, string workingDirPath, int timeout)
        {
            var shellArgs = new ShellProcessArguments
            {
                Executable = $"{workingDirPath}/{exeName}{ExecutableExtension}",
                Arguments = new string[] { },
            };

            return DesktopRun.RunTestMode(shellArgs, workingDirPath, timeout);
        }
    }
}
