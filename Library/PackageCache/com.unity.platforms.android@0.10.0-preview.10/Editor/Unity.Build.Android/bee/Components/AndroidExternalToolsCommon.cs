using Unity.Properties;

namespace Unity.Build.Android
{
    internal sealed partial class AndroidExternalTools
    {
        string m_JavaPath;
        string m_SdkPath;
        string m_NdkPath;
        string m_GradlePath;

        [CreateProperty]
        public string JavaPath
        {
            get => !string.IsNullOrEmpty(m_JavaPath) ? m_JavaPath : AndroidTools.JdkRootPath;
            set => m_JavaPath = value;
        }

        [CreateProperty]
        public string SdkPath
        {
            get => !string.IsNullOrEmpty(m_SdkPath) ? m_SdkPath : AndroidTools.SdkRootPath;
            set => m_SdkPath = value;
        }

        [CreateProperty]
        public string NdkPath
        {
            get => !string.IsNullOrEmpty(m_NdkPath) ? m_NdkPath : AndroidTools.NdkRootPath;
            set => m_NdkPath = value;
        }

        [CreateProperty]
        public string GradlePath
        {
            get => !string.IsNullOrEmpty(m_GradlePath) ? m_GradlePath : AndroidTools.GradlePath;
            set => m_GradlePath = value;
        }

        public AndroidExternalTools()
        {
            m_JavaPath = AndroidTools.JdkRootPath;
            m_SdkPath = AndroidTools.SdkRootPath;
            m_NdkPath = AndroidTools.NdkRootPath;
            m_GradlePath = AndroidTools.GradlePath;
        }
    }
}

