using NUnit.Framework;
using Unity.Build.Web.DotsRuntime;

class BasicTests
{
    [Test]
    public void VerifyCanReferenceWebBuildTarget()
    {
        Assert.IsNotNull(typeof(WebBuildTarget));
    }
}
