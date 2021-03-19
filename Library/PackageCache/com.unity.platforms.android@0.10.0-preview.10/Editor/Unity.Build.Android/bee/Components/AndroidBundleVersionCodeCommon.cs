using System;
using Unity.Properties;

namespace Unity.Build.Android
{
    internal sealed partial class AndroidBundleVersionCode
    {
        const int MaxVersionCode = 2100000000;
        int m_VersionCode = 1;

        [CreateProperty]
        public int VersionCode
        {
            set
            {
                m_VersionCode = Math.Min(value, MaxVersionCode);
            }
            get
            {
                return m_VersionCode;
            }
        }
    }
}
