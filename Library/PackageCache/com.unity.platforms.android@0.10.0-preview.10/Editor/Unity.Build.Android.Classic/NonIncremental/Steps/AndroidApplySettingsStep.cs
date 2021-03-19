using System;
using Unity.Build.Common;
using Unity.Build.Classic;
using UnityEditor;

namespace Unity.Build.Android.Classic
{
    sealed class AndroidApplySettingsStep : BuildStepBase
    {
        public override Type[] UsedComponents { get; } =
        {
            typeof(AndroidExportSettings),
            typeof(ClassicBuildProfile),
            typeof(AndroidArchitectures),
            typeof(AndroidAPILevels),
            typeof(ClassicScriptingSettings),
            typeof(ApplicationIdentifier)
        };

        public override BuildResult Run(BuildContext context)
        {
            var architectures = context.GetComponentOrDefault<AndroidArchitectures>().Architectures;
            var apiLevels = context.GetComponentOrDefault<AndroidAPILevels>();
            var profile = context.GetComponentOrDefault<ClassicBuildProfile>();
            switch (profile.Configuration)
            {
                case BuildType.Debug:
                    EditorUserBuildSettings.androidBuildType = AndroidBuildType.Debug;
                    break;
                case BuildType.Develop:
                    EditorUserBuildSettings.androidBuildType = AndroidBuildType.Development;
                    break;
                case BuildType.Release:
                    EditorUserBuildSettings.androidBuildType = AndroidBuildType.Release;
                    break;
            }
            // Note: We always export a project, since we need to modify gradle project contents
            EditorUserBuildSettings.exportAsGoogleAndroidProject = true;

            // Unset ARM64 if we're targeting Mono
            var scriptingSettings = context.GetComponentOrDefault<ClassicScriptingSettings>();
            if (scriptingSettings.ScriptingBackend == ScriptingImplementation.Mono2x)
                architectures &= ~AndroidArchitecture.ARM64;

            PlayerSettings.Android.targetArchitectures = (UnityEditor.AndroidArchitecture)architectures;
            PlayerSettings.Android.minSdkVersion = (UnityEditor.AndroidSdkVersions)apiLevels.MinAPILevel;
            PlayerSettings.Android.targetSdkVersion = (UnityEditor.AndroidSdkVersions)apiLevels.TargetAPILevel;

            var applicationIdentifier = context.GetComponentOrDefault<ApplicationIdentifier>();
            PlayerSettings.SetApplicationIdentifier(BuildTargetGroup.Android, applicationIdentifier.PackageName);

            return context.Success();
        }
    }
}
