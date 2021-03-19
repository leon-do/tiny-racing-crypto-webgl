using System.Diagnostics;

namespace Unity.Build.Linux.Classic
{
    sealed class LinuxRunInstance : IRunInstance
    {
        Process m_Process;

        public bool IsRunning => !m_Process.HasExited;

        public LinuxRunInstance(Process process)
        {
            m_Process = process;
        }

        public void Dispose()
        {
            m_Process.Dispose();
        }

        public static RunResult Create(RunContext context)
        {
            var artifact = context.GetBuildArtifact<LinuxArtifact>();
            var process = new Process
            {
                StartInfo =
                {
                    FileName = artifact.OutputTargetFile.FullName,
                    WorkingDirectory = artifact.OutputTargetFile.Directory?.FullName ?? string.Empty,
                    CreateNoWindow = true,
                    UseShellExecute = true
                }
            };

            if (!process.Start())
            {
                return context.Failure($"Failed to start process at '{process.StartInfo.FileName}'.");
            }

            return context.Success(new LinuxRunInstance(process));
        }
    }
}
