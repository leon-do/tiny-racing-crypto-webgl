#include <Unity/Runtime.h>

#include <emscripten.h>
#include <emscripten/html5.h>
#include <stdio.h>

#include "il2cpp-config.h"
#include "gc/GarbageCollector.h"

extern "C" {
    // Looking for js_html_init() ? It's moved to ZeroJobs so it can be initialized by the test runner.
    bool js_html_setCanvasSize(int width, int height, bool webgl);
    void js_html_debugReadback(int w, int h, void *pixels);
}

// C# delegates
static void (*pausef)(int) = 0;
static void (*destroyf)() = 0;

DOTS_EXPORT(bool)
pausecallbackinit_html(void (*func)(int)) {
    if (pausef)
        return false;
    pausef = func;
    return true;
}

DOTS_EXPORT(bool)
destroycallbackinit_html(void (*func)()) {
    if (destroyf)
        return false;
    destroyf = func;
    return true;
}

DOTS_EXPORT(void)
shutdown_html(int exitCode)
{
}

DOTS_EXPORT(void)
ondestroyapp()
{
    if (destroyf)
        destroyf();
}

DOTS_EXPORT(void)
onpauseapp(int paused)
{
    if (pausef)
        pausef(paused);
}

DOTS_EXPORT(double)
time_html()
{
    // TODO: If we want to target such old mobile browsers that they do not have performance.now() API,
    //       we should change the following call to emscripten_get_now() instead of emscripten_performance_now().
    //       They are the same otherwise, except that emscripten_performance_now() is much smaller code-size wise,
    //       since it does not emulate performance.now() via Date.now() (which emscripten_get_now() does)
    return emscripten_performance_now()*0.001;
}
