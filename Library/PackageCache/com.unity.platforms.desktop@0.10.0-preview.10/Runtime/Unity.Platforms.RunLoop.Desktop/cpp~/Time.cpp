#include <Unity/Runtime.h>
#include <Baselib.h>
#include <C/Baselib_Timer.h>

#define NS_TO_S 1000000000.0

DOTS_EXPORT(double)
GetSecondsMonotonic()
{
    static Baselib_Timer_TickToNanosecondConversionRatio conversion = Baselib_Timer_GetTicksToNanosecondsConversionRatio();
    return ((int64_t)Baselib_Timer_GetHighPrecisionTimerTicks() * conversion.ticksToNanosecondsNumerator / conversion.ticksToNanosecondsDenominator) / NS_TO_S;
}
