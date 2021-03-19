using System.Diagnostics;
using System.IO;
using System.Threading;
using Unity.Build;
using Unity.Build.Internals;
using Unity.Build.DotsRuntime;
using Debug = UnityEngine.Debug;

namespace Unity.Build.Desktop.DotsRuntime
{
    public class DesktopRun
    {
        // This will almost certainly be a single string built from an unhandled exception,
        // but the default handling will emit an event PER LINE. So we will concatenate the
        // lines to a single, usable, actual error message.
        private string StandardErrorString;
        
        public DesktopRun()
        {
        }
        
        private void WaitForProcess(Process process)
        {
            // This has to be called to start async. redirection of standard error
            process.BeginErrorReadLine();
            
            process.WaitForExit();

            if (!string.IsNullOrEmpty(StandardErrorString))
            {
                Debug.LogFormat(UnityEngine.LogType.Error, UnityEngine.LogOption.NoStacktrace, null, StandardErrorString);
            }
        }

        public bool RunOnThread(ProcessStartInfo startInfo)
        {
            startInfo.CreateNoWindow = true;
            
            // This should always remain false because the means of redirection
            // only reads one line at a time and there isn't any consistent and generic way
            // to detect the start AND end of a log.
            startInfo.RedirectStandardOutput = false;
            
            // This should be true because otherwise we won't catch unhandled exceptions.
            // However, the same issue exists as with RedirectStandardOutput, though
            // an unhandled exception is a crash anyway, so we can build the string from
            // and emit it finally when the process exits.
            startInfo.RedirectStandardError = true;

            // This should remain false in order to support RedirectStandardError.
            startInfo.UseShellExecute = false;

            var process = new Process();
            process.StartInfo = startInfo;
            process.EnableRaisingEvents = true;
            process.ErrorDataReceived += (_, args) =>
            {
                if (args.Data != null)
                {
                    if (!string.IsNullOrEmpty(StandardErrorString))
                        StandardErrorString += "\n";
                    StandardErrorString += args.Data;
                }
            };

            var success = process.Start();
            if (!success)
                return false;

            new Thread(() => { WaitForProcess(process); }).Start();
            
            return true;
        }

        internal static ShellProcessOutput RunTestMode(ShellProcessArguments shellArgs, string workingDirPath, int timeout)
        {
            shellArgs.WorkingDirectory = new DirectoryInfo(workingDirPath);
            shellArgs.ThrowOnError = false;

            // samples should be killed on timeout
            if (timeout > 0)
            {
                shellArgs.MaxIdleTimeInMilliseconds = timeout;
                shellArgs.MaxIdleKillIsAnError = false;
            }

            return ShellProcess.Run(shellArgs);
        }
    }        
}

