using Unity.Properties;

namespace Unity.Build.Android
{
    // Preferred application install location
    internal enum AndroidPreferredInstallLocation
    {
        // Let the OS decide, app doesn't have any preferences
        Auto = 0,

        // Prefer external, if possible. Install to internal otherwise
        PreferExternal = 1,

        // Force installation into internal memory. Needed for things like Live Wallpapers
        ForceInternal = 2,
    }

    internal sealed partial class AndroidInstallLocation
    {
        [CreateProperty]
        public AndroidPreferredInstallLocation InstallLocation { set; get; } = AndroidPreferredInstallLocation.Auto;

        public string PreferredInstallLocationAsString()
        {
            switch (InstallLocation)
            {
                case AndroidPreferredInstallLocation.Auto: return "auto";
                case AndroidPreferredInstallLocation.PreferExternal: return "preferExternal";
                case AndroidPreferredInstallLocation.ForceInternal: return "internalOnly";
            }
            return "preferExternal";
        }
    }
}
