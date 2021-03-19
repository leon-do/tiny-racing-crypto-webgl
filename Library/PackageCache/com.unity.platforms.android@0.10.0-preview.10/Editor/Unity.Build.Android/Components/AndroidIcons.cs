using Unity.Build.Classic;
using Unity.Properties;
using Unity.Serialization;
using UnityEditor;

namespace Unity.Build.Android
{
    internal sealed partial class AndroidIcons : IBuildComponent
    {
        public static readonly int[] kSize =
        {
            108, //mdpi
            162, //hdpi
            216, //xhdpi
            324, //xxhdpi
            432 //xxxhdpi
        };

        public static readonly int[] kLegacySize =
        {
            48,  //mdpi
            72,  //hdpi
            96,  //xhdpi
            144, //xxhdpi
            192 //xxxhdpi
        };

        public AndroidIcons()
        {
            for (int i = 0; i < Icons.Length; ++i)
            {
                Icons[i] = new IconsSet();
            }
        }
    }
}
