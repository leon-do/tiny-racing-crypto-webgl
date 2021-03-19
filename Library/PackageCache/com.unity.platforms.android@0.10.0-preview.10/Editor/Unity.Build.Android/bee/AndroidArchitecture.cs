using System;

namespace Unity.Build.Android
{
    // Android CPU architecture.
    // Matches enum in EditorOnlyPlayerSettings.h.
    [Flags]
    internal enum AndroidArchitecture : uint
    {
        // Invalid architecture
        None = 0,

        // armeabi-v7a
        ARMv7 = 1 << 0,

        // arm64-v8a
        ARM64 = 1 << 1,

        // x86
        // X86 = 1 << 2,

        // All architectures
        All = 0xffffffff,
    }
}
