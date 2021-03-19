#if (UNITY_ANDROID)
using System;
using Unity.Platforms;
using Unity.Tiny.Rendering;

namespace Unity.Tiny.Rendering
{
    public abstract partial class RenderingGPUSystem
    {
        protected override void OnStartRunning()
        {
            PlatformEvents.OnSuspendResume += OnSuspendResume;
        }

        protected override void OnStopRunning()
        {
            PlatformEvents.OnSuspendResume -= OnSuspendResume;
        }

        public void OnSuspendResume(object sender, SuspendResumeEvent evt)
        {
            if (evt.Suspend)
            {
                Shutdown();
            }
            else
            {
                Resume();
            }
        }
    }
}
#endif
