#pragma once

#include <stdint.h>
#include "il2cpp-config.h"
#include "il2cpp-object-internals.h"

struct Il2CppObject;

namespace tiny
{
namespace icalls
{
namespace mscorlib
{
namespace System
{
namespace Runtime
{
namespace InteropServices
{
    class LIBIL2CPP_CODEGEN_API GCHandle
    {
    public:
        static void FreeHandle(int32_t handle);
        static Il2CppObject * GetTarget(int32_t handle);
        static int32_t GetTargetHandle(Il2CppObject * obj, int32_t handle, int32_t type);
        static intptr_t GetAddrOfPinnedObject(int32_t handle);
    };
} /* namespace InteropServices */
} /* namespace Runtime */
} /* namespace System */
} /* namespace mscorlib */
} /* namespace icalls */
} /* namespace tiny */
