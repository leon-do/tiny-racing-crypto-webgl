#if UNITY_ANDROID
#include <jni.h>
#include <android/log.h>
#include <android/asset_manager.h>
#include <android/asset_manager_jni.h>

static AAssetManager *nativeAssetManager = NULL;

extern "C"
JNIEXPORT void setNativeAssetManager(AAssetManager *assetManager)
{
    nativeAssetManager = assetManager;
}

extern "C"
JNIEXPORT void* loadAsset(const char *path, int *size, void* (*alloc)(size_t))
{
    AAsset* asset = AAssetManager_open(nativeAssetManager, path, AASSET_MODE_STREAMING);
    if (asset == NULL)
    {
        __android_log_print(ANDROID_LOG_INFO, "AndroidLoader", "can't read asset %s", path);
        return NULL;
    }
    else
    {
        *size = (int)AAsset_getLength(asset);
        void* data = alloc(*size);
        unsigned char *ptr = (unsigned char*)data;
        int remaining = (int)AAsset_getRemainingLength(asset);
        int nb_read = 0;
        while (remaining > 0)
        {
            nb_read = AAsset_read(asset, ptr, 1000 * 1024); // 1Mb is maximum chunk size for compressed assets
            if (nb_read > 0) ptr += nb_read;
            remaining = AAsset_getRemainingLength64(asset);
        }
        AAsset_close(asset);
        return data;
    }
}
#endif
