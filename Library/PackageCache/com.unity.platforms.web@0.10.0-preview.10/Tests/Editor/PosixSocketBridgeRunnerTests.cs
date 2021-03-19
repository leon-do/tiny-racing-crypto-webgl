using System.Diagnostics;
using System.Threading;
using NUnit.Framework;
using Unity.Build.Web.DotsRuntime;

[Ignore("These tests can't run in the dots-platforms repo because it cannot extract the Emscripten package from Stevedore to get to the proxy bridge executable.")]
public class PosixSocketBridgeRunnerTests
{
    [TearDown]
    public void TearDown()
    {
        PosixSocketBridgeRunner.StopRunning();
    }

    [Test]
    public void EnsureRunningStartsTheProxyBridge()
    {
        PosixSocketBridgeRunner.EnsureRunning();

        var posixSocketBridgeProcesses = Process.GetProcessesByName("websocket_to_posix_proxy");

        Assert.That(posixSocketBridgeProcesses.Length, Is.EqualTo(1), "The proxy bridge was not started, which is not expected.");
    }

    [Test]
    public void EnsureRunningOnlyStartsOneProxyBridgeWhenCalledMoreThanOnce()
    {
        PosixSocketBridgeRunner.EnsureRunning();
        PosixSocketBridgeRunner.EnsureRunning();
        PosixSocketBridgeRunner.EnsureRunning();

        var posixSocketBridgeProcesses = Process.GetProcessesByName("websocket_to_posix_proxy");

        Assert.That(posixSocketBridgeProcesses.Length, Is.EqualTo(1), "Only one proxy bridge was not started, which is not expected.");
    }

    [Test]
    public void TheProxyBridgeIsRestartedIfItIsKilled()
    {
        PosixSocketBridgeRunner.EnsureRunning();

        var posixSocketBridgeProcesses = Process.GetProcessesByName("websocket_to_posix_proxy");
        posixSocketBridgeProcesses[0].Kill();
        posixSocketBridgeProcesses[0].WaitForExit();

        Thread.Sleep(500);

        posixSocketBridgeProcesses = Process.GetProcessesByName("websocket_to_posix_proxy");

        Assert.That(posixSocketBridgeProcesses.Length, Is.EqualTo(1),
            "The proxy bridge was not restarted, which is not expected.");
    }

    [Test]
    public void StopRunningStopsTheProxyBridge()
    {
        PosixSocketBridgeRunner.EnsureRunning();

        var posixSocketBridgeProcesses = Process.GetProcessesByName("websocket_to_posix_proxy");

        PosixSocketBridgeRunner.StopRunning();

        posixSocketBridgeProcesses[0].Refresh();

        Assert.That(posixSocketBridgeProcesses[0].HasExited, "The proxy bridge did not exit, which is not expected.");
    }

}

