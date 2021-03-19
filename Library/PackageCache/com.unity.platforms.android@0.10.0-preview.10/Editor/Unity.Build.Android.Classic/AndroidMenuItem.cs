using Unity.Build.Classic;
using Unity.Build.Common;
using Unity.Build.Editor;
using UnityEditor;

namespace Unity.Build.Android.Classic
{
    static class AndroidMenuItem
    {
        const string k_CreateBuildConfigurationAssetClassic = BuildConfigurationMenuItem.k_BuildConfigurationMenu + "Android Classic Build Configuration";

        [MenuItem(k_CreateBuildConfigurationAssetClassic)]
        static void CreateBuildConfigurationAssetClassic()
        {
            var newAsset = BuildConfigurationMenuItem.CreateAssetInActiveDirectory("AndroidClassic", GetDefaultComponents());
            if (newAsset != null && newAsset)
                ProjectWindowUtil.ShowCreatedAsset(newAsset);
        }

        static IBuildComponent[] GetDefaultComponents()
        {
            return new IBuildComponent[]
            {
                new GeneralSettings(),
                new SceneList(),
                new ClassicBuildProfile {Platform = Platform.Android}
            };
        }
    }
}
