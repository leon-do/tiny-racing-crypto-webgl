using NUnit.Framework;
using Unity.Build.iOS.DotsRuntime;

class BasicTests
{
    [Test]
    public void VerifyCanReferenceiOSBuildTarget()
    {
        Assert.IsNotNull(typeof(iOSBuildTarget));
    }
}
