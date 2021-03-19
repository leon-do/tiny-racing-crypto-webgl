using NUnit.Framework;
using Unity.Build.Linux.DotsRuntime;

class BasicTests
{
    [Test]
    public void VerifyCanReferenceLinuxBuildTarget()
    {
        Assert.IsNotNull(typeof(LinuxBuildTarget));
    }
}
