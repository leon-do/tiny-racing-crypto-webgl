using DotsBuildTargets;

using Bee.NativeProgramSupport;
using Bee.Toolchain.MacOS;

abstract class DotsMacOSTarget : DotsBuildSystemTarget
{
    public override ToolChain ToolChain => new MacToolchain(MacSdk.Locatorx64.UserDefaultOrDummy);
    public override bool CanUseBurst => true;
}

class DotsMacOSDotNetTinyTarget : DotsMacOSTarget
{
    public override string Identifier => "macos-dotnet";

    public override ScriptingBackend ScriptingBackend => ScriptingBackend.Dotnet;

}

class DotsMacOSDotNetStandard20Target : DotsMacOSTarget
{
    public override string Identifier => "macos-dotnet-ns20";

    public override ScriptingBackend ScriptingBackend => ScriptingBackend.Dotnet;

    public override TargetFramework TargetFramework => TargetFramework.NetStandard20;
}

class DotsMacOSIL2CPPTarget : DotsMacOSTarget
{
    public override string Identifier => "macos-il2cpp";
}
