using System.IO;

namespace Unity.Build.macOS.Classic
{
    sealed class MacOSArtifact : IBuildArtifact
    {
        public FileInfo OutputTargetFile;
    }
}
