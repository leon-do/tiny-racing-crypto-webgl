using UnityEngine;
using Unity.Build.DotsRuntime;
using Unity.Properties;
using Unity.Serialization;
using Unity.Serialization.Json;

namespace Unity.Build.Web.DotsRuntime
{
    public class WasmOutputSettings : IDotsRuntimeBuildModifier
    {
        [CreateProperty]
        [Tooltip("If enabled, Wasm build will generate a single .html file as build output, that embeds HTML, JS, Wasm and Asset data. However, this increases build size and slows down startup, so it is not recommended unless deploying to an environment that requires it.")]
        public bool OutputSingleHTMLFile = false;

        [CreateProperty]
        [Tooltip("If enabled, the generated .html file will be minified for smallest build output. Ignored in Debug and Develop builds.")]
        public bool MinifyHTMLFile = true;

        [CreateProperty]
        [Tooltip("If enabled, Closure compiler is used to minify JavaScript code. This is generally recommended for smallest build output, but it does require carefully adhering to Closure's name minification rules. For more information, refer to https://github.com/google/closure-compiler/. Ignored in Debug and Develop builds.")]
        public bool MinifyOutputWithClosure = false;

        [CreateProperty]
        [Tooltip("If enabled, the generated build will embed an ad hoc CPU frame rate counter and a frame time profiling graph. CPU profiling incurs a small performance overhead.")]
        public bool EmbedCpuProfiler = false;

        [CreateProperty]
        [Tooltip("If enabled, the generated build will embed an ad hoc Wasm heap memory usage profiler. Use this for advanced memory debugging from Wasm heap perspective. Memory profiling incurs a large performance overhead.")]
        public bool EmbedMemoryProfiler = false;

        [CreateProperty]
        [Tooltip("If enabled, the generated .wasm file will retain function name information, to be able to see proper callstack names in the browser, and for profiling and debugging in Browser Devtools. Enabling symbols carries a lare size increase, so remember to disable this when shipping!")]
        public bool IncludeSymbolsForBrowserCallstacks = false;

        [CreateProperty]
        [Tooltip("If enabled, the generated build will be annotated for validity of low-level memory load and store operations. Enable to track sources of memory access corruptions. Incurs a large performance overhead.")]
        public bool EmitRuntimeMemoryDebugChecks = false;

        [CreateProperty]
        [Tooltip("If enabled, the generated build will be annotated for validity of low-level memory allocation operations. Enable to track sources of memory allocation and buffer overrun corruptions. Incurs a large performance overhead.")]
        public bool EmitRuntimeAllocationDebugChecks = false;

        [CreateProperty]
        [Tooltip("Specifies the location of the web template folder. Specified folder is treated as relative to the project root. If this value is empty, then the default web template will be used.")]
        public string WebTemplateFolder = "";

        public void Modify(JsonObject jsonObject)
        {
            jsonObject["SingleFile"] = OutputSingleHTMLFile;
            jsonObject["MinifyHTMLFile"] = MinifyHTMLFile;
            jsonObject["MinifyOutputWithClosure"] = MinifyOutputWithClosure;
            jsonObject["EmbedCpuProfiler"] = EmbedCpuProfiler;
            jsonObject["EmbedMemoryProfiler"] = EmbedMemoryProfiler;
            jsonObject["IncludeSymbolsForBrowserCallstacks"] = IncludeSymbolsForBrowserCallstacks;
            jsonObject["EmitRuntimeMemoryDebugChecks"] = EmitRuntimeMemoryDebugChecks;
            jsonObject["EmitRuntimeAllocationDebugChecks"] = EmitRuntimeAllocationDebugChecks;
            jsonObject["WebTemplateFolder"] = WebTemplateFolder;
        }
    }
}
