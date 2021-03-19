using System;
using System.IO;
using System.Linq;

namespace Unity.Build.Android
{
    internal sealed class AndroidUtils
    {
        private static Type AndroidUtilsClass { get; set; }

        static AndroidUtils()
        {
            AndroidUtilsClass =
                (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                 from type in assembly.GetTypes()
                 where type.FullName == "UnityEditor.Android.Utils"
                 select type).FirstOrDefault();
        }

        public static string[] GetAvailableSigningKeyAlias(string keystore, string storepass, bool browse = false)
        {
            if (AndroidUtilsClass == default(Type))
            {
                return null;
            }
            var methodInfo = AndroidUtilsClass.GetMethod("GetAvailableSigningKeyAlias", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public);
            if (methodInfo == null)
            {
                return null;
            }
            var getMethod = (Func<string, string, bool, string[]>)Delegate.CreateDelegate(typeof(Func<string, string, bool, string[]>), null, methodInfo);
            return getMethod(keystore, storepass, browse);
        }
    }
}
