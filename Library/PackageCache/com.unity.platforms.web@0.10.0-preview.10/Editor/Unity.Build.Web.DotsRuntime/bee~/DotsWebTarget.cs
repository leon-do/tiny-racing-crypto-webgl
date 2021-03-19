using Bee.Toolchain.Emscripten;
using Bee.Tools;
using System;
using System.Collections.Generic;
using DotsBuildTargets;
using Newtonsoft.Json.Linq;

using Bee.NativeProgramSupport;

class WebBuildConfig : IPlatformBuildConfig
{
    public bool SingleFile = false;
    public string WebTemplateFolder = "";
}

abstract class DotsWebTarget : DotsBuildSystemTarget
{
    public override bool CanUseBurst => true;

    protected abstract bool UseWasm { get; }

    protected abstract bool SupportsManagedDebugging { get; }

    protected override NativeProgramFormat GetExecutableFormatForConfig(DotsConfiguration config,
        bool enableManagedDebugger)
    {
        var format = new EmscriptenExecutableFormat(ToolChain, "html");

        switch (config)
        {
            case DotsConfiguration.Debug:
                return format.WithLinkerSetting<EmscriptenDynamicLinker>(d =>
                    TinyEmscripten.ConfigureEmscriptenLinkerFor(d,
                        "debug",
                        enableManagedDebugger));

            case DotsConfiguration.Develop:
                return format.WithLinkerSetting<EmscriptenDynamicLinker>(d =>
                    TinyEmscripten.ConfigureEmscriptenLinkerFor(d,
                        "develop",
                        enableManagedDebugger));

            case DotsConfiguration.Release:
                return format.WithLinkerSetting<EmscriptenDynamicLinker>(d =>
                    TinyEmscripten.ConfigureEmscriptenLinkerFor(d,
                        "release",
                        enableManagedDebugger));

            default:
                throw new NotImplementedException("Unknown config: " + config);
        }
    }

    public override DotsRuntimeCSharpProgramConfiguration CustomizeConfigForSettings(DotsRuntimeCSharpProgramConfiguration config, FriendlyJObject settings)
    {
        var executableFormat = GetExecutableFormatForConfig(DotsConfigs.DotsConfigForSettings(settings, out _),
                SupportsManagedDebugging && config.EnableManagedDebugging)
            .WithLinkerSetting<EmscriptenDynamicLinker>(e => e
                .WithCustomFlags_workaround(new[] { "-s", "TOTAL_STACK=" + (settings.GetString("WasmStackSize") ?? "512KB")})
                .WithCustomFlags_workaround(new[] { "-s", "TOTAL_MEMORY=" + (settings.GetString("WasmMemorySize") ?? "128MB")})
                .WithCustomFlags_workaround(new[] { "-s", "ALLOW_MEMORY_GROWTH=" + (settings.GetBool("AllowWasmMemoryGrowth")?"1":"0")})
                .WithCustomFlags_workaround(new[] { "-s", "MINIFY_HTML=" + (settings.GetBool("MinifyHTMLFile")?"1":"0")})
                .WithCustomFlags_workaround(settings.GetBool("MinifyOutputWithClosure") ? new[] {
                    "--closure-args", "\"--platform native --externs " + BuildProgram.BeeRoot.Combine("closure_externs.js").ToString() + "\"",
                    "--closure", "1", "-s", "CLOSURE_WARNINGS=warn"
                } : new[] {""})
                .WithCustomFlags_workaround(new[] { settings.GetBool("EmbedCpuProfiler")?"--cpuprofiler":""})
                .WithCustomFlags_workaround(new[] { settings.GetBool("EmbedMemoryProfiler")?"--memoryprofiler":""})
                .WithCustomFlags_workaround(new[] { settings.GetBool("IncludeSymbolsForBrowserCallstacks")?"--profiling-funcs":""})
                .WithCustomFlags_workaround(new[] { "-s", "ASSERTIONS=" + (settings.GetBool("EmitRuntimeAllocationDebugChecks")?"2":(settings.GetBool("EmitRuntimeMemoryDebugChecks")?"1":"0"))})
                .WithCustomFlags_workaround(new[] { "-s", "SAFE_HEAP=" + (settings.GetBool("EmitRuntimeMemoryDebugChecks")?"1":"0")})
                .WithSingleFile(settings.GetBool("SingleFile"))
                // Specify extra EmscriptenCmdLine overrides last so they can override previous settings.
                .WithCustomFlags_workaround(new[] { settings.GetString("EmscriptenCmdLine") ?? "" })
            );
        config.NativeProgramConfiguration = new DotsRuntimeNativeProgramConfiguration(
            config.NativeProgramConfiguration.CodeGen,
            config.NativeProgramConfiguration.ToolChain,
            config.Identifier,
            config,
            executableFormat: executableFormat);
        config.PlatformBuildConfig = new WebBuildConfig
        {
            SingleFile = settings.GetBool("SingleFile"),
            WebTemplateFolder = settings.GetString("WebTemplateFolder"),
        };
        return config;
    }

    public override bool ValidateManagedDebugging(ref bool mdb)
    {
        if (mdb)
        {
            Errors.PrintWarning("Warning: Managed Debugging is disabled on WASM and ASM-JS builds.");
            mdb = false;
        }
        return true;
    }
}

class DotsAsmJSTarget : DotsWebTarget
{
    protected override bool UseWasm => false;

    public override string Identifier => "asmjs";

    public override ToolChain ToolChain => TinyEmscripten.ToolChain_AsmJS;

    // Wasm2JS does not support pthreads, so the asmjs build cannot support managed debugging.
    protected override bool SupportsManagedDebugging => false;
}

class DotsWasmTarget : DotsWebTarget
{
    protected override bool UseWasm => true;

    public override string Identifier => "wasm";

    public override ToolChain ToolChain => TinyEmscripten.ToolChain_Wasm;

    protected override bool SupportsManagedDebugging => true;
}
