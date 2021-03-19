using System;
using Unity.Build.Bridge;
using Unity.Properties.UI;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Unity.Build.iOS
{
    sealed class iOSSigningSettingsInspector : Inspector<iOSSigningSettings>
    {
        VisualElement m_ProvisioningProfile;
        Toggle m_AutomaticallySign;
        TextField m_ProvisioningProfileUUID;
        EnumField m_ProvisioningProfileType;

        public override VisualElement Build()
        {
            var root = new VisualElement();
            DoDefaultGui(root, nameof(iOSSigningSettings.SigningTeamID));
            DoDefaultGui(root, nameof(iOSSigningSettings.AutomaticallySign));

            m_ProvisioningProfile = new VisualElement();
            var provisioningProfileHeader = new TextElement();
            provisioningProfileHeader.text = "iOS Provisioning Profile";
            m_ProvisioningProfile.Add(provisioningProfileHeader);
            var provisioningProfileBrowse = new Button(OnBrowse)
            {
                text = "Browse"
            };
            m_ProvisioningProfile.Add(provisioningProfileBrowse);
            DoDefaultGui(m_ProvisioningProfile, nameof(iOSSigningSettings.ProfileID));
            DoDefaultGui(m_ProvisioningProfile, nameof(iOSSigningSettings.ProfileType));
            root.Add(m_ProvisioningProfile);
            m_ProvisioningProfileUUID = m_ProvisioningProfile.Q<TextField>(nameof(iOSSigningSettings.ProfileID));
            m_ProvisioningProfileType = m_ProvisioningProfile.Q<EnumField>(nameof(iOSSigningSettings.ProfileType));

            m_AutomaticallySign = root.Q<Toggle>(nameof(iOSSigningSettings.AutomaticallySign));

            return root;
        }

        public override void Update()
        {
            var style = m_AutomaticallySign.value ? DisplayStyle.None : DisplayStyle.Flex;
            m_ProvisioningProfile.style.display = style;
        }

        private void OnBrowse()
        {
            var provisioningProfile = Browse("");
            if (provisioningProfile != null && !string.IsNullOrEmpty(provisioningProfile.UUID))
            {
                m_ProvisioningProfileUUID.value = provisioningProfile.UUID;
                m_ProvisioningProfileType.value = (ProvisioningProfileType)provisioningProfile.type;
            }
        }

        private ProvisioningProfileBridge Browse(string path)
        {
            var msg = "Select the Provising Profile used for Manual Signing";
            var defaultFolder = path;

            ProvisioningProfileBridge provisioningProfile = null;
            do
            {
                path = EditorUtility.OpenFilePanel(msg, defaultFolder, "mobileprovision");

                // user pressed cancel?
                if (path.Length == 0)
                    return null;
            }
            while (!GetProvisioningProfileId(path, out provisioningProfile));

            return provisioningProfile;
        }

        private static bool GetProvisioningProfileId(string filePath, out ProvisioningProfileBridge provisioningProfile)
        {
            var profile = ProvisioningProfileBridge.ParseProvisioningProfileAtPath(filePath);
            provisioningProfile = profile;
            return profile.UUID != null;
        }
    }
}
