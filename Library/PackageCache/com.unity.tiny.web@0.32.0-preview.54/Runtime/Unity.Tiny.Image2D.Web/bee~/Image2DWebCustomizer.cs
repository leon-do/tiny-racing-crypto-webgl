using JetBrains.Annotations;
using Bee.Toolchain.Emscripten;
using System;

[UsedImplicitly]
class CustomizerForImage2DWeb : AsmDefCSharpProgramCustomizer
{
    public override string CustomizerFor => "Unity.Tiny.Image2D.Web";

    public override string[] ImplementationFor => new [] { "Unity.Tiny.Image2D" };

    public override void CustomizeSelf(AsmDefCSharpProgram program)
    {
        NiceIO.NPath path = program.MainSourcePath.Combine("external/libwebp.js");
        program.NativeProgram.Libraries.Add(c => ((DotsRuntimeNativeProgramConfiguration)c).CSharpConfig.PlatformBuildConfig is WebBuildConfig, new PostJsLibrary(path));
    }
}
