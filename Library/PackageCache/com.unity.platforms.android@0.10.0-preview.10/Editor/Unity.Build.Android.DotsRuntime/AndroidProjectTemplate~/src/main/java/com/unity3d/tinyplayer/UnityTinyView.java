package com.unity3d.tinyplayer;

import java.util.concurrent.Semaphore;
import java.util.concurrent.TimeUnit;
import android.app.Activity;
import android.content.Context;
import android.content.res.AssetManager;
import android.util.Log;
import android.view.View;
import android.view.SurfaceView;
import android.view.SurfaceHolder;
import android.os.Handler;
import android.os.Message;
import android.os.Looper;

class UnityTinyView extends SurfaceView implements SurfaceHolder.Callback
{
    enum RunStateEvent { PAUSE, RESUME, QUIT, ORIENTATION, NEXT_FRAME };
    private static final int RUN_STATE_CHANGED_MSG_CODE = 2269;
    private static final int ANR_TIMEOUT_SECONDS = 4;

    private class UnityTinyThread extends Thread
    {
        private static final String TAG = "UnityTinyThread";

        private Handler m_Handler;
        private SurfaceHolder m_Holder;
        private boolean m_Running = false;

        public boolean m_SurfaceAvailable = false;

        public UnityTinyThread(SurfaceHolder holder)
        {
            m_Holder = holder;
        }

        @Override
        public void run()
        {
            setName("DOTSMain");

            Looper.prepare();
            m_Handler = new Handler(new Handler.Callback()
            {
                public boolean handleMessage(Message msg)
                {
                    if (msg.what != RUN_STATE_CHANGED_MSG_CODE)
                        return false;

                    final RunStateEvent runState = (RunStateEvent)msg.obj;
                    if (runState == RunStateEvent.NEXT_FRAME)
                    {
                        if (!m_Running)
                            return true;

                        if (m_SurfaceAvailable)
                        {
                            UnityTinyAndroidJNILib.step();
                        }
                    }
                    else if (runState == RunStateEvent.QUIT)
                    {
                        Log.d(TAG, "Quit");
                        UnityTinyAndroidJNILib.destroy();
                        Looper.myLooper().quit();
                    }
                    else if (runState == RunStateEvent.RESUME)
                    {
                        Log.d(TAG, "Resume");
                        UnityTinyAndroidJNILib.pause(0);
                        m_Running = true;
                    }
                    else if (runState == RunStateEvent.PAUSE)
                    {
                        Log.d(TAG, "Pause");
                        UnityTinyAndroidJNILib.pause(1);
                        m_Running = false;
                    }
                    else if (runState == RunStateEvent.ORIENTATION)
                    {
                        Log.d(TAG, "Device orientation changed " + msg.arg1);
                        UnityTinyAndroidJNILib.deviceOrientationChanged(msg.arg1);
                    }

                    // trigger next frame
                    if (m_Running)
                        Message.obtain(m_Handler, RUN_STATE_CHANGED_MSG_CODE, RunStateEvent.NEXT_FRAME).sendToTarget();

                    return true;
                }
            });

            Log.d(TAG, "Calling JNILib.start");
            UnityTinyAndroidJNILib.start();

            Looper.loop();
        }

        public void quit()
        {
            dispatchRunStateEvent(RunStateEvent.QUIT);
        }

        public void resumeExecution()
        {
            dispatchRunStateEvent(RunStateEvent.RESUME);
        }

        public void orientationChanged(int orientation)
        {
            if (m_Handler != null)
                Message.obtain(m_Handler, RUN_STATE_CHANGED_MSG_CODE, orientation, 0, RunStateEvent.ORIENTATION).sendToTarget();
        }

        public void pauseExecution(Runnable runnable)
        {
            if (m_Handler == null)
                return;
            dispatchRunStateEvent(RunStateEvent.PAUSE);
            Message.obtain(m_Handler, runnable).sendToTarget();
        }

        private void dispatchRunStateEvent(RunStateEvent ev)
        {
            if (m_Handler != null)
                Message.obtain(m_Handler, RUN_STATE_CHANGED_MSG_CODE, ev).sendToTarget();
        }
    }

    private static final String TAG = "UnityTinyView";
    private UnityTinyThread m_Thread;
    private boolean m_FixedResolution = false;
    private int m_FixedWidth;
    private int m_FixedHeight;

    public UnityTinyView(AssetManager assetManager, String path, Context context)
    {
        super(context);

        getHolder().addCallback(this);
        UnityTinyAndroidJNILib.setAssetManager(assetManager);

        m_Thread = new UnityTinyThread(getHolder());
        m_Thread.start();
    }

    @Override
    public void onSizeChanged(int w, int h, int oldw, int oldh)
    {
        Log.d(TAG, "screenSizeChanged " + w + " x " + h);
        UnityTinyAndroidJNILib.screenSizeChanged(w, h);
    }

    @Override
    public void surfaceChanged(SurfaceHolder holder, int format, int width, int height)
    {
        Log.d(TAG, "surfaceChanged " + width + " x " + height);
        UnityTinyAndroidJNILib.init(holder.getSurface(), width, height);
        m_Thread.m_SurfaceAvailable = true;
    }

    @Override
    public void surfaceCreated(SurfaceHolder holder)
    {
        Log.d(TAG, "surfaceCreated");
        if (m_FixedResolution)
        {
            // there is no call of surfaceChanged in case of fixed resolution
            holder.setFixedSize(m_FixedWidth, m_FixedHeight);
            UnityTinyAndroidJNILib.init(holder.getSurface(), m_FixedWidth, m_FixedHeight);
            m_Thread.m_SurfaceAvailable = true;
        }
    }

    @Override
    public void surfaceDestroyed(SurfaceHolder holder)
    {
        Log.d(TAG, "surfaceDestroyed");
        m_Thread.m_SurfaceAvailable = false;
    }

    public void surfaceDisabled()
    {
        if (!m_FixedResolution)
        {
            // there is no need to disable surface in case of fixed resolution
            Log.d(TAG, "surfaceDisabled");
            m_Thread.m_SurfaceAvailable = false;
        }
    }

    public void setFixedResolution(int width, int height)
    {
        m_FixedResolution = true;
        m_FixedWidth = width;
        m_FixedHeight = height;
        getHolder().setFixedSize(width, height);
    }

    public void onPause()
    {
        Log.d(TAG, "Pause");

        final Semaphore synchronize = new Semaphore(0);

        Runnable runnable = new Runnable() { public void run(){
                synchronize.release();
            }};

        m_Thread.pauseExecution(runnable);

        try
        {
            if (!synchronize.tryAcquire(ANR_TIMEOUT_SECONDS, TimeUnit.SECONDS))
            {
                Log.w(TAG, "Timeout while trying to pause the Unity Engine.");
            }
        }
        catch (InterruptedException e)
        {
            Log.w(TAG, "UI thread got interrupted while trying to pause the Unity Engine.");
        }
    }

    public void onResume()
    {
        Log.d(TAG, "Resume");
        m_Thread.resumeExecution();
    }

    public void onDestroy()
    {
        Log.d(TAG, "Destroy");
        m_Thread.quit();
    }

    public void onOrientationChanged(int orientation)
    {
        Log.d(TAG, "Device orientation changed " + orientation);
        m_Thread.orientationChanged(orientation);
    }

}
