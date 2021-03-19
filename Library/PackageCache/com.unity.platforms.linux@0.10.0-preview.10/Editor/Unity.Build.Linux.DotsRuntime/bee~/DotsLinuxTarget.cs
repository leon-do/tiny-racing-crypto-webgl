using Bee.Toolchain.Linux;
using DotsBuildTargets;
using Bee.NativeProgramSupport;

abstract class DotsLinuxTarget : DotsBuildSystemTarget
{
    public override ToolChain ToolChain => new LinuxGccToolchain(LinuxGccSdk.Locatorx64.UserDefaultOrDummy);
    public override bool CanUseBurst => true;
}

class DotsLinuxDotNetTinyTarget : DotsLinuxTarget
{
    public override string Identifier => "linux-dotnet";

    public override ScriptingBackend ScriptingBackend => ScriptingBackend.Dotnet;
}

class DotsLinuxDotNetStandard20Target : DotsLinuxTarget
{
    public override string Identifier => "linux-dotnet-ns20";

    public override ScriptingBackend ScriptingBackend => ScriptingBackend.Dotnet;

    public override TargetFramework TargetFramework => TargetFramework.NetStandard20;
}

class DotsLinuxIL2CPPTarget : DotsLinuxTarget
{
    public override string Identifier => "linux-il2cpp";
}
