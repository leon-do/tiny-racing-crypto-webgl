using Bee.Toolchain.IOS;
using DotsBuildTargets;
using Bee.NativeProgramSupport;

class DotsIOSTarget : DotsBuildSystemTarget
{
    protected override NativeProgramFormat GetExecutableFormatForConfig(DotsConfiguration config, bool enableManagedDebugger)
    {
        return new IOSAppMainModuleFormat(ToolChain as IOSAppToolchain);
    }

    public override string Identifier => "ios";

    public override ToolChain ToolChain => IOSAppToolchain.GetIOSAppToolchain(true);

    //TODO should return true once burst supports iOS simulator 
    public override bool CanUseBurst => ToolChain.Architecture.IsArm64;
}
