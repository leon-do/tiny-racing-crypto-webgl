using System;
using System.Runtime.InteropServices;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Burst;
using Unity.Tiny;
using Unity.Tiny.Audio;
using Unity.Tiny.GenericAssetLoading;

#if ENABLE_DOTSRUNTIME_PROFILER
using Unity.Development.Profiling;
#endif

namespace Unity.Tiny.Web
{
    // Unlike the native version, the HTML version manages the IDs for the clips and sources.
    struct IDPool
    {
        internal int clipID;
        internal int sourceID;
    }

    sealed class SharedIDPool
    {
        public static readonly SharedStatic<IDPool> Value = SharedStatic<IDPool>.GetOrCreate<AudioHTMLSystemLoadFromFile, IDPool>();
    }

    public struct AudioHTMLClip : ISystemStateComponentData
    {
        public int clipID;
    }

    public struct AudioHTMLLoading : ISystemStateComponentData
    {
    }

    static class AudioHTMLNativeCalls
    {
        private const string DLL = "lib_unity_tiny_audio_web";

        [DllImport(DLL, EntryPoint = "js_html_initAudio")]
        [return : MarshalAs(UnmanagedType.I1)]
        public static extern bool Init();

        [DllImport(DLL, EntryPoint = "js_html_audioIsUnlocked")]
        [return : MarshalAs(UnmanagedType.I1)]
        public static extern bool IsUnlocked();

        [DllImport(DLL, EntryPoint = "js_html_audioUnlock")]
        public static extern void Unlock();

        [DllImport(DLL, EntryPoint = "js_html_audioPause")]
        public static extern void Pause();

        [DllImport(DLL, EntryPoint = "js_html_audioResume")]
        public static extern void Resume();

        [DllImport(DLL, EntryPoint = "js_html_setMaxUncompressedAudioBufferBytes")]
        public static extern void SetUncompressedAudioMemoryBytesMax(int uncompressedAudioMemoryBytesMax);

        // Note this just returns the audioClipIndex, which isn't super helpful.
        [DllImport(DLL, EntryPoint = "js_html_audioStartLoadFile", CharSet = CharSet.Ansi)]
        public static extern int StartLoad([MarshalAs(UnmanagedType.LPStr)] string audioClipName, int audioClipIndex);

        // LoadResult:
        // stillWorking = 0,
        // success = 1,
        // failed = 2
        [DllImport(DLL, EntryPoint = "js_html_audioCheckLoad")]
        public static extern int CheckLoad(int audioClipIndex);

        [DllImport(DLL, EntryPoint = "js_html_audioFree")]
        public static extern void Free(int audioClipIndex);

#if ENABLE_DOTSRUNTIME_PROFILER
        [DllImport(DLL, EntryPoint = "js_html_getRequiredMemoryUncompressed")]
        public static extern int GetRequiredMemoryUncompressed(int clipID);

        [DllImport(DLL, EntryPoint = "js_html_getRequiredMemoryCompressed")]
        public static extern int GetRequiredMemoryCompressed(int clipID);
#endif

        [DllImport(DLL, EntryPoint = "js_html_audioPlay")]
        public static extern int Play(int audioClipIdx, int audioSourceIdx, double volume, double pitch, double pan, int loop);

        [DllImport(DLL, EntryPoint = "js_html_audioStop")]
        public static extern int Stop(int audioSourceIdx, int doStop);

        [DllImport(DLL, EntryPoint = "js_html_audioSetVolume")]
        public static extern void SetVolume(int audioSourceIdx, double volume);

        [DllImport(DLL, EntryPoint = "js_html_audioSetPan")]
        public static extern void SetPan(int audioSourceIdx, double pan);

        [DllImport(DLL, EntryPoint = "js_html_audioSetPitch")]
        public static extern void SetPitch(int audioSourceIdx, double pitch);

        [DllImport(DLL, EntryPoint = "js_html_audioIsPlaying")]
        public static extern int IsPlaying(int audioSourceIdx);

        [DllImport(DLL, EntryPoint = "js_html_audioUpdate")]
        public static extern void Update();
    }

    class AudioHTMLSystemLoadFromFile : IGenericAssetLoader<AudioClip, AudioHTMLClip, AudioClipLoadFromFile, AudioHTMLLoading>
    {
        public void StartLoad(
            EntityManager entityManager,
            Entity e,
            ref AudioClip audioClip,
            ref AudioHTMLClip audioHtmlClip,
            ref AudioClipLoadFromFile loader,
            ref AudioHTMLLoading loading)
        {
            if (!entityManager.HasComponent<AudioClipLoadFromFileAudioFile>(e))
            {
                audioHtmlClip.clipID = 0;
                audioClip.status = AudioClipStatus.LoadError;
                return;
            }

            string path = entityManager.GetBufferAsString<AudioClipLoadFromFileAudioFile>(e);
            audioHtmlClip.clipID = ++SharedIDPool.Value.Data.clipID;
            AudioHTMLNativeCalls.StartLoad(path, audioHtmlClip.clipID);
            audioClip.status = AudioClipStatus.Loading;
        }

        public LoadResult CheckLoading(IntPtr cppWrapper, EntityManager man, Entity e, ref AudioClip audioClip, ref AudioHTMLClip audioNative, ref AudioClipLoadFromFile param, ref AudioHTMLLoading loading)
        {
            LoadResult result = (LoadResult)AudioHTMLNativeCalls.CheckLoad(audioNative.clipID);

            if (result == LoadResult.success)
            {
                audioClip.status = AudioClipStatus.Loaded;
            }
            else if (result == LoadResult.failed)
            {
                audioClip.status = AudioClipStatus.LoadError;
            }

            return result;
        }

        public void FreeNative(EntityManager man, Entity e, ref AudioHTMLClip audioNative)
        {
            AudioHTMLNativeCalls.Free(audioNative.clipID);
        }

        public void FinishLoading(EntityManager man, Entity e, ref AudioClip audioClip, ref AudioHTMLClip audioNative, ref AudioHTMLLoading loading)
        {
        }
    }


    [UpdateInGroup(typeof(PresentationSystemGroup))]
    [UpdateBefore(typeof(AudioHTMLSystem))]
    public class AudioIOHTMLSystem : GenericAssetLoader<AudioClip, AudioHTMLClip, AudioClipLoadFromFile, AudioHTMLLoading>
    {
        protected override void OnCreate()
        {
            base.OnCreate();
            c = new AudioHTMLSystemLoadFromFile();
        }
    }

    [UpdateInGroup(typeof(PresentationSystemGroup))]
    public class AudioHTMLSystem : AudioSystem
    {
        private bool unlocked = false;

        protected override void OnStartRunning()
        {
            AudioHTMLNativeCalls.Unlock();
            unlocked = AudioHTMLNativeCalls.IsUnlocked();
            //Console.WriteLine("(re) checking un-locked: ");
            //Console.WriteLine(unlocked ? "true" : "false");

            AudioConfig ac = GetSingleton<AudioConfig>();
            ac.initialized = true;
            ac.unlocked = unlocked;
            SetSingleton<AudioConfig>(ac);
        }

        protected override void OnStopRunning()
        {
            
        }

        protected override void OnUpdate()
        {
            EntityManager mgr = EntityManager;
            Entity audioEntity = m_audioEntity;
            NativeList<Entity> entitiesPlayed = new NativeList<Entity>(Allocator.Temp);

            base.OnUpdate();

            AudioConfig ac = GetSingleton<AudioConfig>();
            if (!unlocked)
            {
                unlocked = AudioHTMLNativeCalls.IsUnlocked();    
                ac.unlocked = unlocked;
                SetSingleton<AudioConfig>(ac);
            }
            
            if (ac.paused)
                AudioHTMLNativeCalls.Pause();
            else
                AudioHTMLNativeCalls.Resume();

            AudioHTMLNativeCalls.SetUncompressedAudioMemoryBytesMax(ac.maxUncompressedAudioMemoryBytes);

            // Stop sounds.
            for (int i = 0; i < mgr.GetBuffer<SourceIDToStop>(audioEntity).Length; i++)
            {
                uint id = mgr.GetBuffer<SourceIDToStop>(audioEntity)[i];
                AudioHTMLNativeCalls.Stop((int)id, 1);
            }

            // Play sounds.
            if (unlocked)
            {
                Entities
                    .WithAll<AudioSource, AudioSourceStart>()
                    .ForEach((Entity e) =>
                    {
                        uint sourceID = (uint)PlaySource(mgr, e);
                        if (sourceID > 0)
                        {
                            AudioSourceID audioSourceID = mgr.GetComponentData<AudioSourceID>(e);
                            audioSourceID.sourceID = sourceID;
                            mgr.SetComponentData<AudioSourceID>(e, audioSourceID);

                            entitiesPlayed.Add(e);
                        }
                    }).Run();

                for (int i = 0; i < entitiesPlayed.Length; i++)
                    mgr.RemoveComponent<AudioSourceStart>(entitiesPlayed[i]);
            }

            DynamicBuffer<EntityPlaying> entitiesPlaying = mgr.GetBuffer<EntityPlaying>(m_audioEntity);
            for (int i = 0; i < entitiesPlaying.Length; i++)
            {
                Entity e = entitiesPlaying[i];
                AudioSource audioSource = mgr.GetComponentData<AudioSource>(e);

                audioSource.isPlaying = (IsPlaying(mgr, e) == 1) ? true : false;
                mgr.SetComponentData<AudioSource>(e, audioSource);

                if (audioSource.isPlaying)
                {
                    float volume = audioSource.volume;
                    if (mgr.HasComponent<AudioDistanceAttenuation>(e))
                    {
                        AudioDistanceAttenuation distanceAttenuation = mgr.GetComponentData<AudioDistanceAttenuation>(e);
                        volume *= distanceAttenuation.volume;
                    }
                    SetVolume(mgr, e, volume);

                    if (mgr.HasComponent<Audio3dPanning>(e))
                    {
                        Audio3dPanning panning = mgr.GetComponentData<Audio3dPanning>(e);
                        SetPan(mgr, e, panning.pan);
                    }
                    else if (mgr.HasComponent<Audio2dPanning>(e))
                    {
                        Audio2dPanning panning = mgr.GetComponentData<Audio2dPanning>(e);
                        SetPan(mgr, e, panning.pan);
                    }

                    if (mgr.HasComponent<AudioPitch>(e))
                    {
                        AudioPitch pitchEffect = mgr.GetComponentData<AudioPitch>(e);
                        float pitch = (pitchEffect.pitch > 0.0f) ? pitchEffect.pitch : 1.0f;
                        SetPitch(mgr, e, pitch);
                    }
                } 
            }

#if ENABLE_DOTSRUNTIME_PROFILER
            ProfilerStats.AccumStats.memAudioCount.value = 0;
            ProfilerStats.AccumStats.memAudio.value = 0;
            ProfilerStats.AccumStats.memReservedAudio.value = 0;
            ProfilerStats.AccumStats.memUsedAudio.value = 0;
            ProfilerStats.AccumStats.memReservedExternal.value = 0;
            ProfilerStats.AccumStats.memUsedExternal.value = 0;
            ProfilerStats.AccumStats.audioStreamFileMemory.value = 0;
            ProfilerStats.AccumStats.audioSampleMemory.value = 0;

            Entities.ForEach((Entity e, in AudioHTMLClip audioHTMLClip) =>
            {
                int memUncompressedBytes = AudioHTMLNativeCalls.GetRequiredMemoryUncompressed(audioHTMLClip.clipID);
                int memCompressedBytes = AudioHTMLNativeCalls.GetRequiredMemoryCompressed(audioHTMLClip.clipID);
                long memTotalBytes = memUncompressedBytes + memCompressedBytes;

                ProfilerStats.AccumStats.memAudioCount.Accumulate(1);
                ProfilerStats.AccumStats.memAudio.Accumulate(memTotalBytes);
                ProfilerStats.AccumStats.memReservedAudio.Accumulate(memTotalBytes);
                ProfilerStats.AccumStats.memUsedAudio.Accumulate(memTotalBytes);
                ProfilerStats.AccumStats.memReservedExternal.Accumulate(memTotalBytes);
                ProfilerStats.AccumStats.memUsedExternal.Accumulate(memTotalBytes);
                ProfilerStats.AccumStats.audioSampleMemory.Accumulate(memTotalBytes);
            }).Run();
#endif

            AudioHTMLNativeCalls.Update();
        }

        protected override void InitAudioSystem()
        {
            //Console.WriteLine("InitAudioSystem()");
            AudioHTMLNativeCalls.Init();
        }

        protected override void DestroyAudioSystem()
        {
            // No-op in HTML
        }

        [BurstCompile]
        protected static int PlaySource(EntityManager mgr, Entity e)
        {
            if (mgr.HasComponent<AudioSource>(e))
            {
                AudioSource audioSource = mgr.GetComponentData<AudioSource>(e);

                Entity clipEntity = audioSource.clip;
                if (mgr.HasComponent<AudioHTMLClip>(clipEntity))
                {
                    AudioHTMLClip clip = mgr.GetComponentData<AudioHTMLClip>(clipEntity);
                    if (clip.clipID > 0)
                    {
                        // If there is an existing source, it should re-start.
                        // Do this with a Stop() and let it play below.
                        if (mgr.HasComponent<AudioSourceID>(e))
                        {
                            AudioSourceID ans = mgr.GetComponentData<AudioSourceID>(e);
                            AudioHTMLNativeCalls.Stop((int)ans.sourceID, 1);
                        }

                        float volume = audioSource.volume;
                        float pan = mgr.HasComponent<Audio2dPanning>(e) ? mgr.GetComponentData<Audio2dPanning>(e).pan : 0.0f;
                        float pitch = mgr.HasComponent<AudioPitch>(e) ? mgr.GetComponentData<AudioPitch>(e).pitch : 1.0f;

                        // For 3d sounds, we start at volume zero because we don't know if this sound is close or far from the listener.
                        // It is much smoother to ramp up volume from zero than the alternative.
                        if (mgr.HasComponent<Audio3dPanning>(e))
                            volume = 0.0f;

                        int sourceID = ++SharedIDPool.Value.Data.sourceID;

                        // Check the return value from Play because it fails sometimes at startup for AudioSources with PlayOnAwake set to true.
                        // If initial attempt fails, try again next frame.
                        if (AudioHTMLNativeCalls.Play(clip.clipID, sourceID, volume, pitch, pan, audioSource.loop ? 1 : 0) == 0)
                            return 0;

                        return sourceID;
                    }
                }
            }

            return 0;
        }

        [BurstCompile]
        protected static void StopSource(EntityManager mgr, Entity e)
        {
            if (mgr.HasComponent<AudioSourceID>(e))
            {
                AudioSourceID audioSourceID = mgr.GetComponentData<AudioSourceID>(e);
                if (audioSourceID.sourceID > 0)
                {
                    AudioHTMLNativeCalls.Stop((int)audioSourceID.sourceID, 1);
                }
            }
        }

        [BurstCompile]
        protected static int IsPlaying(EntityManager mgr, Entity e)
        {
            if (mgr.HasComponent<AudioSourceID>(e))
            {
                AudioSourceID audioSourceID = mgr.GetComponentData<AudioSourceID>(e);
                if (audioSourceID.sourceID > 0)
                    return AudioHTMLNativeCalls.IsPlaying((int)audioSourceID.sourceID);
            }

            return 0;
        }

        [BurstCompile]
        protected static void SetVolume(EntityManager mgr, Entity e, float volume)
        {
            if (mgr.HasComponent<AudioSourceID>(e))
            {
                AudioSourceID audioSourceID = mgr.GetComponentData<AudioSourceID>(e);
                if (audioSourceID.sourceID > 0)
                    AudioHTMLNativeCalls.SetVolume((int)audioSourceID.sourceID, volume);
            }
        }

        [BurstCompile]
        protected static void SetPan(EntityManager mgr, Entity e, float pan)
        {
            if (mgr.HasComponent<AudioSourceID>(e))
            {
                AudioSourceID audioSourceID = mgr.GetComponentData<AudioSourceID>(e);
                if (audioSourceID.sourceID > 0)
                    AudioHTMLNativeCalls.SetPan((int)audioSourceID.sourceID, pan);
            }
        }

        [BurstCompile]
        protected static void SetPitch(EntityManager mgr, Entity e, float pitch)
        {
            if (mgr.HasComponent<AudioSourceID>(e))
            {
                AudioSourceID audioSourceID = mgr.GetComponentData<AudioSourceID>(e);
                if (audioSourceID.sourceID > 0)
                    AudioHTMLNativeCalls.SetPitch((int)audioSourceID.sourceID, pitch);
            }
        }
    }
}
