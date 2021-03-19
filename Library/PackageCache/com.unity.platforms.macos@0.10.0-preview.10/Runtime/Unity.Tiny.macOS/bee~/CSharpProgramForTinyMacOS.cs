using Bee.Toolchain.Xcode;
using JetBrains.Annotations;

using Bee.NativeProgramSupport;
using Bee.Core;

[UsedImplicitly]
class CustomizerForTinyMacOS: AsmDefCSharpProgramCustomizer
{
    public override string CustomizerFor => "Unity.Platforms.Common";

    public override void CustomizeSelf(AsmDefCSharpProgram program)
    {
        program.NativeProgram.Libraries.Add(c =>
            ((DotsRuntimeNativeProgramConfiguration) c).CSharpConfig.EnableManagedDebugging &&
            ((DotsRuntimeNativeProgramConfiguration) c).CSharpConfig.WaitForManagedDebugger &&
            c.Platform is MacOSXPlatform, new SystemFramework("CoreFoundation"));
    }
}
