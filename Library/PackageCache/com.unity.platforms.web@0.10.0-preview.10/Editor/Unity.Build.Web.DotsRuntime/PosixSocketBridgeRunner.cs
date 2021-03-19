using System;
using System.Diagnostics;
using System.IO;
using System.Net.NetworkInformation;
using System.Threading;
using UnityEngine;
using Unity.Build.Internals;
using Unity.Build.DotsRuntime;

namespace Unity.Build.Web.DotsRuntime
{
    public static class PosixSocketBridgeRunner
    {
        private const string SocketBridgeExecutableMac = "Library/DotsRuntimeBuild/artifacts/Stevedore/emscripten-mac/websocket_to_posix_proxy";

        private const string SocketBridgeExecutableLinux = "Library/DotsRuntimeBuild/artifacts/Stevedore/emscripten-linux/websocket_to_posix_proxy";

        private const string SocketBridgeExecutableWindows = "Library/DotsRuntimeBuild/artifacts/Stevedore/emscripten-win/websocket_to_posix_proxy.exe";

        private static string SocketBridgeExecutable
        {
            get
            {
                var workingDirectory = Directory.GetCurrentDirectory();
                if (Application.platform == RuntimePlatform.OSXEditor)
                    return Path.Combine(workingDirectory, SocketBridgeExecutableMac);
                if (Application.platform == RuntimePlatform.LinuxEditor)
                    return Path.Combine(workingDirectory, SocketBridgeExecutableLinux);
                return Path.Combine(workingDirectory, SocketBridgeExecutableWindows);
            }
        }

        private static Thread _posixSocketBridgeThread;
        private static AutoResetEvent _proxyBridgeHasStarted = new AutoResetEvent(false);
        private static ManualResetEvent _proxyBridgeThreadHasEnded = new ManualResetEvent(false);
        private static AutoResetEvent _stopProxyBridge = new AutoResetEvent(false);
        private static int numberOfRestartTries = 0;
        private const int MaximumRestartTries = 5;

        public static void EnsureRunning()
        {
            if (!File.Exists(SocketBridgeExecutable))
            {
                UnityEngine.Debug.LogWarning($"Unable to start web debugger proxy bridge. The file '{Path.Combine(Directory.GetCurrentDirectory(), SocketBridgeExecutable)}' does not exist. Managed debugging for web builds will not be available.");
                return;
            }

            // Check if the thread ended without us knowing
            if (_posixSocketBridgeThread != null && _proxyBridgeThreadHasEnded.WaitOne(0))
            {
                _proxyBridgeThreadHasEnded.Reset();
                _posixSocketBridgeThread = null;
                numberOfRestartTries = 0;
            }

            if (_posixSocketBridgeThread == null)
            {
                _posixSocketBridgeThread = new Thread(PosixSocketBridgeRunThread);
                _posixSocketBridgeThread.Start();

                var indexOfSignaledEvent =
                    WaitHandle.WaitAny(new WaitHandle[] {_proxyBridgeHasStarted, _proxyBridgeThreadHasEnded});
                if (indexOfSignaledEvent == 1) // The thread exited
                {
                    UnityEngine.Debug.LogWarning($"Unable to start web debugger proxy bridge. Managed debugging for web builds will not be available.");
                    _posixSocketBridgeThread = null;
                }
            }
        }

        public static void StopRunning()
        {
            if (_posixSocketBridgeThread != null)
            {
                _stopProxyBridge.Set();
                _posixSocketBridgeThread.Join();
                _posixSocketBridgeThread = null;
            }
        }

        private static void PosixSocketBridgeRunThread()
        {
            try
            {
                var posixSocketBridgeProcess = StartPosixSocketBridgeProcess();
                _proxyBridgeHasStarted.Set();
                while (!_stopProxyBridge.WaitOne(100))
                {
                    if (posixSocketBridgeProcess.HasExited)
                    {
                        // If the proxy bridge exited with an expected error, e.g. it can't bind
                        // to a socket, don't try to start it again.
                        if (posixSocketBridgeProcess.ExitCode == 1)
                        {
                            UnityEngine.Debug.LogWarning(
                                "The proxy bridge required for managed debugging of web players has exited. It might be running already.");
                            break;
                        }

                        if (numberOfRestartTries < MaximumRestartTries)
                        {
                            UnityEngine.Debug.LogWarning(
                                "The proxy bridge required for managed debugging of web players has exited unexpectedly. Unity will try to restart it.");

                            // Restart the process if it exits
                            posixSocketBridgeProcess = StartPosixSocketBridgeProcess();
                            numberOfRestartTries++;
                        }
                        else
                        {
                            UnityEngine.Debug.LogWarning(
                                "The proxy bridge required for managed debugging of web players continues to exit unexpectedly. Unity will not try to restart it again.");
                            break;
                        }
                    }
                }

                try
                {
                    posixSocketBridgeProcess.Kill();
                    posixSocketBridgeProcess.WaitForExit();
                }
                catch (Exception)
                {
                    // We might get an exception trying to kill the process.
                    // Just eat it since the thread will exit anyway.
                }
            }
            finally
            {
                _proxyBridgeThreadHasEnded.Set();
            }
        }

        private static Process StartPosixSocketBridgeProcess()
        {
            var shellArgs = new ShellProcessArguments
            {
                Executable = SocketBridgeExecutable,
                Arguments = new [] {"6690"},
            };

            var posixSocketBridgeProcess = ShellProcess.Start(shellArgs);
            return posixSocketBridgeProcess.Process;
        }
    }
}
