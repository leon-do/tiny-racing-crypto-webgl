using System;
using System.Diagnostics;
using System.IO;
using Unity.Build.Desktop.DotsRuntime;
using Unity.Build.DotsRuntime;
using Unity.Build.Internals;
using UnityEngine;

namespace Unity.Build.MacOS.DotsRuntime
{
    public abstract class MacOSBuildTarget : BuildTarget
    {
        protected static Texture2D s_Icon = LoadIcon("Icons", "BuildSettings.Standalone");

        public override bool CanBuild => UnityEngine.Application.platform == UnityEngine.RuntimePlatform.OSXEditor;
        public override string UnityPlatformName => nameof(UnityEditor.BuildTarget.StandaloneOSX);
        public override Texture2D Icon => s_Icon;
    }

    abstract class DotNetMacOSBuildTargetBase : MacOSBuildTarget
    {
        public override string ExecutableExtension => ".exe";
        public override bool UsesIL2CPP => false;

        public override bool Run(FileInfo buildTarget)
        {
            var startInfo = new ProcessStartInfo();
            startInfo.Arguments = $"\"{buildTarget.FullName.Trim('\"')}\"";
            startInfo.FileName = Path.GetFullPath(Path.Combine(UnityEditor.EditorApplication.applicationContentsPath, "MonoBleedingEdge", "bin", "mono"));
            startInfo.WorkingDirectory = buildTarget.Directory.FullName;

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

    class DotNetTinyMacOSBuildTarget : DotNetMacOSBuildTargetBase
    {
#if UNITY_EDITOR_OSX
        protected override bool IsDefaultBuildTarget => true;
#endif

        public override string DisplayName => "macOS .NET";
        public override string BeeTargetName => "macos-dotnet";
        public override Type[] DefaultComponents { get; }
        public override string DefaultAssetFileName => "Mac-DotNet";
        public override bool ShouldCreateBuildTargetByDefault => true;
    }

    class DotNetStandard20MacOSBuildTarget : DotNetMacOSBuildTargetBase
    {
        public override string DisplayName => "macOS .NET - .NET Standard 2.0";
        public override string BeeTargetName => "macos-dotnet-ns20";
    }

    class IL2CPPMacOSBuildTarget : MacOSBuildTarget
    {
        public override string DisplayName => "macOS IL2CPP - Tiny";
        public override string BeeTargetName => "macos-il2cpp";
        public override string ExecutableExtension => string.Empty;
        public override bool UsesIL2CPP => true;

        public override bool Run(FileInfo buildTarget)
        {
            var startInfo = new ProcessStartInfo();
            startInfo.FileName = buildTarget.FullName.Trim('.');
            startInfo.WorkingDirectory = buildTarget.Directory.FullName;

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
