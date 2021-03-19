#if UNITY_WINDOWS && UNITY_DOTSRUNTIME_IL2CPP_WAIT_FOR_MANAGED_DEBUGGER

#include <Unity/Runtime.h>

#include <windef.h>
#include <winuser.h>

typedef void (*BroadcastFunction)();

static BroadcastFunction s_Broadcast = NULL;

void DialogUpdateCallback()
{
    if (s_Broadcast != NULL)
        s_Broadcast();
}

void CALLBACK DialogTimerCallback(HWND hwnd, UINT uMsg, UINT timerId, DWORD dwTime)
{
    DialogUpdateCallback();
}

DOTS_EXPORT(void)
ShowDebuggerAttachDialog(const char* message, BroadcastFunction broadcast)
{
    s_Broadcast = broadcast;
    UINT_PTR timerId = 0;
    timerId = SetTimer(NULL, 0, USER_TIMER_MINIMUM, (TIMERPROC)&DialogTimerCallback);

    MessageBoxA(0, message, "Debug", MB_OK);

    if (timerId != 0)
    {
        KillTimer(NULL, timerId);
        timerId = 0;
    }
}

#endif
