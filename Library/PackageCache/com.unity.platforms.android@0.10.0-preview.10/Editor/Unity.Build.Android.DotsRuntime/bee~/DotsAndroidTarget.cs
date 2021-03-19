using System;
using Bee.Toolchain.Android;
using Bee.Tools;
using DotsBuildTargets;
using Bee.NativeProgramSupport;

abstract class DotsAndroidTarget : DotsBuildSystemTarget
{
    protected const bool k_UseStatic = true;
    public override bool CanUseBurst { get; } = true;
}

class DotsAndroidTargetMain : DotsAndroidTarget
{
    public override string Identifier => "android_armv7";

    public override ToolChain ToolChain => AndroidApkToolchain.GetToolChain(k_UseStatic, true);

    public override DotsBuildSystemTarget ComplementaryTarget
    {
        get
        {
            var target = DotsAndroidTargetComplementary.GetInstance();
            return target.ToolChain != null ? target : null;
        }
    }

    public override bool ValidateManagedDebugging(ref bool mdb)
    {
        if (mdb && ComplementaryTarget != null)
        {
            Errors.PrintError(@"Managed Debugging is disabled on fat (armv7/arm64) Android builds.
To use Managed Debugging enable single architecture in AndroidArchitectures component.
To build fat Android APK use Release Configuration or explicitly disable Scripts Debugging (using IL2CPP Setting component).");
            return false;
        }
        return true;
    }
}

internal class DotsAndroidTargetComplementary : DotsAndroidTarget
{
    public override string Identifier => "android_complementary";

    public override ToolChain ToolChain => AndroidApkToolchain.GetToolChain(k_UseStatic, false);

    public static DotsAndroidTargetComplementary GetInstance()
    {
        if (m_Instance == null)
        {
            m_Instance = new DotsAndroidTargetComplementary();
        }
        return m_Instance;
    }
    private static DotsAndroidTargetComplementary m_Instance = null;
}
