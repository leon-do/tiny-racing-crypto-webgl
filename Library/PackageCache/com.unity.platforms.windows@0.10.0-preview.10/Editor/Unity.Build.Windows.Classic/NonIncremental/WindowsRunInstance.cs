using System.Diagnostics;

namespace Unity.Build.Windows.Classic
{
    sealed class WindowsRunInstance : IRunInstance
    {
        readonly Process m_Process;

        public bool IsRunning => !m_Process.HasExited;

        public WindowsRunInstance(Process process)
        {
            m_Process = process;
        }

        public void Dispose()
        {
            m_Process.Dispose();
        }

        public static RunResult Create(RunContext context)
        {
            var artifact = context.GetBuildArtifact<WindowsArtifact>();
            var process = new Process();
            process.StartInfo.FileName = artifact.OutputTargetFile.FullName;
            process.StartInfo.WorkingDirectory = artifact.OutputTargetFile.Directory?.FullName ?? string.Empty;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.UseShellExecute = true;

            if (!process.Start())
            {
                return context.Failure($"Failed to start process at '{process.StartInfo.FileName}'.");
            }

            return context.Success(new WindowsRunInstance(process));
        }
    }
}
