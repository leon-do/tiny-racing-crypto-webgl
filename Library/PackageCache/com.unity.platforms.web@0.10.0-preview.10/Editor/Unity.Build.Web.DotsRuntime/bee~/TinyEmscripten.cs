using System;
using System.Collections.Generic;
using Bee.Toolchain.Emscripten;
using Bee.Tools;
using NiceIO;
using Bee.Core.Stevedore;

using Bee.NativeProgramSupport;
using Bee.Core;

internal static class TinyEmscripten
{
    public static ToolChain ToolChain_AsmJS { get; } = MakeEmscripten(new AsmJsArchitecture());

    public static ToolChain ToolChain_Wasm { get; } = MakeEmscripten(new WasmArchitecture());

    public static NPath NodeExe;

    // If this boolean is set to true, the new upstream Wasm backend is used for Wasm codegen.
    // If false, the older Emscripten "fastcomp" backend will be used.
    // This option is provided for a transitional period to enable flipping between the two backends for
    // profiling and debugging purposes.
    public static bool UseWasmBackend => true;

    // If set to true, Closure compiler minification is enabled for the code in release builds. If false,
    // weaker UglifyJS based minification is used instead. TODO: enable this by default.
    public static bool EnableClosureCompiler => false;

    // Returns the naming scheme for OS component for Emscripten packages hosted on artifactory
    public static string EmscriptenPackageOSName()
    {
        if (HostPlatform.IsWindows) return "win";
        if (HostPlatform.IsLinux) return "linux";
        if (HostPlatform.IsOSX) return "mac";
        throw new Exception("Emscripten build support only works from Windows, Linux or macOS hosts!");
    }

    public static EmscriptenToolchain MakeEmscripten(EmscriptenArchitecture arch)
    {
        var emscripten = new StevedoreArtifact("emscripten-" + EmscriptenPackageOSName());
        var llvm = new StevedoreArtifact("emscripten-" + (UseWasmBackend ? "wasm" : "fc") + "-llvm-" + EmscriptenPackageOSName());
        var emscriptenVersion = new Version(1, 39, 17);

        emscripten.GenerateUnusualPath();
        var emscriptenRoot = emscripten.GetUnusualPath();

        var llvmPath = llvm.Path.ResolveWithFileSystem();

        EmscriptenSdk sdk = null;

        if (Environment.GetEnvironmentVariable("EMSDK") != null)
        {
            Console.WriteLine("Using pre-set environment EMSDK=" + Environment.GetEnvironmentVariable("EMSDK") +
                              ". This should only be used for local development. Unset EMSDK env. variable to use tagged Emscripten version from Stevedore.");
            NodeExe = Environment.GetEnvironmentVariable("EMSDK_NODE");
            sdk = new EmscriptenSdk(
                Environment.GetEnvironmentVariable("EMSCRIPTEN"),
                llvmRoot: Environment.GetEnvironmentVariable("LLVM_ROOT"),
                pythonExe: Environment.GetEnvironmentVariable("EMSDK_PYTHON"),
                nodeExe: NodeExe,
                architecture: arch,
                // Use a dummy/hardcoded version string to represent Emscripten "incoming" branch (it should be always considered
                // a "dirty" branch that does not correspond to any tagged release)
                version: new Version(9, 9, 9),
                isDownloadable: false
            );
        }
        else if (HostPlatform.IsWindows)
        {
            var python = new StevedoreArtifact("winpython2-x64");
            var node = new StevedoreArtifact("node-win-x64");

            node.GenerateUnusualPath();
            NodeExe = node.GetUnusualPath().Combine("node.exe");

            var pythonPath = python.Path.Combine("WinPython-64bit-2.7.13.1Zero/python-2.7.13.amd64/python.exe").ResolveWithFileSystem();

            sdk = new EmscriptenSdk(
                emscriptenRoot,
                llvmRoot: llvmPath,
                pythonExe: pythonPath,
                nodeExe: NodeExe,
                architecture: arch,
                version: emscriptenVersion,
                isDownloadable: true
                );
        }
        else if (HostPlatform.IsLinux)
        {
            var node = new StevedoreArtifact("node-linux-x64");

            node.GenerateUnusualPath();
            NodeExe = node.GetUnusualPath().Combine("bin/node");

            sdk = new EmscriptenSdk(
                emscriptenRoot,
                llvmRoot: llvmPath,
                pythonExe: "/usr/bin/python2",
                nodeExe: NodeExe,
                architecture: arch,
                version: emscriptenVersion,
                isDownloadable: true
                );
        }
        else if (HostPlatform.IsOSX)
        {
            var node = new StevedoreArtifact("node-mac-x64");

            node.GenerateUnusualPath();
            NodeExe = node.GetUnusualPath().Combine("bin/node");

            sdk = new EmscriptenSdk(
                emscriptenRoot: emscriptenRoot,
                llvmRoot: llvmPath,
                pythonExe: "/usr/bin/python",
                nodeExe: NodeExe,
                architecture: arch,
                version: emscriptenVersion,
                isDownloadable: true
                );
        }

        if (sdk == null)
            return null;

        // All Emsdk components are already pre-setup, so no need to verify the environment.
        // This avoids issues reported in https://github.com/emscripten-core/emscripten/issues/5042
        // (macOS Java check dialog popping up and slight slowdown in compiler invocation times)
        // BUG: this does not actually work. Emcc is not a child of the Bee build process.
        // Switch to use something else.
//        if (Environment.GetEnvironmentVariable("EMCC_SKIP_SANITY_CHECK") == null)
//            Environment.SetEnvironmentVariable("EMCC_SKIP_SANITY_CHECK", "1");

        return new EmscriptenToolchain(sdk);
    }

    // Development time configuration: Set to true to generate a HTML5 build that runs in a Web Worker instead of the (default) main browser thread.
    // If this is enabled, EnableMultithreading should also be true.
    public static bool RunInBackgroundWorker { get; } = false;

    // Development time configuration: Set to true to generate a HTML5 build that enables SharedArrayBuffer support.
    public static bool EnableMultithreading { get; } = false;

    public static EmscriptenDynamicLinker ConfigureEmscriptenLinkerFor(EmscriptenDynamicLinker e,
        string variation, bool enableManagedDebugger)
    {
        bool runInBackgroundWorker = RunInBackgroundWorker || enableManagedDebugger;
        bool enableMultithreading = EnableMultithreading || runInBackgroundWorker;

        var linkflags = new Dictionary<string, string>
        {
            // Bee defaults to PRECISE_F32=2, which is not an interesting feature for Dots. In Dots asm.js builds, we don't
            // care about single-precision floats, but care more about code size.
            {"PRECISE_F32", "0"},
            // No virtual filesystem needed, saves code size
            {"NO_FILESYSTEM", "1"},
            // Generate runtime code only for executing in web browser (and in a Web Worker if debugging)
            {"ENVIRONMENT", enableMultithreading ? "web,worker" : "web"},
            // Proxy all posix sockets calls to a sockets thread when managed debugging is enabled
            {"PROXY_POSIX_SOCKETS", enableManagedDebugger ? "1" : "0"},
            // No exceptions machinery needed when not debugging, saves code size
            {"DISABLE_EXCEPTION_CATCHING", enableManagedDebugger ? "0" : "1"},
            // In -Oz builds, Emscripten does compile time global initializer evaluation in hope that it can
            // optimize away some ctors that can be compile time executed. This does not really happen often,
            // and with MINIMAL_RUNTIME we have a better "super-constructor" approach that groups all ctors
            // together into one, and that saves more code size. Unfortunately grouping constructors is
            // not possible if EVAL_CTORS is used, so disable EVAL_CTORS to enable grouping.
            {"EVAL_CTORS", "0"},
            // By default the musl C runtime used by Emscripten is POSIX errno aware. We do not care about
            // errno, so opt out from errno management to save a tiny bit of performance and code size.
            {"SUPPORT_ERRNO", "0"},
            // IndexedDB not currently working with Fetch when MINIMAL_RUNTIME is used. (We don't need
            // it anyways as long as our content sizes are nice and small. Revisit when we have 50MB+
            // asset package files)
            {"FETCH_SUPPORT_INDEXEDDB", "0"},
            // We only utilize asynchronous Fetches, so do not need a dedicated Fetch Worker for sync fetches
            // on the background.
            {"USE_FETCH_WORKER", "0"},
            // Initial heap size is defined by TOTAL_MEMORY, but also enable the heap to grow at runtime with
            // ALLOW_MEMORY_GROWTH flag.
            {"ALLOW_MEMORY_GROWTH", "1"},
            // Remove support for OES_texture_half_float and OES_texture_half_float_linear extensions if
            // they are broken. See https://bugs.webkit.org/show_bug.cgi?id=183321,
            // https://bugs.webkit.org/show_bug.cgi?id=169999,
            // https://stackoverflow.com/questions/54248633/cannot-create-half-float-oes-texture-from-uint16array-on-ipad
            {"GL_DISABLE_HALF_FLOAT_EXTENSION_IF_BROKEN", "1"},
            // Use emmalloc_memalign to allocate VM GC memory with BDWGC so that the managed heap
            // uses the same allcoator as everything else.
            {"MALLOC", "emmalloc"},
        };

        if (enableMultithreading)
        {
            e = e.WithMultithreading_Linker(EmscriptenMultithreadingMode.Enabled);
        }

        if (runInBackgroundWorker)
        {
            // WebGL rendering will run in a background thread - proxy GL over to the main thread.
            linkflags["OFFSCREEN_FRAMEBUFFER"] = "1";

            // Enable the main() thread to launch in a Web Worker instead of the main browser thread.
            linkflags["PROXY_TO_PTHREAD"] = "1";
        }

        if (enableManagedDebugger)
        {
            e = e.WithCustomFlags_workaround(new[] {"-lwebsocket.js"});
        }

        if (e.Toolchain.Architecture is AsmJsArchitecture)
        {
            // Target the oldest of browsers when building to JavaScript.
            linkflags["LEGACY_VM_SUPPORT"] = "1";

            // In old fastcomp backend, we can separate the unreadable .asm.js content to its own .asm.js file.
            // In new LLVM backend, it is currently always separated if -s WASM=2 is set, or embedded inline
            // if -s WASM=0 is set, so this option does not apply there.
            if (!UseWasmBackend)
                e = e.WithSeparateAsm(true);
        }

        if (variation == "debug" || variation == "develop")
        {
            linkflags["ASSERTIONS"] = "1";
            linkflags["DEMANGLE_SUPPORT"] = "1";
        }
        else
        {
            linkflags["ASSERTIONS"] = "0";
            linkflags["AGGRESSIVE_VARIABLE_ELIMINATION"] = "1";
            if (!UseWasmBackend) // This optimization pass only exists for the old fastcomp backend.
                linkflags["ELIMINATE_DUPLICATE_FUNCTIONS"] = "1";
        }

        e = e.WithEmscriptenSettings(linkflags);
        e = e.WithNoExitRuntime(true);

        switch (variation)
        {
            case "debug":
                e = e.WithDebugLevel("3"); // Preserve JS whitespace, function names, and LLVM debug info
                e = e.WithOptLevel("1"); // -O0 generates too much code from IL2CPP, must apply optimizations.
                e = e.WithLinkTimeOptLevel(0);
                e = e.WithEmitSymbolMap(false); // At -g3 no name minification occurs -> no symbols present
                e = e.WithCustomFlags_workaround(new[] {
                    "-fno-inline" // Disable inlining in debug builds for easier stepping through code.
                });
                break;
            case "develop":
                e = e.WithDebugLevel("2"); // Preserve JS whitespace and function names
                e = e.WithOptLevel("1");
                e = e.WithLinkTimeOptLevel(0);
                e = e.WithEmitSymbolMap(false); // At -g2 no name minification occurs -> no symbols present
                break;
            case "release":
                e = e.WithDebugLevel("0");
                e = e.WithOptLevel("z");
                if (UseWasmBackend)
                {
                    // Wasm backend uses the general LLVM/GCC -flto flag to enable LTO.
                    e = e.WithCustomFlags_workaround(new[]
                    {
                        "-flto"
                    });
                }
                else
                {
                    // Old fastcomp backend uses its own --llvm-lto <x> flag.
                    e = e.WithLinkTimeOptLevel(3);
                }
                e = e.WithEmitSymbolMap(false); // TODO: re-enable this after Emscripten update
                break;
            default:
                throw new ArgumentException();
        }

        e = e.WithMinimalRuntime(EmscriptenMinimalRuntimeMode.EnableDangerouslyAggressive);

        if (variation == "release" && EnableClosureCompiler)
        {
            // Inject -g1 (preserve whitespace) to Emscripten build so that error messages from Closure will be readable and not minified.
            // Closure will kill this whitespace as part of its minification.
            // TODO: Remove this the next time we update Emscripten (https://github.com/emscripten-core/emscripten/pull/12726)
            e = e.WithDebugLevel("1");

            e = e.WithCustomFlags_workaround(new[]
            {
                "--closure-args", ("--platform native --externs " + BuildProgram.BeeRoot.Combine("closure_externs.js").ToString()).QuoteForProcessStart(),
                "--closure", "1",
                "-s", "CLOSURE_WARNINGS=warn"
            });
        }

        // TODO: Remove this line once Bee fix is in to support SystemLibrary() objects on web builds. Then restore
        // the line Libraries.Add(c => c.ToolChain.Platform is WebGLPlatform, new SystemLibrary("GL")); at the top of this file
        e = e.WithCustomFlags_workaround(new[] {"-lGL"});

        // Target the Emscripten Fetch API for network requests.
        e = e.WithCustomFlags_workaround(new[] { "-s FETCH=1" });

        e = e.WithMemoryInitFile(e.Toolchain.Architecture is AsmJsArchitecture || (enableMultithreading && !UseWasmBackend));

        if (UseWasmBackend && e.Toolchain.Architecture is AsmJsArchitecture)
        {
            // Work around Binaryen multithreading bug: using more than 1 core is slower than using a single core!
            // TODO: Remove this after Emscripten update, where the issue has been fixed.
            // BUG: this does not actually work. Emcc is not a child of the Bee build process.
            // Switch to use something else.
            // Environment.SetEnvironmentVariable("BINARYEN_CORES", "1");
        }

        return e;
    }
}
