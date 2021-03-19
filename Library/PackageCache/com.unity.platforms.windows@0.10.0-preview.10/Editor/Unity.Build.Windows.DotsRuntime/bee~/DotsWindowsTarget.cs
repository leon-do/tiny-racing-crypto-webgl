using Bee.Toolchain.Windows;
using DotsBuildTargets;
using Bee.NativeProgramSupport;


abstract class DotsWindowsTarget : DotsBuildSystemTarget
{
    public override ToolChain ToolChain => new WindowsToolchain(WindowsSdk.Locatorx64.UserDefaultOrDummy);
}

class DotsWindowsDotNetTinyTarget : DotsWindowsTarget
{
    public override string Identifier => "windows-dotnet";

    public override ScriptingBackend ScriptingBackend => ScriptingBackend.Dotnet;

    public override bool CanUseBurst => true;
}

class DotsWindowsDotNetStandard20Target : DotsWindowsTarget
{
    public override string Identifier => "windows-dotnet-ns20";

    public override ScriptingBackend ScriptingBackend => ScriptingBackend.Dotnet;

    public override bool CanUseBurst => true;

    public override TargetFramework TargetFramework => TargetFramework.NetStandard20;
}

abstract class DotsWindows32Target : DotsBuildSystemTarget
{
    public override ToolChain ToolChain => new WindowsToolchain(WindowsSdk.Locatorx86.UserDefaultOrDummy);
}

class DotsWindows32DotNetTarget : DotsWindows32Target
{
    public override string Identifier => "windows32-dotnet";

    public override ScriptingBackend ScriptingBackend => ScriptingBackend.Dotnet;
    public override bool CanUseBurst => false;
}

class DotsWindowsIL2CPPTarget : DotsWindowsTarget
{
    public override string Identifier => "windows-il2cpp";
    public override bool CanUseBurst => true;
}
