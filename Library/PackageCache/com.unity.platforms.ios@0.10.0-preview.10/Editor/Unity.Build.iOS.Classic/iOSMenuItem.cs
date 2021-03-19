using Unity.Build.Classic;
using Unity.Build.Common;
using Unity.Build.Editor;
using UnityEditor;

namespace Unity.Build.iOS.Classic
{
    static class iOSMenuItem
    {
        const string k_CreateBuildConfigurationAssetClassic = BuildConfigurationMenuItem.k_BuildConfigurationMenu + "iOS Classic Build Configuration";

        [MenuItem(k_CreateBuildConfigurationAssetClassic)]
        static void CreateBuildConfigurationAsset()
        {
            var newAsset = BuildConfigurationMenuItem.CreateAssetInActiveDirectory("iOSClassic", GetDefaultComponents());
            if (newAsset != null && newAsset)
                ProjectWindowUtil.ShowCreatedAsset(newAsset);
        }

        static IBuildComponent[] GetDefaultComponents()
        {
            return new IBuildComponent[]
            {
                new GeneralSettings(),
                new SceneList(),
                new ClassicBuildProfile {Platform = Platform.iOS}
            };
        }
    }
}
