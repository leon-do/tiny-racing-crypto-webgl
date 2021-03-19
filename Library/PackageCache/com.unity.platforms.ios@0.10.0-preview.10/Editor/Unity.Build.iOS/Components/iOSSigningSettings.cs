using Unity.Build.Bridge;
using Unity.Serialization;
using UnityEngine;

namespace Unity.Build.iOS
{
    internal sealed partial class iOSSigningSettings : IBuildComponent
    {
        public void UpdateCodeSignIdentityValue()
        {
            var localProvisioningProfile = ProvisioningProfileBridge.FindLocalProfileByUUID(ProfileID);

            var provisioningProfileType = ProfileType;
            if (provisioningProfileType == ProvisioningProfileType.Automatic)
            {
                if (localProvisioningProfile != null)
                    provisioningProfileType = (ProvisioningProfileType)localProvisioningProfile.type;
                else
                    provisioningProfileType = ProvisioningProfileType.Development;
            }
            else if (localProvisioningProfile != null && provisioningProfileType != (ProvisioningProfileType)localProvisioningProfile.type)
            {
                Debug.LogWarning(
                    $@"The locally available provisioning profile {ProfileID} uses a {localProvisioningProfile.type} certificate, but it's type is set to {provisioningProfileType} in iOS Signing Settings component.
Please make sure that the correct type is set or change it to Automatic.");
            }

            // Code sign should be set to "iPhone {type}" even when building for Apple TV, for example:
            // CODE_SIGN_IDENTITY[sdk=appletvos*]" = "iPhone Distribution".
            string typeStr = (provisioningProfileType == ProvisioningProfileType.Distribution) ? "Distribution" : "Developer";
            CodeSignIdentityValue = $"iPhone {typeStr}";
        }
    }
}
