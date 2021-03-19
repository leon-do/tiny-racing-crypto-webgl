using NUnit.Framework;
using Unity.Build.Android.DotsRuntime;

class BasicTests
{
    [Test]
    public void VerifyCanReferenceAndroidBuildTarget()
    {
        Assert.IsNotNull(typeof(AndroidBuildTarget));
    }
}
