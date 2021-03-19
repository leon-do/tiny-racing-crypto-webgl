using Unity.Build.Classic;
using Unity.Build.Common;
using Unity.Build.Editor;
using UnityEditor;

namespace Unity.Build.Linux.Classic
{
    static class LinuxMenuItem
    {
        const string k_CreateBuildConfigurationAssetClassic = BuildConfigurationMenuItem.k_BuildConfigurationMenu + "Linux Classic Build Configuration";

        [MenuItem(k_CreateBuildConfigurationAssetClassic)]
        static void CreateBuildConfigurationAsset()
        {
            var newAsset = BuildConfigurationMenuItem.CreateAssetInActiveDirectory("LinuxClassic", GetDefaultComponents());
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
                    Platform = Platform.Linux
                }
            };
        }
    }
}
