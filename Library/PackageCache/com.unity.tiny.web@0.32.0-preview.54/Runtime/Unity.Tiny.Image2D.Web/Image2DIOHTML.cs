using System;
using System.Runtime.InteropServices;
using Unity.Mathematics;
using Unity.Entities;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Collections;
using Unity.Tiny.GenericAssetLoading;
#if ENABLE_DOTSPLAYER_PROFILER
using Unity.Development.Profiling;
#endif
using Hash128 = Unity.Entities.Hash128;

/**
 * @module
 * @name Unity.Tiny
 */
namespace Unity.Tiny.Web
{
    public struct Image2DHTML : ISystemStateComponentData
    {
        public int imageIndex;
        public bool externalOwner;
    };

    public struct Image2DHTMLLoading : ISystemStateComponentData
    {
    }

    public static class ImageIOHTMLNativeCalls
    {
        // directly calls out to JS!

        [DllImport("lib_unity_tiny_image2d_web", EntryPoint = "js_html_initImageLoading")]
        public static extern void JSInitImageLoading();

        [DllImport("lib_unity_tiny_image2d_web", EntryPoint = "js_html_loadImage", CharSet = CharSet.Ansi)]
        public static extern int JSLoadImage([MarshalAs(UnmanagedType.LPStr)] string imageFile, [MarshalAs(UnmanagedType.LPStr)] string maskFile);

        [DllImport("lib_unity_tiny_image2d_web", EntryPoint = "js_html_checkLoadImage")]
        public static extern int JSCheckLoadImage(int idx);

        [DllImport("lib_unity_tiny_image2d_web", EntryPoint = "js_html_finishLoadImage")]
        public static extern void JSFinishLoadImage(int idx, ref int w, ref int h, ref int hasAlpha);

        [DllImport("lib_unity_tiny_image2d_web", EntryPoint = "js_html_getImageInfo")]
        public static extern void JSGetImageInfo(int idx, ref int w, ref int h);

        [DllImport("lib_unity_tiny_image2d_web", EntryPoint = "js_html_freeImage")]
        public static extern void JSFreeImage(int idx);

        [DllImport("lib_unity_tiny_image2d_web", EntryPoint = "js_html_extractAlphaFromImage")]
        public static extern unsafe void ExtractAlphaFromImage(int idx, byte* destPtr, int w, int h);

        [DllImport("lib_unity_tiny_image2d_web", EntryPoint = "js_html_imageToDataURI")]
        public static extern unsafe byte *ImageToDataURI(int idx, int w, int h);

        [DllImport("lib_unity_tiny_image2d_web", EntryPoint = "js_html_imagePostRequestStatus")]
        public static extern unsafe int ImagePostRequestStatus(int idx);

        [DllImport("lib_unity_tiny_image2d_web", EntryPoint = "js_html_imagePostRequest", CharSet = CharSet.Ansi)]
        public static extern unsafe int ImagePostRequest(int idx, int w, int h, [MarshalAs(UnmanagedType.LPStr)] string uri);

        [DllImport("lib_unity_tiny_image2d_web", EntryPoint = "js_html_imageToMemory")]
        public static extern unsafe int ImageToMemory(int idx, int w, int h, byte* destPtr);

        [DllImport("lib_unity_tiny_image2d_web", EntryPoint = "js_html_imageFromMemory")]
        public static extern unsafe int ImageFromMemory(int idx, int w, int h, byte *src);
    }


    public class Image2DIOHTMLLoader : IGenericAssetLoader<Image2D, Image2DHTML, Image2DLoadFromFile, Image2DHTMLLoading>
    {
        public void StartLoad(EntityManager man, Entity e, ref Image2D image, ref Image2DHTML imgHTML,
            ref Image2DLoadFromFile fspec, ref Image2DHTMLLoading loading)
        {
            // if there was an image with that index, free it
            FreeNative(man, e, ref imgHTML);

            image.status = ImageStatus.Loading;
            image.imagePixelHeight = 0;
            image.imagePixelWidth = 0;

            string fnImage = "", fnMask = "";
            if (man.HasComponent<Image2DLoadFromFileGuids>(e))
            {
                var guids = man.GetComponentData<Image2DLoadFromFileGuids>(e);
                // TODO -- call an asset service to actually get some kind of stream from a guid
                if (guids.imageAsset.IsValid)
                    fnImage = "Data/" + guids.imageAsset.ToString();
                if (guids.maskAsset.IsValid)
                    fnMask = "Data/" + guids.maskAsset.ToString();
            }
            else
            {
                fnImage = man.GetBufferAsString<Image2DLoadFromFileImageFile>(e);
                fnMask = man.GetBufferAsString<Image2DLoadFromFileMaskFile>(e);
            }

            imgHTML.imageIndex = ImageIOHTMLNativeCalls.JSLoadImage(fnImage, fnMask);
        }

        public LoadResult CheckLoading(IntPtr wrapper, EntityManager man, Entity e, ref Image2D image, ref Image2DHTML imgHTML,
            ref Image2DLoadFromFile unused, ref Image2DHTMLLoading loading)
        {
            int r = ImageIOHTMLNativeCalls.JSCheckLoadImage(imgHTML.imageIndex);
            if (r == 0)
                return LoadResult.stillWorking;

            var fnLog = man.GetBufferAsString<Image2DLoadFromFileImageFile>(e);
            if (man.HasComponent<Image2DLoadFromFileMaskFile>(e))
            {
                fnLog += " alpha=";
                fnLog += man.GetBufferAsString<Image2DLoadFromFileMaskFile>(e);
            }

            if (r == 2)
            {
                image.status = ImageStatus.LoadError;
                image.imagePixelHeight = 0;
                image.imagePixelWidth = 0;
                FreeNative(man, e, ref imgHTML);
                Debug.Log("Failed to load " + fnLog);
                return LoadResult.failed;
            }

            int wi = 0;
            int hi = 0;
            int ai = 0;
            ImageIOHTMLNativeCalls.JSFinishLoadImage(imgHTML.imageIndex, ref wi, ref hi, ref ai);
            image.imagePixelHeight = hi;
            image.imagePixelWidth = wi;
            image.status = ImageStatus.Loaded;
            imgHTML.externalOwner = false;
#if IO_ENABLE_TRACE
            var s = $"Loaded image: {fnLog} size: {wi}, {hi} ";
            if (ai != 0) s += " (has alpha channel)";
            s += $" idx: {imgHTML.imageIndex}";
            Debug.Log(s);
#endif
#if ENABLE_DOTSPLAYER_PROFILER
            ProfilerStats.AccumStats.memTextureCount.Accumulate(1);
            long bytes = image.imagePixelWidth * image.imagePixelHeight * 4;
            ProfilerStats.AccumStats.memTexture.Accumulate(bytes);
            ProfilerStats.AccumStats.memReservedGFX.Accumulate(bytes);
            ProfilerStats.AccumStats.memUsedGFX.Accumulate(bytes);

            // WebGL image loading doesn't use our unsafeutility heap allocator so we need to track our own stats
            ProfilerStats.AccumStats.memReservedExternal.Accumulate(bytes);
            ProfilerStats.AccumStats.memUsedExternal.Accumulate(bytes);
#endif

            return LoadResult.success;
        }

        public void FreeNative(EntityManager man, Entity e, ref Image2DHTML imgHTML)
        {
            if (!imgHTML.externalOwner && imgHTML.imageIndex > 0)
            {
                ImageIOHTMLNativeCalls.JSFreeImage(imgHTML.imageIndex);
#if ENABLE_DOTSPLAYER_PROFILER
                int w = 0, h = 0;
                unsafe
                {
                    ImageIOHTMLNativeCalls.JSGetImageInfo(imgHTML.imageIndex, ref w, ref h);
                }
                if (w != 0 && h != 0)
                {
                    ProfilerStats.AccumStats.memTextureCount.Accumulate(-1);
                    long bytes = -w * h * 4;
                    ProfilerStats.AccumStats.memTexture.Accumulate(bytes);
                    ProfilerStats.AccumStats.memReservedGFX.Accumulate(bytes);
                    ProfilerStats.AccumStats.memUsedGFX.Accumulate(bytes);

                    // WebGL image loading doesn't use our unsafeutility heap allocator so we need to track our own stats
                    ProfilerStats.AccumStats.memReservedExternal.Accumulate(bytes);
                    ProfilerStats.AccumStats.memUsedExternal.Accumulate(bytes);
                }
#endif
            }
            if (imgHTML.imageIndex > 0)
            {
                var s = "Free HTML image at ";
                s += imgHTML.imageIndex.ToString();
                Console.WriteLine(s);
            }
            imgHTML.imageIndex = 0;
            imgHTML.externalOwner = false;
        }

        public void FinishLoading(EntityManager man, Entity e, ref Image2D img, ref Image2DHTML imgHTML,
            ref Image2DHTMLLoading loading)
        {
        }
    }

    [UpdateInGroup(typeof(InitializationSystemGroup))]
    public class Image2DIOHTMLSystem : GenericAssetLoader<Image2D, Image2DHTML, Image2DLoadFromFile, Image2DHTMLLoading>
    {
        protected override void OnCreate()
        {
            base.OnCreate();
            c = new Image2DIOHTMLLoader();
            ImageIOHTMLNativeCalls.JSInitImageLoading();
        }

        protected override void OnUpdate()
        {
            // loading
            base.OnUpdate();
        }
    }
}
