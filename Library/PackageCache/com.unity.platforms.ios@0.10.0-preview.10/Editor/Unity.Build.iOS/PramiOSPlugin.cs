using System.Collections.Generic;
using System.IO;
using Unity.Build.Internals;

namespace Unity.Build.iOS
{
    sealed class PramiOSPlugin : PramPlatformPlugin
    {
        public override string[] Providers { get; } = {"appledevice"};
        public override string PlatformAssemblyLoadPath
        {
            get { return Path.GetFullPath("Packages/com.unity.platforms.ios/Editor/Unity.Build.iOS/pram~"); }
        }

        public override IReadOnlyDictionary<string, string> Environment { get; } = new Dictionary<string, string> ();
    }
}
