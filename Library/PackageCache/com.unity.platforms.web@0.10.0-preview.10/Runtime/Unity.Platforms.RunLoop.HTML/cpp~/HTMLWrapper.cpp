#if UNITY_WEBGL
#include <Unity/Runtime.h>

#include <emscripten.h>
#include <emscripten/html5.h>
#include <emscripten/threading.h>
#include <stdio.h>
#include <string>

#include "il2cpp-config.h"
#include "gc/GarbageCollector.h"

static bool (*raf)(double) = 0; // c# delegate

#if UNITY_DOTSRUNTIME_IL2CPP_WAIT_FOR_MANAGED_DEBUGGER

typedef void (*BroadcastFunction)();
static BroadcastFunction broadcastCallback = NULL;

extern "C" bool js_html_StillWaitingForManagedDebugger(void);

#endif

static EM_BOOL tick(double wallclock_time_in_msecs, void* /*userData*/)
{
    using namespace il2cpp::gc;
    bool disabled = GarbageCollector::IsDisabled();
    if (disabled)
        GarbageCollector::Enable();
    GarbageCollector::CollectALittle();
    if (disabled)
        GarbageCollector::Disable();

#if UNITY_DOTSRUNTIME_IL2CPP_WAIT_FOR_MANAGED_DEBUGGER
    // Check if the user acknowledged the "continue" button.
    // If so, start executing managed code.
    if (!js_html_StillWaitingForManagedDebugger())
        broadcastCallback = NULL;

    if (broadcastCallback != NULL)
    {
        broadcastCallback();
    }
    else
#endif
    if (!raf(wallclock_time_in_msecs * 0.001)) // msec to sec
    {
        raf = 0;
        return EM_FALSE; // return back to Emscripten runtime saying that animation loop should stop here
    }

    // If we are in an off-main-thread loop, need to tell the main browser thread that now is the time
    // to swap GL contents on screen
    if (!emscripten_is_main_browser_thread())
        emscripten_webgl_commit_frame();
    return EM_TRUE; // return back to Emscripten runtime saying that animation loop should keep going
}

DOTS_EXPORT(bool)
rafcallbackinit_html(bool (*func)(double))
{
    if (raf)
        return false;
    raf = func;
    // When running in a web worker, which does not have requestAnimationFrame(), instead run a manual loop
    // with setTimeout()s. TODO: With OffscreenCanvas rAF() will likely become available in Workers, so in
    // future will probably want to feature test rAF() first, and only if not available, fall back to
    // setTimeout() loop.
    if (!emscripten_is_main_browser_thread())
        emscripten_set_timeout_loop(tick, 1000.0/60.0, 0);
    else
    // In singlethreaded build on main thread, can always use rAF().
        emscripten_request_animation_frame_loop(tick, 0);

    // Unwind back to browser, skipping executing anything after this function.
    emscripten_throw_string("unwind");
    // This line is never reached, the throw above throws a JS statement that skips over rest of the code.
    return true;
}

#if UNITY_DOTSRUNTIME_IL2CPP_WAIT_FOR_MANAGED_DEBUGGER

extern "C" void js_html_displayWaitForManagedDebugger(const char* message);

DOTS_EXPORT(void)
ShowDebuggerAttachDialog(const char* message , BroadcastFunction broadcast)
{
    broadcastCallback = broadcast;
    js_html_displayWaitForManagedDebugger(message);
}

#endif // UNITY_DOTSRUNTIME_IL2CPP_WAIT_FOR_MANAGED_DEBUGGER

#endif
