using System.IO;

namespace Unity.Build.Android.Classic
{
    sealed class AndroidProjectArtifact : IBuildArtifact
    {
        public DirectoryInfo ProjectDirectory;
    }
}
