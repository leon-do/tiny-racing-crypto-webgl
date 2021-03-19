using System;
using System.Collections.Generic;
using Unity.Properties.UI;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Unity.Build.Android
{
    sealed class AndroidKeystoreInspector : Inspector<AndroidKeystore>
    {
        VisualElement m_Root;
        TextField m_KeystoreFullPath;
        TextField m_KeystorePass;
        VisualElement m_KeyaliasInfo;

        public override VisualElement Build()
        {
            m_Root = new VisualElement();
            var keystoreBrowse = new Button(OnBrowse)
            {
                text = "Browse"
            };
            m_Root.Add(keystoreBrowse);
            DoDefaultGui(m_Root, nameof(AndroidKeystore.KeystoreFullPath));
            DoDefaultGui(m_Root, nameof(AndroidKeystore.KeystorePass));
            m_KeystoreFullPath = m_Root.Q<TextField>(nameof(AndroidKeystore.KeystoreFullPath));
            m_KeystorePass = m_Root.Q<TextField>(nameof(AndroidKeystore.KeystorePass));
            m_KeystorePass.isPasswordField = true;
            m_KeystorePass.RegisterValueChangedCallback(evt => ResetAliasInfo());
            ResetAliasInfo();

            return m_Root;
        }

        private void ResetAliasInfo()
        {
            string[] aliases = null;
            var isBadPass = false;
            if (!string.IsNullOrEmpty(m_KeystoreFullPath.value))
            {
                try
                {
                    aliases = AndroidUtils.GetAvailableSigningKeyAlias(m_KeystoreFullPath.value, m_KeystorePass.value);
                }
                catch (Exception)
                {
                    isBadPass = true;
                }
            }

            if (aliases == null)
            {
                aliases = new []{""};
            }
            if (m_KeyaliasInfo != null)
            {
                m_Root.Remove(m_KeyaliasInfo);
            }
            m_KeyaliasInfo = new VisualElement();
            if (isBadPass)
            {
                var badPass = new TextElement()
                {
                    text = "Wrong password for this keystore"
                };
                m_KeyaliasInfo.Add(badPass);
            }
            var index = Array.IndexOf(aliases, Target.KeyaliasName);
            if (index == -1)
            {
                if (Target.KeyaliasName != aliases[0])
                {
                    Target.KeyaliasName = aliases[0];
                    NotifyChanged();
                }
                index = 0;
            }
            var keyaliasName = new PopupField<string>("Keyalias Name", new List<string>(aliases), index,
                val =>
                {
                    if (Target.KeyaliasName != val)
                    {
                        Target.KeyaliasName = val;
                        NotifyChanged();
                    }
                    return val;
                });
            m_KeyaliasInfo.Add(keyaliasName);
            DoDefaultGui(m_KeyaliasInfo, nameof(AndroidKeystore.KeyaliasPass));
            var keyaliasPass = m_KeyaliasInfo.Q<TextField>(nameof(AndroidKeystore.KeyaliasPass));
            keyaliasPass.isPasswordField = true;
            m_Root.Add(m_KeyaliasInfo);
        }

        private void OnBrowse()
        {
            var keystorePath = Browse("");
            if (keystorePath != null)
            {
                m_KeystoreFullPath.value = keystorePath;
                ResetAliasInfo();
            }
        }

        private string Browse(string path)
        {
            var msg = "Open existing keystore...";
            var defaultFolder = path;

            path = EditorUtility.OpenFilePanel(msg, defaultFolder, "keystore");
            // user pressed cancel?
            if (path.Length == 0)
            {
                return null;
            }
            return path;
        }

    }
}
