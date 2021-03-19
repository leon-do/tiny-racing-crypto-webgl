using Unity.Properties;

namespace Unity.Build.Android
{
    internal sealed partial class AndroidKeystore
    {
        // Android keystore name
        public string KeystoreFullPath = string.Empty;

        // Android keystore password
        public string KeystorePass = string.Empty;

        // Android key alias name
        public string KeyaliasName = string.Empty;

        // Android key alias password
        public string KeyaliasPass = string.Empty;

        internal string GetSigningConfig(bool useCustom)
        {
            return $"signingConfig signingConfigs.{(useCustom ? "release" : "debug")}";
        }

        internal string GetSigningConfigs(bool useCustom)
        {
            if (!useCustom)
            {
                return string.Empty;
            }

            var keystore = KeystoreFullPath;
            // Use forward slashes in the paths in build.gradle
            keystore = keystore.Replace('\\', '/');

            var keyData = $@"
            storeFile file('{EscapeString(keystore)}')
            storePassword '{EscapeString(KeystorePass)}'
            keyAlias '{EscapeString(KeyaliasName)}'
            keyPassword '{EscapeString(KeyaliasPass)}'";

            // TODO need to set signerVersionConfig to "\n\t\tv2SigningEnabled false" for Oculus.
            var signerVersionConfig = "";

            return @"
    signingConfigs {
        release {" + keyData + signerVersionConfig + @"
        }
    }";
        }

        private string EscapeString(string pass)
        {
            // Escape any illegal gradle characters
            return pass.Replace("\\", "\\\\").Replace("'", "\\'");
        }
        
    }
}
