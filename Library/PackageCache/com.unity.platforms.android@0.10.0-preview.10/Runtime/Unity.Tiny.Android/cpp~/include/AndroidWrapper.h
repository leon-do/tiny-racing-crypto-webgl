#include <jni.h>
#include <android/log.h>

extern "C" {
    jobject get_activity() __attribute__ ((deprecated));
    JavaVM* get_javavm() __attribute__ ((deprecated));

    jobject Unity_Get_AndroidActivity();
    JavaVM* Unity_Get_JavaVM();
}

class JavaVMThreadScope
{
public:
    JavaVMThreadScope()
    {
        m_env = 0;
        m_detached = Unity_Get_JavaVM()->GetEnv((void**)&m_env, JNI_VERSION_1_2) == JNI_EDETACHED;
        if (m_detached)
        {
            Unity_Get_JavaVM()->AttachCurrentThread(&m_env, NULL);
        }
        CheckException();
    }

    ~JavaVMThreadScope()
    {
        CheckException();
        if (m_detached)
        {
            Unity_Get_JavaVM()->DetachCurrentThread();
        }
    }

    JNIEnv* GetEnv()
    {
        return m_env;
    }

private:
    JNIEnv* m_env;
    bool m_detached;

#if defined(DEBUG)
    void CheckException()
    {
        if (!m_env->ExceptionCheck())
            return;

        __android_log_print(ANDROID_LOG_INFO, "AndroidWrapper", "Java exception detected");
        m_env->ExceptionDescribe();
        m_env->ExceptionClear();
    }
#else
    void CheckException() {}
#endif
};

