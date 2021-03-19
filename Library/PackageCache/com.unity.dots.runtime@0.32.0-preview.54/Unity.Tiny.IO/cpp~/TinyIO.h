#pragma once

#include <Unity/Runtime.h>

namespace Unity { namespace Tiny { namespace IO {

// Keep this in sync with C#
enum class Status {
    NotStarted = 0,
    InProgress,
    Failure,
    Success
};

enum class ErrorStatus {
    None = 0,
    FileNotFound,
    Unknown
};

DOTS_EXPORT(int) RequestAsyncRead(const char* path, void* pData = nullptr, int len = 0);
DOTS_EXPORT(int) GetStatus(int requestIndex);
DOTS_EXPORT(int) GetErrorStatus(int requestIndex);
DOTS_EXPORT(void) Close(int requestIndex);
DOTS_EXPORT(void) GetData(int requestIndex, const char** ppData, int* pLen);

}}} // namespace Unity::Tiny::IO
