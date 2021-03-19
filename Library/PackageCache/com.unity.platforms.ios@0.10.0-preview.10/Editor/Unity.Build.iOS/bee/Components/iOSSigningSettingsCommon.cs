using System;
using Unity.Properties;
using UnityEngine;

namespace Unity.Build.iOS
{
    internal enum ProvisioningProfileType
    {
        Automatic,
        Development,
        Distribution
    }

    internal sealed partial class iOSSigningSettings
    {
        [CreateProperty]
        public string SigningTeamID { set; get; } = string.Empty;

        [CreateProperty]
        public bool AutomaticallySign { set; get; } = true;

        [CreateProperty]
        public string ProfileID { set; get; } = string.Empty;

        [CreateProperty]
        public ProvisioningProfileType ProfileType { set; get; } = ProvisioningProfileType.Development;

        [CreateProperty]
        [HideInInspector]
        public string CodeSignIdentityValue { set; get; } = string.Empty;
    }
}
