#include <Unity/Runtime.h>

#include <dlfcn.h>
#include <jni.h>
#include <android/log.h>
#include <android/asset_manager.h>
#include <android/asset_manager_jni.h>
#include <android/native_window_jni.h>
#include <android/window.h>
#include <unistd.h>
#include <stdlib.h>
#include <stdio.h>
#include <sys/stat.h>
#include <math.h>
#include <time.h>
#include <vector>
#include <string>
#include <mutex>
#include <AndroidWrapper.h>
#include "AndroidSensors.h"

static JavaVM* gJavaVm = NULL;
static jobject tinyActivity = NULL;
static void* m_libmain = NULL;
static bool shouldClose = false;
static int windowW = 0;
static int windowH = 0;
static int screenW = 0;
static int screenH = 0;
static int deviceOrientation = 0;
static int screenOrientation = 0;
static ANativeWindow *nativeWindow = NULL;
// input
static std::vector<int> touch_info_stream;
static std::vector<int> key_stream;
static std::mutex key_stream_lock;
static std::mutex touch_stream_lock;
// c# delegates
static bool (*raf)(double) = 0;
static void (*pausef)(int) = 0;
static void (*destroyf)() = 0;
static void (*screen_orientationf)(int) = 0;
static void (*device_orientationf)(int) = 0;

DOTS_EXPORT(jobject)
get_activity()
{
    return tinyActivity;
}

DOTS_EXPORT(JavaVM*)
get_javavm()
{
    return gJavaVm;
}

DOTS_EXPORT(jobject)
Unity_Get_AndroidActivity()
{
    return tinyActivity;
}

DOTS_EXPORT(JavaVM*)
Unity_Get_JavaVM()
{
    return gJavaVm;
}

DOTS_EXPORT(bool)
init_android() {
    __android_log_print(ANDROID_LOG_INFO, "AndroidWrapper", "Android C Init\n");
    return true;
}

DOTS_EXPORT(void)
getWindowSize_android(int *width, int *height) {
    *width = windowW;
    *height = windowH;
}

DOTS_EXPORT(void)
getScreenSize_android(int *width, int *height) {
    *width = screenW;
    *height = screenH;
}

DOTS_EXPORT(void)
shutdown_android(int exitCode) {
    // TODO: call something to kill app
    raf = 0;
}

DOTS_EXPORT(bool)
messagePump_android() {
    return !shouldClose;
}

DOTS_EXPORT(double)
time_android() {
    static double start_time = -1;
    struct timespec res;
    clock_gettime(CLOCK_REALTIME, &res);
    double t = res.tv_sec + (double) res.tv_nsec / 1e9;
    if (start_time < 0) {
        start_time = t;
    }
    return t - start_time;
}

DOTS_EXPORT(bool)
rafcallbackinit_android(bool (*func)(double)) {
    if (raf)
        return false;
    raf = func;
    return true;
}

DOTS_EXPORT(bool)
pausecallbackinit_android(void (*func)(int)) {
    if (pausef)
        return false;
    pausef = func;
    return true;
}

DOTS_EXPORT(bool)
destroycallbackinit_android(void (*func)()) {
    if (destroyf)
        return false;
    destroyf = func;
    return true;
}

DOTS_EXPORT(bool)
screen_orientationcallbackinit_android(void (*func)(int)) {
    if (screen_orientationf)
        return false;
    screen_orientationf = func;
    if (screen_orientationf)
        screen_orientationf(screenOrientation);
    return true;
}

DOTS_EXPORT(bool)
device_orientationcallbackinit_android(void (*func)(int)) {
    if (device_orientationf)
        return false;
    device_orientationf = func;
    if (device_orientationf)
        device_orientationf(deviceOrientation);
    return true;
}

DOTS_EXPORT(void)
input_streams_lock_android(bool lock)
{
    if (lock)
    {
        key_stream_lock.lock();
        touch_stream_lock.lock();
    }
    else
    {
        key_stream_lock.unlock();
        touch_stream_lock.unlock();
    }
    m_AndroidSensors.LockSensorsData(lock);
}

DOTS_EXPORT(const int*)
get_touch_info_stream_android(int *len) {
    if (len == NULL)
        return NULL;
    *len = (int)touch_info_stream.size();
    return touch_info_stream.data();
}

DOTS_EXPORT(const int *)
get_key_stream_android(int *len)
{
    *len = (int)key_stream.size();
    return key_stream.data();
}

DOTS_EXPORT(void)
reset_input_android()
{
    touch_info_stream.clear();
    key_stream.clear();
    m_AndroidSensors.ResetSensorsData();
}

DOTS_EXPORT(int64_t)
get_native_window_android()
{
    return (int64_t)nativeWindow ;
}

DOTS_EXPORT(bool)
available_sensor_android(int type)
{
    return m_AndroidSensors.AvailableSensor(type);
}

DOTS_EXPORT(bool)
enable_sensor_android(int type, bool enable, int rate)
{
    return m_AndroidSensors.EnableSensor(type, enable, rate);
}

DOTS_EXPORT(const double*)
get_sensor_stream_android(int type, int *len)
{
    if (len == NULL)
        return NULL;
    return m_AndroidSensors.GetSensorData(type, len);
}

DOTS_EXPORT(void)
set_resolution_android(int width, int height)
{
    if (windowW != width || windowH != height)
    {
        JavaVMThreadScope javaVM;
        JNIEnv* env = javaVM.GetEnv();
        jclass clazz = env->FindClass("com/unity3d/tinyplayer/UnityTinyActivity");
        jmethodID setResolution = env->GetStaticMethodID(clazz, "setResolution", "(II)V");
        env->CallStaticVoidMethod(clazz, setResolution, width, height);
        windowW = width;
        windowH = height;
    }
}

DOTS_EXPORT(bool)
set_orientation_android(int orientation)
{
    JavaVMThreadScope javaVM;
    JNIEnv* env = javaVM.GetEnv();
    jclass clazz = env->FindClass("com/unity3d/tinyplayer/UnityTinyActivity");
    jmethodID setOrientation = env->GetStaticMethodID(clazz, "changeOrientation", "(I)Z");
    return env->CallStaticBooleanMethod(clazz, setOrientation, orientation);
}

DOTS_EXPORT(bool)
is_orientation_allowed_android(int orientation)
{
    JavaVMThreadScope javaVM;
    JNIEnv* env = javaVM.GetEnv();
    jclass clazz = env->FindClass("com/unity3d/tinyplayer/UnityTinyActivity");
    jmethodID isOrientationAllowed = env->GetStaticMethodID(clazz, "isAllowed", "(I)Z");
    return env->CallStaticBooleanMethod(clazz, isOrientationAllowed, orientation);
}

DOTS_EXPORT(int)
get_natural_orientation_android()
{
    JavaVMThreadScope javaVM;
    JNIEnv* env = javaVM.GetEnv();
    jclass clazz = env->FindClass("com/unity3d/tinyplayer/UnityTinyActivity");
    jmethodID getNaturalOrientation = env->GetStaticMethodID(clazz, "getNaturalOrientation", "()I");
    return env->CallStaticIntMethod(clazz, getNaturalOrientation);
}

#if UNITY_DOTSRUNTIME_IL2CPP_WAIT_FOR_MANAGED_DEBUGGER

typedef void(*BroadcastFunction)();
static BroadcastFunction s_Broadcast = NULL;

DOTS_EXPORT(void)
show_debug_dialog(const char* message)
{
    JavaVMThreadScope javaVM;
    JNIEnv* env = javaVM.GetEnv();
    jclass clazz = env->FindClass("com/unity3d/tinyplayer/UnityTinyActivity");
    jmethodID showAlertDialog = env->GetStaticMethodID(clazz, "showDebugDialog", "(Ljava/lang/String;)V");
    jstring jmessage = env->NewStringUTF(message);
    env->CallStaticVoidMethod(clazz, showAlertDialog, jmessage);
    env->DeleteLocalRef(jmessage);
}

DOTS_EXPORT(void)
ShowDebuggerAttachDialog(const char* message, BroadcastFunction broadcast)
{
    s_Broadcast = broadcast;
    show_debug_dialog(message);
}

extern "C"
JNIEXPORT void JNICALL Java_com_unity3d_tinyplayer_UnityTinyAndroidJNILib_broadcastDebuggerMessage()
{
    if (s_Broadcast != NULL)
        s_Broadcast();
}

#endif // UNITY_DOTSRUNTIME_IL2CPP_WAIT_FOR_MANAGED_DEBUGGER

extern "C"
JNIEXPORT void JNICALL Java_com_unity3d_tinyplayer_UnityTinyAndroidJNILib_setActivity(JNIEnv * env, jobject obj, jobject activity)
{
    tinyActivity = env->NewGlobalRef(activity);
}

extern "C"
JNIEXPORT void JNICALL Java_com_unity3d_tinyplayer_UnityTinyAndroidJNILib_start(JNIEnv * env, jobject obj, jstring name)
{
    env->GetJavaVM(&gJavaVm);

    // to initialize time
    time_android();

    m_AndroidSensors.InitializeSensors();

    typedef void(*fp_main)();
    fp_main mainfunc;
    const char* mainlib = env->GetStringUTFChars(name, NULL);
    __android_log_print(ANDROID_LOG_INFO, "AndroidWrapper", "mainlib name: %s", mainlib);
    m_libmain = dlopen(mainlib, RTLD_NOW | RTLD_LOCAL);
    env->ReleaseStringUTFChars(name, mainlib);
    if (m_libmain)
    {
        mainfunc = reinterpret_cast<fp_main>(dlsym(m_libmain, "start"));
        if (mainfunc)
        {
            mainfunc();
            return;
        }
    }
    __android_log_print(ANDROID_LOG_INFO, "AndroidWrapper", "%s", dlerror());
}

#if STATIC_LINKING
extern "C"
JNIEXPORT void setNativeAssetManager(AAssetManager *assetManager);
#endif
extern "C"
JNIEXPORT void JNICALL Java_com_unity3d_tinyplayer_UnityTinyAndroidJNILib_setAssetManager(JNIEnv* env, jobject obj, jobject assetManager)
{
    __android_log_print(ANDROID_LOG_INFO, "AndroidWrapper", "UnityTinyAndroidJNILib_setAssetManager\n");
#if STATIC_LINKING
    setNativeAssetManager(AAssetManager_fromJava(env, assetManager));
#else
    void *libio = dlopen("lib_unity_tiny_io.so", RTLD_NOW | RTLD_LOCAL);
    if (libio != NULL)
    {
        typedef void (*fp_setNativeAssetManager)(AAssetManager *assetManager);
        fp_setNativeAssetManager setNativeAssetManager = reinterpret_cast<fp_setNativeAssetManager>(dlsym(libio, "setNativeAssetManager"));
        if (setNativeAssetManager != NULL)
        {
            setNativeAssetManager(AAssetManager_fromJava(env, assetManager));
        }
        dlclose(libio);
    }
#endif
}

extern "C"
JNIEXPORT void JNICALL Java_com_unity3d_tinyplayer_UnityTinyAndroidJNILib_init(JNIEnv* env, jobject obj, jobject surface, jint width, jint height)
{
    __android_log_print(ANDROID_LOG_INFO, "AndroidWrapper", "UnityTinyAndroidJNILib_init\n");
    if (nativeWindow != NULL)
        ANativeWindow_release(nativeWindow);
    nativeWindow = surface != NULL ? ANativeWindow_fromSurface(env, surface) : NULL;
    windowW = width;
    windowH = height;
}

extern "C"
JNIEXPORT void JNICALL Java_com_unity3d_tinyplayer_UnityTinyAndroidJNILib_step(JNIEnv* env, jobject obj)
{
    if (raf && !raf(time_android()))
        shutdown_android(2);
}

extern "C"
JNIEXPORT void JNICALL Java_com_unity3d_tinyplayer_UnityTinyAndroidJNILib_pause(JNIEnv* env, jobject obj, jint paused)
{
    if (pausef)
        pausef(paused);
}

extern "C"
JNIEXPORT void JNICALL Java_com_unity3d_tinyplayer_UnityTinyAndroidJNILib_destroy(JNIEnv* env, jobject obj)
{
    if (destroyf)
        destroyf();
    if (m_libmain)
        dlclose(m_libmain);
    m_AndroidSensors.ShutdownSensors();
    if (tinyActivity != NULL)
    {
        env->DeleteGlobalRef(tinyActivity);
        tinyActivity = NULL;
    }
}

extern "C"
JNIEXPORT void JNICALL Java_com_unity3d_tinyplayer_UnityTinyAndroidJNILib_touchevent(JNIEnv* env, jobject obj, jint id, jint action, jint xpos, jint ypos)
{
    std::lock_guard<std::mutex> lock(touch_stream_lock);
    touch_info_stream.push_back((int)id);
    touch_info_stream.push_back((int)action);
    touch_info_stream.push_back((int)xpos * windowW / screenW);
    touch_info_stream.push_back(windowH - 1 - (int)ypos * windowH / screenH);
}

extern "C"
JNIEXPORT void JNICALL Java_com_unity3d_tinyplayer_UnityTinyAndroidJNILib_keyevent(JNIEnv* env, jobject obj, jint key, jint scancode, jint action, jint mods)
{
    __android_log_print(ANDROID_LOG_INFO, "AndroidWrapper", "Key %d scancode %d action %d mods %d\n", key, scancode, action, mods);
    std::lock_guard<std::mutex> lock(key_stream_lock);
    key_stream.push_back(key);
    key_stream.push_back(scancode);
    key_stream.push_back(action);
    key_stream.push_back(mods);
}

extern "C"
JNIEXPORT void JNICALL Java_com_unity3d_tinyplayer_UnityTinyAndroidJNILib_screenSizeChanged(JNIEnv* env, jobject obj, jint width, jint height)
{
    screenW = width;
    screenH = height;
}

extern "C"
JNIEXPORT void JNICALL Java_com_unity3d_tinyplayer_UnityTinyAndroidJNILib_screenOrientationChanged(JNIEnv* env, jobject obj, jint orientation)
{
    screenOrientation = orientation;
    if (screen_orientationf)
        screen_orientationf(orientation);
}

extern "C"
JNIEXPORT void JNICALL Java_com_unity3d_tinyplayer_UnityTinyAndroidJNILib_deviceOrientationChanged(JNIEnv* env, jobject obj, jint orientation)
{
    deviceOrientation = orientation;
    if (device_orientationf)
        device_orientationf(orientation);
}
