using Unity.Build.Classic;
using Unity.Build.Common;
using Unity.Build.Editor;
using UnityEditor;

namespace Unity.Build.macOS.Classic
{
    static class MacOSMenuItem
    {
        const string k_CreateBuildConfigurationAssetClassic = BuildConfigurationMenuItem.k_BuildConfigurationMenu + "macOS Classic Build Configuration";

        [MenuItem(k_CreateBuildConfigurationAssetClassic)]
        static void CreateBuildConfigurationAsset()
        {
            var newAsset = BuildConfigurationMenuItem.CreateAssetInActiveDirectory("macOSClassic", GetDefaultComponents());
            if (newAsset != null && newAsset)
                ProjectWindowUtil.ShowCreatedAsset(newAsset);
        }

        static IBuildComponent[] GetDefaultComponents()
        {
            return new IBuildComponent[]
            {
                new GeneralSettings(),
                new SceneList(),
                new ClassicBuildProfile
                {
                    Platform = Platform.macOS
                }
            };
        }
    }
}
