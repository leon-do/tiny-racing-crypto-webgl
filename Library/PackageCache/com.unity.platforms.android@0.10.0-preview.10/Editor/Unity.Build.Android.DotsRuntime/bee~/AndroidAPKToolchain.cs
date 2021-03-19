using System;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using Bee.Core;
using Bee.DotNet;
using Bee.Stevedore;
using Bee.Toolchain.GNU;
using Bee.Toolchain.LLVM;
using Bee.Toolchain.Extension;
using Bee.BuildTools;
using Bee.NativeProgramSupport;
using NiceIO;

using Unity.Build.Common;
using Unity.Build.DotsRuntime;
using Unity.Build.Android;

namespace Bee.Toolchain.Android
{
    internal class AndroidApkToolchain : AndroidNdkToolchain
    {
        public override CLikeCompiler CppCompiler { get; }
        public override NativeProgramFormat DynamicLibraryFormat { get; }
        public override NativeProgramFormat ExecutableFormat { get; }

        // Build configuration
        internal class Config
        {
            public static AndroidExternalTools ExternalTools { get; private set; }
            public static GeneralSettings Settings { get; private set; }
            public static ApplicationIdentifier Identifier { get; private set; }
            public static AndroidBundleVersionCode VersionCode { get; private set; }
            public static ScreenOrientations Orientations { get; private set; }
            public static AndroidAPILevels APILevels { get; private set; }
            public static AndroidArchitectures Architectures { get; private set; }
            public static AndroidExportSettings ExportSettings { get; private set; }
            public static AndroidInstallLocation InstallLocation { get; private set; }
            public static AndroidRenderOutsideSafeArea RenderOutsideSafeArea { get; private set; }
            public static AndroidAspectRatio AspectRatio { get; private set; }
            public static AndroidIcons Icons { get; private set; }
            public static AndroidKeystore Keystore { get; private set; }
            public static ARCoreSettings ARCore { get; private set; }

            public static bool Validate()
            {
                // not android target or no required build components
                if (Architectures == null || ExternalTools == null)
                {
                    return false;
                }
                if (ExportSettings.BuildSystem != AndroidBuildSystem.Gradle)
                {
                    Console.WriteLine($"{Config.ExportSettings.BuildSystem.ToString()} is not supported yet for Tiny");
                    return false;
                }
                if ((Architectures.Architectures & AndroidArchitecture.ARMv7) == 0 && (Architectures.Architectures & AndroidArchitecture.ARM64) == 0)
                {
                    Console.WriteLine($"No valid architecture for Tiny android toolchain {Architectures.Architectures.ToString()}");
                    return false;
                }
                if (Orientations == null ||
                    (Orientations.DefaultOrientation == UIOrientation.AutoRotation &&
                    !Orientations.AllowAutoRotateToPortrait &&
                    !Orientations.AllowAutoRotateToReversePortrait &&
                    !Orientations.AllowAutoRotateToLandscape &&
                    !Orientations.AllowAutoRotateToReverseLandscape))
                {
                    Console.WriteLine("There are no allowed orientations for the application");
                    return false;
                }
                if (BuildConfiguration.HasComponent<ARCoreSettings>() && ARCore.Requirement == Requirement.Required &&
                    APILevels.MinAPILevel < AndroidSdkVersions.AndroidApiLevel24)
                {
                    Console.WriteLine($"Android Min SDK version must be at least 24 for ARCore Required apps");
                    return false;
                }
                if (String.IsNullOrEmpty(ExternalTools.NdkPath) || !(new NPath(ExternalTools.NdkPath)).DirectoryExists())
                {
                    Console.WriteLine($"Can't find Android NDK folder {ExternalTools.NdkPath}");
                    return false;
                }
                if (String.IsNullOrEmpty(ExternalTools.SdkPath) || !(new NPath(ExternalTools.SdkPath)).DirectoryExists())
                {
                    Console.WriteLine($"Can't find Android SDK folder {ExternalTools.SdkPath}");
                    return false;
                }
                if (String.IsNullOrEmpty(ExternalTools.JavaPath) || !(new NPath(ExternalTools.JavaPath)).DirectoryExists())
                {
                    Console.WriteLine($"Can't find Java SDK folder {ExternalTools.JavaPath}");
                    return false;
                }
                if (String.IsNullOrEmpty(ExternalTools.GradlePath) || !(new NPath(Config.ExternalTools.GradlePath)).DirectoryExists())
                {
                    Console.WriteLine($"Can't find Gradle folder {ExternalTools.GradlePath}");
                    return false;
                }
                return true;
            }
        }

        public static bool IsFatApk => (Config.Architectures?.Architectures & AndroidArchitecture.ARMv7) != 0 && (Config.Architectures?.Architectures & AndroidArchitecture.ARM64) != 0;
        public static bool BuildAppBundle => Config.ExportSettings?.TargetType == AndroidTargetType.AndroidAppBundle;
        public static bool ExportProject => Config.ExportSettings?.ExportProject == true;

        public static bool AllowedOrientationPortrait => Config.Orientations?.DefaultOrientation == UIOrientation.Portrait ||
                                                         (Config.Orientations?.DefaultOrientation == UIOrientation.AutoRotation &&
                                                          Config.Orientations?.AllowAutoRotateToPortrait == true);
        public static bool AllowedOrientationReversePortrait => Config.Orientations?.DefaultOrientation == UIOrientation.PortraitUpsideDown ||
                                                         (Config.Orientations?.DefaultOrientation == UIOrientation.AutoRotation &&
                                                          Config.Orientations?.AllowAutoRotateToReversePortrait == true);
        public static bool AllowedOrientationLandscape => Config.Orientations?.DefaultOrientation == UIOrientation.LandscapeRight ||
                                                         (Config.Orientations?.DefaultOrientation == UIOrientation.AutoRotation &&
                                                          Config.Orientations?.AllowAutoRotateToLandscape == true);
        public static bool AllowedOrientationReverseLandscape => Config.Orientations?.DefaultOrientation == UIOrientation.LandscapeLeft ||
                                                         (Config.Orientations?.DefaultOrientation == UIOrientation.AutoRotation &&
                                                          Config.Orientations?.AllowAutoRotateToReverseLandscape == true);

        static AndroidApkToolchain()
        {
            var buildconfiguration = NPath.CurrentDirectory.Combine("buildconfiguration.json");
            Backend.Current.RegisterFileInfluencingGraph(buildconfiguration);
            BuildConfiguration.Read(buildconfiguration, typeof(AndroidApkToolchain.Config));
        }

        public static AndroidApkToolchain GetToolChain(bool useStatic, bool mainTarget)
        {
            // wrong build configuration
            if (!Config.Validate())
            {
                return new AndroidApkToolchain(new AndroidNdkLocator(new ARMv7Architecture()).UserDefaultOrDummy, useStatic, mainTarget);
            }

            Architecture architecture;
            if (mainTarget)
            {
                if ((Config.Architectures.Architectures & AndroidArchitecture.ARMv7) != 0)
                {
                    architecture = new ARMv7Architecture();
                }
                else if ((Config.Architectures.Architectures & AndroidArchitecture.ARM64) != 0)
                {
                    architecture = new Arm64Architecture();
                }
                else // shouldn't happen
                {
                    return null;
                }
            }
            else if (IsFatApk) // complementary target for fat apk
            {
                architecture = new Arm64Architecture();
            }
            else // complementary target for single-architecture apk
            {
                return null;
            }
            var androidNdk = (new AndroidNdkLocator(architecture)).UseSpecific(new NPath(Config.ExternalTools.NdkPath));
            return new AndroidApkToolchain(androidNdk, useStatic, mainTarget);
        }

        public AndroidApkToolchain(AndroidNdk ndk, bool useStatic, bool mainTarget) : base(ndk)
        {
            DynamicLibraryFormat = useStatic ? new AndroidApkStaticLibraryFormat(this) as NativeProgramFormat :
                                               new AndroidApkDynamicLibraryFormat(this) as NativeProgramFormat;
            ExecutableFormat = mainTarget ?
                               new AndroidApkFormat(this) as NativeProgramFormat :
                               new AndroidApkMainModuleFormat(this) as NativeProgramFormat;
            CppCompiler = new AndroidNdkCompilerNoThumb(ActionName, Architecture, Platform, Sdk, ndk.ApiLevel, useStatic);
        }

        public static NPath GetGradleLaunchJarPath()
        {
            var launcherFiles = new NPath(Config.ExternalTools.GradlePath).Combine("lib").Files("gradle-launcher-*.jar");
            if (launcherFiles.Length == 1)
                return launcherFiles[0];
            return null;
        }
    }

    internal class AndroidNdkCompilerNoThumb : AndroidNdkCompiler
    {
        public AndroidNdkCompilerNoThumb(string actionNameSuffix, Architecture targetArchitecture, Platform targetPlatform, Sdk sdk, int apiLevel, bool useStatic)
            : base(actionNameSuffix, targetArchitecture, targetPlatform, sdk, apiLevel)
        {
            DefaultSettings = new AndroidNdkCompilerSettingsNoThumb(this, apiLevel, useStatic)
                .WithExplicitlyRequireCPlusPlusIncludes(((AndroidNdk)sdk).GnuBinutils)
                .WithPositionIndependentCode(true);
        }
    }

    public class AndroidNdkCompilerSettingsNoThumb : AndroidNdkCompilerSettings
    {
        public AndroidNdkCompilerSettingsNoThumb(AndroidNdkCompiler gccCompiler, int apiLevel, bool useStatic) : base(gccCompiler, apiLevel)
        {
            UseStatic = useStatic;
        }

        public override IEnumerable<string> CommandLineFlagsFor(NPath target)
        {
            foreach (var flag in base.CommandLineFlagsFor(target))
            {
                // disabling thumb for Debug configuration to solve problem with Android Studio debugging
                if (flag == "-mthumb" && CodeGen == CodeGen.Debug)
                    yield return "-marm";
                else
                    yield return flag;
            }
            if (UseStatic)
            {
                yield return "-DSTATIC_LINKING";
            }
        }

        private bool UseStatic { get; set; }
    }

    // AndroidApkStaticLibraryFormat / AndroidStaticLinker / AndroidApkStaticLibrary are being used instead of
    // AndroidNdkStaticLibraryFormat / LLVMArStaticLinkerForAndroid / StaticLibrary because it is required to keep
    // system libs on which this lib depends on, but which are not embedded. Information about these system libs
    // is required when this static lib is being used as an input file when linking some other library.
    // This has been discussed here https://unity.slack.com/archives/C1RM0NBLY/p1589960319112500
    // Jira ticket has been created https://jira.unity3d.com/browse/DS-243
    // TODO: get rid of these extra classes once required functionality is added to StaticLibrary.
    internal sealed class AndroidApkStaticLibraryFormat : NativeProgramFormat
    {
        public override string Extension { get; } = "a";

        internal AndroidApkStaticLibraryFormat(AndroidNdkToolchain toolchain) : base(
            new AndroidStaticLinker(toolchain))
        {
        }
    }

    internal class AndroidStaticLinker : LLVMArStaticLinkerForAndroid
    {
        public AndroidStaticLinker(ToolChain toolchain) : base(toolchain)
        {
        }

        protected override BuiltNativeProgram BuiltNativeProgramFor(NPath destination, IEnumerable<PrecompiledLibrary> allLibraries)
        {
            return (BuiltNativeProgram)new AndroidApkStaticLibrary(destination, allLibraries.ToArray());
        }
    }

    internal class AndroidApkStaticLibrary : StaticLibrary
    {
        public AndroidApkStaticLibrary(NPath path, PrecompiledLibrary[] libraryDependencies = null) : base(path, libraryDependencies)
        {
            SystemLibraries = libraryDependencies.Where(l => l.System).ToArray();
        }

        public PrecompiledLibrary[] SystemLibraries { get; private set; }
    }

    internal sealed class AndroidApkDynamicLibraryFormat : NativeProgramFormat
    {
        public override string Extension { get; } = "so";

        internal AndroidApkDynamicLibraryFormat(AndroidNdkToolchain toolchain) : base(
            new AndroidDynamicLinker(toolchain).AsDynamicLibrary().WithStaticCppRuntime(toolchain.Sdk.Version.Major >= 19))
        {
        }
    }

    internal sealed class AndroidApkMainModuleFormat : NativeProgramFormat
    {
        public override string Extension { get; } = "so";

        internal AndroidApkMainModuleFormat(AndroidNdkToolchain toolchain) : base(
            new AndroidApkMainModuleLinker(toolchain).AsDynamicLibrary().WithStaticCppRuntime(toolchain.Sdk.Version.Major >= 19))
        {
        }
    }

    internal class AndroidApkMainModuleLinker : AndroidDynamicLinker
    {
        public AndroidApkMainModuleLinker(AndroidNdkToolchain toolchain) : base(toolchain) { }

        protected NPath ChangeMainModuleName(NPath target)
        {
            // need to rename to make it start with "lib", otherwise Android have problems with loading native library
            return target.Parent.Combine("lib" + target.FileName).ChangeExtension("so");
        }

        public override BuiltNativeProgram CombineObjectFiles(
            NPath destination,
            CodeGen codegen,
            IEnumerable<NPath> objectFiles,
            IEnumerable<PrecompiledLibrary> allLibraries,
            bool nativeProgramSupportsLeafInputCaching)
        {
            var requiredLibraries = allLibraries.ToList();
            foreach (var l in allLibraries.OfType<AndroidApkStaticLibrary>())
            {
                foreach (var sl in l.SystemLibraries)
                {
                    if (!requiredLibraries.Contains(sl)) requiredLibraries.Add(sl);
                }
            }
            return base.CombineObjectFiles(
                destination,
                codegen,
                objectFiles,
                requiredLibraries,
                nativeProgramSupportsLeafInputCaching);
        }

        protected override IEnumerable<string> CommandLineFlagsForLibrary(PrecompiledLibrary library, CodeGen codegen)
        {
            // if lib which contains all JNI code is linked statically, then all methods from this lib should be exposed
            var entryPoint = library.ToString().Contains("lib_unity_tiny_android.a");
            if (entryPoint)
            {
                yield return "-Wl,--whole-archive";
            }
            foreach (var flag in base.CommandLineFlagsForLibrary(library, codegen))
            {
                yield return flag;
            }
            if (entryPoint)
            {
                yield return "-Wl,--no-whole-archive";
            }
        }

        protected override IEnumerable<string> CommandLineFlagsFor(NPath target, CodeGen codegen, IEnumerable<NPath> inputFiles)
        {
            foreach (var flag in base.CommandLineFlagsFor(ChangeMainModuleName(target), codegen, inputFiles))
            {
                yield return flag;
            }
        }

        protected override BuiltNativeProgram BuiltNativeProgramFor(NPath destination, IEnumerable<PrecompiledLibrary> allLibraries)
        {
            var dynamicLibraries = allLibraries.Where(l => l.Dynamic).ToArray();
            return (BuiltNativeProgram)new AndroidApkMainModule(ChangeMainModuleName(destination), Toolchain as AndroidApkToolchain, dynamicLibraries);
        }
    }

    internal sealed class AndroidApkMainModule : DynamicLibrary, IPackagedAppExtension
    {
        private String m_libPath;
        private String m_gameName;

        public AndroidApkMainModule(NPath path, AndroidApkToolchain toolchain, params PrecompiledLibrary[] dynamicLibraryDependencies) : base(path, dynamicLibraryDependencies)
        {
            m_libPath = toolchain.Architecture is Arm64Architecture ? "arm64-v8a" : "armeabi-v7a";
        }

        public void SetAppPackagingParameters(String gameName, DotsConfiguration config)
        {
            m_gameName = gameName;
        }

        public override BuiltNativeProgram DeployTo(NPath targetDirectory, Dictionary<IDeployable, IDeployable> alreadyDeployed = null)
        {
            // This is complementary target, library should be deployed to the corresponding folder of the main target
            // see comment in https://github.com/Unity-Technologies/dots/blob/master/TinySamples/Packages/com.unity.dots.runtime/bee%7E/BuildProgramSources/DotsConfigs.cs
            // DotsConfigs.MakeConfigs() method for details.
            var gradleProjectPath = AndroidApkToolchain.ExportProject ? targetDirectory.Combine(m_gameName) : Path.Parent.Parent.Combine("gradle");
            var libDirectory = gradleProjectPath.Combine("src/main/jniLibs").Combine(m_libPath);
            // Deployables with type DeployableFile are deployed with main target
            Deployables = Deployables.Where(f => !(f is DeployableFile)).ToArray();
            var result = base.DeployTo(libDirectory, alreadyDeployed);
            // Required to make sure that main target Gradle project depends on this lib and this lib is deployed before packaging step
            Backend.Current.AddDependency(gradleProjectPath.Combine("build.gradle"), result.Path);
            return result;
        }
    }

    internal sealed class AndroidApkFormat : NativeProgramFormat
    {
        public override string Extension { get; } = AndroidApkToolchain.ExportProject ? "" : (AndroidApkToolchain.BuildAppBundle ? "aab" : "apk");

        internal AndroidApkFormat(AndroidNdkToolchain toolchain) : base(
            new AndroidApkLinker(toolchain).AsDynamicLibrary().WithStaticCppRuntime(toolchain.Sdk.Version.Major >= 19))
        {
        }
    }

    internal class AndroidApkLinker : AndroidApkMainModuleLinker
    {
        public AndroidApkLinker(AndroidNdkToolchain toolchain) : base(toolchain) { }

        protected override BuiltNativeProgram BuiltNativeProgramFor(NPath destination, IEnumerable<PrecompiledLibrary> allLibraries)
        {
            var dynamicLibraries = allLibraries.Where(l => l.Dynamic).ToArray();
            return (BuiltNativeProgram)new AndroidApk(ChangeMainModuleName(destination), Toolchain as AndroidApkToolchain, dynamicLibraries);
        }
    }

    internal class AndroidApk : DynamicLibrary, IPackagedAppExtension
    {
        private AndroidApkToolchain m_apkToolchain;
        private String m_gameName;
        private DotsConfiguration m_config;
        private List<NPath> m_projectFiles = new List<NPath>();

        public AndroidApk(NPath path, AndroidApkToolchain toolchain, params PrecompiledLibrary[] dynamicLibraryDependencies) : base(path, dynamicLibraryDependencies)
        {
            m_apkToolchain = toolchain;
        }

        public void SetAppPackagingParameters(String gameName, DotsConfiguration config)
        {
            m_gameName = gameName;
            m_config = config;
        }

        static readonly string AndroidConfigChanges = string.Join("|", new[]
        {
            "mcc",
            "mnc",
            "locale",
            "touchscreen",
            "keyboard",
            "keyboardHidden",
            "navigation",
            "orientation",
            "screenLayout",
            "uiMode",
            "screenSize",
            "smallestScreenSize",
            "fontScale",
            "layoutDirection",
            // "density",   // this is added dynamically if target SDK level is higher than 23.
        });

        private static string GetOrientationAttr()
        {
            string orientationAttr = null;

            var autoPortrait = AndroidApkToolchain.AllowedOrientationPortrait || AndroidApkToolchain.AllowedOrientationReversePortrait;
            var autoLandscape = AndroidApkToolchain.AllowedOrientationLandscape || AndroidApkToolchain.AllowedOrientationReverseLandscape;
            UIOrientation? defaultOrientation = AndroidApkToolchain.Config.Orientations?.DefaultOrientation;

            if (defaultOrientation == UIOrientation.Portrait)
                orientationAttr = "portrait";
            else if (defaultOrientation == UIOrientation.PortraitUpsideDown)
                orientationAttr = "reversePortrait";
            else if (defaultOrientation == UIOrientation.LandscapeLeft)
                orientationAttr = "reverseLandscape";
            else if (defaultOrientation == UIOrientation.LandscapeRight)
                orientationAttr = "landscape";
            else if (autoPortrait && autoLandscape)
                orientationAttr = "fullSensor";
            else if (autoPortrait)
                orientationAttr = "sensorPortrait";
            else if (autoLandscape)
                orientationAttr = "sensorLandscape";
            else
                orientationAttr = "unspecified";

            return orientationAttr;
        }

        private static string GetPermissionString(string permission)
        {
            return $"<uses-permission android:name=\"{permission}\" />";
        }

        private static string GetMetaDataString(string name, string val)
        {
            return $"<meta-data android:name=\"{name}\" android:value=\"{val}\" />";
        }

        private static string GetFeatureString(string name, bool required)
        {
            return $"<uses-feature android:name=\"{name}\" android:required=\"{required.ToString().ToLower()}\" />";
        }

        private void GenerateGradleProject(NPath gradleProjectPath)
        {
            var gradleSrcPath = AsmDefConfigFile.AsmDefDescriptionFor("Unity.Build.Android.DotsRuntime").Path.Parent.Combine("AndroidProjectTemplate~/");

            var hasGradleDependencies = false;
            var gradleDependencies = new StringBuilder();
            gradleDependencies.AppendLine("    dependencies {");
            var hasKotlin = false;
            foreach (var d in Deployables.Where(d => (d is DeployableFile)))
            {
                var f = d as DeployableFile;
                if (f.Path.Extension == "aar" || f.Path.Extension == "jar")
                {
                    gradleDependencies.AppendLine($"        compile(name:'{f.Path.FileNameWithoutExtension}', ext:'{f.Path.Extension}')");
                    hasGradleDependencies = true;
                }
                else if (f.Path.Extension == "kt")
                {
                    hasKotlin = true;
                }
            }
            if (hasGradleDependencies)
            {
                gradleDependencies.AppendLine("    }");
            }
            else
            {
                gradleDependencies.Clear();
            }

            var kotlinClassPath = hasKotlin ? "        classpath 'org.jetbrains.kotlin:kotlin-gradle-plugin:1.3.11'" : "";
            var kotlinPlugin = hasKotlin ? "apply plugin: 'kotlin-android'" : "";

            var loadLibraries = new StringBuilder();
            bool useStaticLib = Deployables.FirstOrDefault(l => l.ToString().Contains("lib_unity_tiny_android.so")) == default(IDeployable);
            if (useStaticLib)
            {
                loadLibraries.AppendLine($"        System.loadLibrary(\"{m_gameName}\");");
            }
            else
            {
                var rx = new Regex(@".*lib([\w\d_]+)\.so", RegexOptions.Compiled);
                foreach (var l in Deployables)
                {
                    var match = rx.Match(l.ToString());
                    if (match.Success)
                    {
                        loadLibraries.AppendLine($"        System.loadLibrary(\"{match.Groups[1].Value}\");");
                    }
                }
            }

            String abiFilters = "";
            if (AndroidApkToolchain.Config.Architectures.Architectures == AndroidArchitecture.ARM64)
            {
                abiFilters = "'arm64-v8a'";
            }
            else if (AndroidApkToolchain.Config.Architectures.Architectures == AndroidArchitecture.ARMv7)
            {
                abiFilters = "'armeabi-v7a'";
            }
            else if (AndroidApkToolchain.IsFatApk)
            {
                abiFilters = "'armeabi-v7a', 'arm64-v8a'";
            }
            else // shouldn't happen
            {
                Console.WriteLine($"Tiny android toolchain doesn't support {AndroidApkToolchain.Config.Architectures.Architectures.ToString()} architectures");
            }

            // Android docs say "density" value was added in API level 17, but it doesn't compile with target SDK level lower than 24.
            string configChanges = ((int)AndroidApkToolchain.Config.APILevels.ResolvedTargetAPILevel > 23) ? AndroidConfigChanges + "|density" : AndroidConfigChanges;
            var useKeystore = BuildConfiguration.HasComponent<AndroidKeystore>();
            var renderOutsideSafeArea = BuildConfiguration.HasComponent<AndroidRenderOutsideSafeArea>();

            var icons = AndroidApkToolchain.Config.Icons;
            var hasBackground = icons.Icons.Any(i => !String.IsNullOrEmpty(i.Background));
            var hasCustomIcons = hasBackground || icons.Icons.Any(i => !String.IsNullOrEmpty(i.Foreground) || !String.IsNullOrEmpty(i.Legacy));
            var version = AndroidApkToolchain.Config.Settings.Version;
            var versionFieldCount = version.Revision > 0 ? 4 : 3;
            var maxRatio = AndroidApkToolchain.Config.AspectRatio.GetMaxAspectRatio(AndroidApkToolchain.Config.APILevels.ResolvedTargetAPILevel);
            var additionalApplicationMetadata = "";
            var additionalPermissions = "";
            var additionalFeatures = "";
            if (!String.IsNullOrEmpty(maxRatio))
            {
                additionalApplicationMetadata += GetMetaDataString("android.max_aspect", maxRatio);
            }
            if (BuildConfiguration.HasComponent<ARCoreSettings>())
            {
                additionalPermissions += GetPermissionString("android.permission.CAMERA");
                if (AndroidApkToolchain.Config.ARCore.Requirement == Requirement.Optional)
                {
                    additionalApplicationMetadata += "\n" + GetMetaDataString("com.google.ar.core", "optional");
                }
                else
                {
                    additionalApplicationMetadata += "\n" + GetMetaDataString("com.google.ar.core", "required");
                    additionalFeatures += GetFeatureString("android.hardware.camera.ar", true);
                }
                if (AndroidApkToolchain.Config.ARCore.DepthSupport == Requirement.Required)
                {
                    additionalFeatures += "\n" + GetFeatureString("com.google.ar.core.depth", true);
                }
            }
            var templateStrings = new Dictionary<string, string>
            {
                { "**LOADLIBRARIES**", loadLibraries.ToString() },
                { "**PACKAGENAME**", AndroidApkToolchain.Config.Identifier.PackageName },
                { "**PRODUCTNAME**", AndroidApkToolchain.Config.Settings.ProductName },
                { "**VERSIONNAME**", version.ToString(versionFieldCount) },
                { "**VERSIONCODE**", AndroidApkToolchain.Config.VersionCode.VersionCode.ToString() },
                { "**ORIENTATION**", GetOrientationAttr() },
                { "**INSTALLLOCATION**", AndroidApkToolchain.Config.InstallLocation?.PreferredInstallLocationAsString() },
                { "**CUTOUTMODE**", AndroidRenderOutsideSafeArea.CutoutMode(renderOutsideSafeArea) },
                { "**NOTCHCONFIG**", AndroidRenderOutsideSafeArea.NotchConfig(renderOutsideSafeArea) },
                { "**NOTCHSUPPORT**", AndroidRenderOutsideSafeArea.NotchSupport(renderOutsideSafeArea) },
                { "**GAMENAME**", m_gameName },
                { "**MINSDKVERSION**", ((int)AndroidApkToolchain.Config.APILevels.MinAPILevel).ToString() },
                { "**TARGETSDKVERSION**", ((int)AndroidApkToolchain.Config.APILevels.ResolvedTargetAPILevel).ToString()},
                { "**CONFIGCHANGES**", configChanges },
                { "**ACTIVITY_ASPECT**", String.IsNullOrEmpty(maxRatio) ? "" : $"android:maxAspectRatio=\"{maxRatio}\"" },
                { "**ADDITIONAL_APPLICATION_METADATA**", additionalApplicationMetadata },
                { "**ADDITIONAL_PERMISSIONS**", additionalPermissions },
                { "**ADDITIONAL_FEATURES**", additionalFeatures },
                { "**ABIFILTERS**", abiFilters },
                { "**SIGN**", AndroidApkToolchain.Config.Keystore.GetSigningConfigs(useKeystore) },
                { "**SIGNCONFIG**", AndroidApkToolchain.Config.Keystore.GetSigningConfig(useKeystore) },
                { "**DEPENDENCIES**", gradleDependencies.ToString() },
                { "**KOTLINCLASSPATH**", kotlinClassPath },
                { "**KOTLINPLUGIN**", kotlinPlugin },
                { "**ALLOWED_PORTRAIT**", AndroidApkToolchain.AllowedOrientationPortrait ? "true" : "false" },
                { "**ALLOWED_REVERSE_PORTRAIT**", AndroidApkToolchain.AllowedOrientationReversePortrait ? "true" : "false" },
                { "**ALLOWED_LANDSCAPE**", AndroidApkToolchain.AllowedOrientationLandscape ? "true" : "false" },
                { "**ALLOWED_REVERSE_LANDSCAPE**", AndroidApkToolchain.AllowedOrientationReverseLandscape ? "true" : "false" },
                { "**BACKGROUND_PATH**", hasBackground ? "mipmap" : "drawable" }
            };

            // copy icon files
            if (hasCustomIcons)
            {
                for (int i = 0; i < icons.Icons.Length; ++i)
                {
                    var dpi = ((ScreenDPI)i).ToString().ToLower();
                    if (AndroidApkToolchain.Config.APILevels.TargetSDKSupportsAdaptiveIcons)
                    {
                        CopyIcon(gradleProjectPath, dpi, "ic_launcher_foreground.png", icons.Icons[i].Foreground);
                        CopyIcon(gradleProjectPath, dpi, "ic_launcher_background.png", icons.Icons[i].Background);
                    }
                    CopyIcon(gradleProjectPath, dpi, "app_icon.png", icons.Icons[i].Legacy);
                }
            }

            // copy and patch project files
            var apiRx = new Regex(@".+res[\\|\/].+-v([0-9]+)$", RegexOptions.Compiled);
            foreach (var r in gradleSrcPath.Files(true))
            {
                if ((hasCustomIcons && r.HasDirectory("mipmap-mdpi")) ||
                    (hasBackground && r.HasDirectory("drawable"))) // skipping icons files if there are custom ones
                {
                    continue;
                }
                if (!AndroidApkToolchain.Config.APILevels.TargetSDKSupportsAdaptiveIcons && r.FileName.StartsWith("ic_launcher_"))
                {
                    continue;
                }
                var match = apiRx.Match(r.Parent.ToString());
                if (match.Success)
                {
                    var api = Int32.Parse(match.Groups[1].Value);
                    if (api > (int)AndroidApkToolchain.Config.APILevels.ResolvedTargetAPILevel)
                    {
                        continue;
                    }
                }

                var destPath = gradleProjectPath.Combine(r.RelativeTo(gradleSrcPath));
                if (r.Extension == "template")
                {
                    destPath = destPath.ChangeExtension("");
                    var code = r.ReadAllText();
                    foreach (var t in templateStrings)
                    {
                        if (code.IndexOf(t.Key) != -1)
                        {
                            code = code.Replace(t.Key, t.Value);
                        }
                    }
                    Backend.Current.AddWriteTextAction(destPath, code);
                }
                else
                {
                    destPath = CopyTool.Instance().Setup(destPath, r);
                }
                m_projectFiles.Add(destPath);
            }

            var localProperties = new StringBuilder();
            localProperties.AppendLine($"sdk.dir={new NPath(AndroidApkToolchain.Config.ExternalTools.SdkPath).ToString()}");
            localProperties.AppendLine($"ndk.dir={new NPath(AndroidApkToolchain.Config.ExternalTools.NdkPath).ToString()}");
            var localPropertiesPath = gradleProjectPath.Combine("local.properties");
            Backend.Current.AddWriteTextAction(localPropertiesPath, localProperties.ToString());
            m_projectFiles.Add(localPropertiesPath);
        }

        private void CopyIcon(NPath destPath, string dpi, string iconName, string configIcon)
        {
            if (String.IsNullOrEmpty(configIcon))
            {
                return;
            }
            destPath = destPath.Combine($"src/main/res/mipmap-{dpi}", iconName);
            var srcPath = new NPath(configIcon);
            if (srcPath.IsRelative)
            {
                srcPath = (new NPath("../..")).Combine(srcPath);
            }
            m_projectFiles.Add(CopyTool.Instance().Setup(destPath, srcPath));
        }

        private NPath PackageApp(NPath buildPath, BuiltNativeProgram mainProgram)
        {
            var mainLibPath = mainProgram.Path;
            m_projectFiles.Add(mainLibPath);
            m_projectFiles.AddRange(mainProgram.Deployables.Select(d => d.Path));

            if (m_apkToolchain == null)
            {
                Console.WriteLine($"Error: not Android APK toolchain");
                return buildPath;
            }
            if (AndroidApkToolchain.ExportProject)
            {
                var deployedPath = buildPath.Combine(m_gameName);
                GenerateGradleProject(deployedPath);

                // stub action to have deployedPath in build tree and set correct dependencies
                Backend.Current.AddAction(
                    actionName: "Gradle project folder",
                    targetFiles: new[] { deployedPath },
                    inputs: m_projectFiles.ToArray(),
                    executableStringFor: $"echo created",
                    commandLineArguments: Array.Empty<string>(),
                    allowUnexpectedOutput: true,
                    allowUnwrittenOutputFiles: true
                );
                return deployedPath;
            }
            else
            {
                var deployedPath = buildPath.Combine(m_gameName + "." + m_apkToolchain.ExecutableFormat.Extension);
                var gradleProjectPath = mainLibPath.Parent.Parent.Parent.Parent.Parent;
                GenerateGradleProject(gradleProjectPath);
                var pathToRoot = new NPath(string.Concat(Enumerable.Repeat("../", gradleProjectPath.Depth)));

                var javaLaunchPath = new NPath(AndroidApkToolchain.Config.ExternalTools.JavaPath).Combine("bin").Combine("java");
                var gradleLaunchPath = AndroidApkToolchain.GetGradleLaunchJarPath();
                var releaseBuild = m_config == DotsConfiguration.Release;
                var gradleCommand = AndroidApkToolchain.BuildAppBundle ?
                                   (releaseBuild ? "bundleRelease" : "bundleDebug") :
                                   (releaseBuild ? "assembleRelease" : "assembleDebug");
                var gradleExecutableString = $"cd {gradleProjectPath.InQuotes()} && {javaLaunchPath.InQuotes()} -classpath {gradleLaunchPath.InQuotes()} org.gradle.launcher.GradleMain {gradleCommand} && cd {pathToRoot.InQuotes()}";

                var config = releaseBuild ? "release" : "debug";
                var gradleBuildPath = gradleProjectPath.Combine("build/outputs").
                                      Combine(AndroidApkToolchain.BuildAppBundle ? "bundle" : "apk").
                                      Combine($"{config}/gradle-{config}.{(AndroidApkToolchain.BuildAppBundle ? "aab" : "apk")}");

                Backend.Current.AddAction(
                    actionName: "Build Gradle project",
                    targetFiles: new[] { gradleBuildPath },
                    inputs: m_projectFiles.ToArray(),
                    executableStringFor: gradleExecutableString,
                    commandLineArguments: Array.Empty<string>(),
                    allowUnexpectedOutput: false,
                    allowedOutputSubstrings: new[] { ":*", "BUILD SUCCESSFUL in *" }
                );

                return CopyTool.Instance().Setup(deployedPath, gradleBuildPath);
            }
        }

        public override BuiltNativeProgram DeployTo(NPath targetDirectory, Dictionary<IDeployable, IDeployable> alreadyDeployed = null)
        {
            var gradleProjectPath = AndroidApkToolchain.ExportProject ? targetDirectory.Combine(m_gameName) : Path.Parent.Combine("gradle");
            var libDirectory = gradleProjectPath.Combine("src/main/jniLibs");
            libDirectory = libDirectory.Combine(m_apkToolchain.Architecture is Arm64Architecture ? "arm64-v8a" : "armeabi-v7a");

            for (int i = 0; i < Deployables.Length; ++i)
            {
                if (Deployables[i] is DeployableFile)
                {
                    var f = Deployables[i] as DeployableFile;
                    var targetPath = gradleProjectPath.Combine("src/main/assets");
                    if (f.Path.Extension == "java")
                    {
                        targetPath = gradleProjectPath.Combine("src/main/java");
                    }
                    if (f.Path.Extension == "kt")
                    {
                        targetPath = gradleProjectPath.Combine("src/main/kotlin");
                    }
                    else if (f.Path.Extension == "aar" || f.Path.Extension == "jar")
                    {
                        targetPath = gradleProjectPath.Combine("libs");
                    }
                    else if (f.Path.FileName == "testconfig.json")
                    {
                        targetPath = targetDirectory;
                    }
                    targetPath = targetPath.Combine(f.RelativeDeployPath ?? f.Path.FileName);

                    Deployables[i] = new DeployableFile(f.Path, targetPath.RelativeTo(libDirectory));
                }
            }

            var result = base.DeployTo(libDirectory, alreadyDeployed);

            return new Executable(PackageApp(targetDirectory, result));
        }
    }

}

