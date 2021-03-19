using System;
using System.IO;
using System.Linq;

namespace Unity.Build.Android
{
    internal sealed class AndroidTools
    {
        private static Type AndroidExternalToolsSettings { get; set; }

        static AndroidTools()
        {
            AndroidExternalToolsSettings =
                (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                 from type in assembly.GetTypes()
                 where type.Name == "AndroidExternalToolsSettings"
                 select type).FirstOrDefault();
        }

        private static string GetProperty(string name)
        {
            if (AndroidExternalToolsSettings == default(Type))
            {
                return null;
            }
            var property = AndroidExternalToolsSettings.GetProperty(name);
            return property?.GetValue(null) as string;
        }

        public static string SdkRootPath => GetProperty("sdkRootPath");
        public static string NdkRootPath => GetProperty("ndkRootPath");
        public static string JdkRootPath => GetProperty("jdkRootPath");
        public static string GradlePath => GetProperty("gradlePath");
    }
}