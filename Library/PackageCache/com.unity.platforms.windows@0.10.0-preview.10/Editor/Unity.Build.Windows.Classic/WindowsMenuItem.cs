using Unity.Build.Classic;
using Unity.Build.Common;
using Unity.Build.Editor;
using UnityEditor;

namespace Unity.Build.Windows.Classic
{
    static class WindowsMenuItem
    {
        const string k_CreateBuildConfigurationAssetClassic = BuildConfigurationMenuItem.k_BuildConfigurationMenu + "Windows Classic Build Configuration";

        [MenuItem(k_CreateBuildConfigurationAssetClassic)]
        static void CreateBuildConfigurationAssetClassic()
        {
            var newAsset = BuildConfigurationMenuItem.CreateAssetInActiveDirectory("WindowsClassic", GetDefaultComponents());
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
                    Platform = Platform.Windows
                }
            };
        }
    }
}
