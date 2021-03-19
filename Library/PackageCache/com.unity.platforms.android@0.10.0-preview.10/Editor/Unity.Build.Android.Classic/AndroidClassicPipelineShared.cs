using Unity.Build.Common;
using Unity.Build.Classic;

namespace Unity.Build.Android.Classic
{
    class AndroidClassicPipelineShared
    {
        internal static void ClearReverseTunneling()
        {
#if UNITY_ANDROID
            var args = new[]
{
                "reverse --remove-all"
            };

            var result = UnityEditor.Android.ADB.GetInstance().Run(args, "Failed to clear reverse tunneling");

            UnityEngine.Debug.Log("Clearing reverse tunneling");
#endif
        }

        internal static void ClearForwardTunneling()
        {
#if UNITY_ANDROID
            var args = new[]
{
                "forward --remove-all"
            };

            var result = UnityEditor.Android.ADB.GetInstance().Run(args, "Failed to clear forward tunneling");

            UnityEngine.Debug.Log("Clearing forward tunneling");
#endif
        }

        internal static void SetupForwardTunneling(string packageName)
        {
#if UNITY_ANDROID
            var args = new[]
            {
                "forward",
                "tcp:" + UnityEditorInternal.ProfilerDriver.directConnectionPort,
                "localabstract:Unity-" + packageName
            };

            var result = UnityEditor.Android.ADB.GetInstance().Run(args, "Failed to set tunneling");

            UnityEngine.Debug.Log("Setting up tunneling: adb " + string.Join(" ", args) + "\n" + result);
#endif
        }

        internal static void SetupReverseTunneling()
        {
#if UNITY_ANDROID
            // Note: See Editor\Src\BuildPipeline\BuildPlayer.cpp, where we set player-connection-direct-connection-port for Android
            var args = new[]
            {
                "reverse",
                "tcp:" + (uint.Parse(UnityEditorInternal.ProfilerDriver.directConnectionPort) - 1),
                "tcp:" + UnityEditorInternal.ProfilerDriver.directConnectionPort,
            };

            var result = UnityEditor.Android.ADB.GetInstance().Run(args, "Failed to set tunneling");

            UnityEngine.Debug.Log("Setting up tunneling: adb " + string.Join(" ", args) + "\n" + result);
#endif
        }

        internal static void SetupPlayerConnection(RunContext context)
        {
            var config = context.GetComponentOrDefault<ClassicBuildProfile>().Configuration;
            if (config == BuildType.Debug || config == BuildType.Develop)
            {
                AndroidClassicPipelineShared.ClearForwardTunneling();
                AndroidClassicPipelineShared.ClearReverseTunneling();
                if (context.TryGetComponent<PlayerConnectionSettings>(out PlayerConnectionSettings value) && value.Mode == PlayerConnectionInitiateMode.Connect)
                    AndroidClassicPipelineShared.SetupReverseTunneling();
                else
                {
                    var packageName = context.GetComponentOrDefault<ApplicationIdentifier>().PackageName;
                    AndroidClassicPipelineShared.SetupForwardTunneling(packageName);
                }
            }
        }

    }
}
