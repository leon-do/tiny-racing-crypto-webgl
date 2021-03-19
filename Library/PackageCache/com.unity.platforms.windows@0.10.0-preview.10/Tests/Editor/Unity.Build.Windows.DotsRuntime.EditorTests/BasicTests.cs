using NUnit.Framework;
using Unity.Build.Windows.DotsRuntime;

class BasicTests
{
    [Test]
    public void VerifyCanReferenceWindowsBuildTarget()
    {
        Assert.IsNotNull(typeof(WindowsBuildTarget));
    }
}
