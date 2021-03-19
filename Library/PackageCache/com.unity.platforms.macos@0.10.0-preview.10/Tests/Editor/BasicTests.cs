using NUnit.Framework;
using Unity.Build.MacOS.DotsRuntime;

class BasicTests
{
    [Test]
    public void VerifyCanReferenceMacOSBuildTarget()
    {
        Assert.IsNotNull(typeof(MacOSBuildTarget));
    }
}
