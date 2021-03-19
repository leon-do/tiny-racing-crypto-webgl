using System.Collections.Generic;
using Bee.Toolchain.GNU;
using Bee.Toolchain.Xcode;
using JetBrains.Annotations;
using Bee.NativeProgramSupport;
using Bee.Core;

[UsedImplicitly]
class CustomizerForTinyGLFW : AsmDefCSharpProgramCustomizer
{
    public override string CustomizerFor => "Unity.Tiny.GLFW";

    // not exactly right, but good enough for now
    public override string[] ImplementationFor => new[] {"Unity.Tiny.Rendering"};

    public override void CustomizeSelf(AsmDefCSharpProgram program)
    {
        if (program.MainSourcePath.FileName == "Unity.Tiny.GLFW")
        {
            External.GLFWStaticLibrary = External.SetupGLFW();
            program.NativeProgram.CompilerSettingsForMac().Add(c => c.WithObjcArc(false));
            program.NativeProgram.Libraries.Add(c => c.Platform is MacOSXPlatform, new List<string>
            {
                "Cocoa", "QuartzCore", "OpenGL", "Metal"
            }
            .ConvertAll(s => new SystemFramework(s)));

            program.NativeProgram.CompilerSettingsForIos().Add(c => c.WithObjcArc(false));

            program.NativeProgram.Libraries.Add(new NativeProgramAsLibrary(External.GLFWStaticLibrary){BuildMode = NativeProgramLibraryBuildMode.BagOfObjects});
        }
    }
}
