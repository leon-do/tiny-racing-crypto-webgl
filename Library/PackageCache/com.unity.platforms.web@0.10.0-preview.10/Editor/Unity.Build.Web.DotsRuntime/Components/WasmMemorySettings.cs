using UnityEngine;
using Unity.Build.DotsRuntime;
using Unity.Properties;
using Unity.Serialization;
using Unity.Serialization.Json;

namespace Unity.Build.Web.DotsRuntime
{
    public class WasmMemorySettings : IDotsRuntimeBuildModifier
    {
        [CreateProperty]
        [Tooltip("Specifies the size of the program main thread stack on the WebAssembly memory. Generally this can be kept small, but may need increasing if utilizing deeply nested recursive programming techniques. (default: 512KB)")]
        public string WasmStackSize = "512KB";

        [CreateProperty]
        [Tooltip("Specifies the starting size of the WebAssembly heap. If memory growth is enabled, this memory size will specify the initial size of the heap, which can later grow as more memory is needed. If memory growth is disabled, this field specifies the total/maximum size. (default: 128MB)")]
        public string WasmMemorySize = "128MB";

        [CreateProperty]
        [Tooltip("If enabled, WebAssembly memory is allowed to grow in size after its initial creation. This should generally only be disabled if to enforce a specified memory limit, e.g. when debugging that application does not consume exorbitant amounts of memory in a memory leak.")]
        public bool AllowWasmMemoryGrowth = true;

        public void Modify(JsonObject jsonObject)
        {
            jsonObject["WasmStackSize"] = WasmStackSize;
            jsonObject["WasmMemorySize"] = WasmMemorySize;
            jsonObject["AllowWasmMemoryGrowth"] = AllowWasmMemoryGrowth;
        }
    }
}
