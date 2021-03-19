using UnityEngine;
using Unity.Build.DotsRuntime;
using Unity.Properties;
using Unity.Serialization;
using Unity.Serialization.Json;

namespace Unity.Build.Web.DotsRuntime
{
    public class EmscriptenAdvancedSettings : IDotsRuntimeBuildModifier
    {
        [CreateProperty]
        [Tooltip("Specifies additional directives to pass to the Emscripten linker command line. Use this only if you know what you are doing. Refer to Emscripten compiler documentation for details.")]
        public string AdvancedEmscriptenLinkerCommandLine = "";

        public void Modify(JsonObject jsonObject)
        {
            jsonObject["EmscriptenCmdLine"] = AdvancedEmscriptenLinkerCommandLine;
        }
    }
}
