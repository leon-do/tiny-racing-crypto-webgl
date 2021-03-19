package com.unity3d.tinyplayer;

import android.app.Activity;
import android.app.AlertDialog;
import android.os.Handler;
import android.os.Bundle;
import android.os.Process;
import android.util.Log;
import android.view.MotionEvent;
import android.view.View;
import android.view.Window;
import android.view.WindowManager;
import android.view.Surface;
import android.view.KeyEvent;
import android.view.OrientationEventListener;
import android.hardware.SensorManager;
import android.content.Context;
import android.content.res.AssetManager;
import android.content.res.Configuration;
import android.content.pm.ActivityInfo;
import android.content.DialogInterface;
import android.provider.Settings;
import android.database.ContentObserver;
import java.io.File;
import java.util.concurrent.Semaphore;

public class UnityTinyActivity extends Activity {

    static UnityTinyActivity sActivity;

    private UnityTinyView mView;
    private AssetManager mAssetManager;
    private OrientationEventListener mOrientationListener;
    private WindowManager mWindowManager;
    private ContentObserver mRotationObserver;

    private static final String TAG = "UnityTinyActivity";

    @Override protected void onCreate(Bundle bundle) {
        super.onCreate(bundle);

        sActivity = this;
        UnityTinyAndroidJNILib.setActivity(this);
        requestWindowFeature(Window.FEATURE_NO_TITLE);
        mAssetManager = getAssets();
        mView = new UnityTinyView(mAssetManager, getCacheDir().getAbsolutePath(), this);
        mView.setOnTouchListener(new View.OnTouchListener() {

            public boolean onTouch(View v, MotionEvent event)
            {
                int action = event.getActionMasked();
                switch (action) {
                    case MotionEvent.ACTION_DOWN:
                    case MotionEvent.ACTION_POINTER_DOWN:
                    case MotionEvent.ACTION_UP:
                    case MotionEvent.ACTION_POINTER_UP:
                        {
                            int index = event.getActionIndex();
                            if (action == MotionEvent.ACTION_POINTER_DOWN) action = MotionEvent.ACTION_DOWN;
                            else if (action == MotionEvent.ACTION_POINTER_UP) action = MotionEvent.ACTION_UP;
                            UnityTinyAndroidJNILib.touchevent(event.getPointerId(index), action, (int)event.getX(index), (int)event.getY(index));
                        }
                        break;
                    case MotionEvent.ACTION_CANCEL:
                    case MotionEvent.ACTION_MOVE:
                        {
                            for (int i = 0; i < event.getPointerCount(); ++i)
                            {
                                int pointerId = event.getPointerId(i);
                                UnityTinyAndroidJNILib.touchevent(pointerId, action, (int)event.getX(i), (int)event.getY(i));
                            }
                        }
                        break;
                }
                return true;
            }
        });
        setContentView(mView);
        setFullScreen(true);
        mView.requestFocus();

        mOrientationListener = new OrientationEventListener(this, SensorManager.SENSOR_DELAY_NORMAL) {

            @Override
            public void onOrientationChanged(int angle)
            {
                processOrientationChange(angle);
            }
        };

        if (!mOrientationListener.canDetectOrientation())
        {
            Log.v(TAG, "Cannot detect orientation");
            mOrientationListener.disable();
        }

        mRotationObserver = new ContentObserver(new Handler()) {

            @Override
            public void onChange(boolean selfChange) {
                mIsOrientationLocked = getOrientationLocked();
                Log.d(TAG, "Change orientation locked: " + mIsOrientationLocked);
                if (!mIsOrientationLocked && isAllowed(mDeviceOrientation))
                {
                    mView.onOrientationChanged(mDeviceOrientation);
                }
                super.onChange(selfChange);
            }

            @Override
            public boolean deliverSelfNotifications() {
                return true;
            }
        };

        mWindowManager = (WindowManager)getSystemService(Context.WINDOW_SERVICE);
        Configuration config = getResources().getConfiguration();
        mNaturalOrientation = getNaturalOrientation(config.orientation);
        Log.d(TAG, "Natural device orientation: " + (mNaturalOrientation == ActivityInfo.SCREEN_ORIENTATION_LANDSCAPE ? "Landscape" : "Portrait"));
        mDeviceOrientation = getActualOrientation(config.orientation);
        Log.d(TAG, "Start device orientation: " + mDeviceOrientation);
        mDeviceOrientation = getBestAllowed(mDeviceOrientation);
        Log.d(TAG, "Start allowed orientation: " + mDeviceOrientation);
        mScreenOrientation = mDeviceOrientation;
        UnityTinyAndroidJNILib.screenOrientationChanged(mDeviceOrientation);
        mView.onOrientationChanged(mDeviceOrientation);
        setRequestedOrientation(mDeviceOrientation);
    }

    @Override protected void onPause() {
        stopOrientationProcessing();
        mView.onPause();
        super.onPause();
    }

    @Override protected void onResume() {
        super.onResume();
        startOrientationProcessing();
        mView.onResume();
        setFullScreen(true);
    }

    private static int sFullscreenFlags =
            View.SYSTEM_UI_FLAG_IMMERSIVE_STICKY |
            View.SYSTEM_UI_FLAG_LAYOUT_STABLE |
            View.SYSTEM_UI_FLAG_LAYOUT_FULLSCREEN |
            View.SYSTEM_UI_FLAG_LAYOUT_HIDE_NAVIGATION |
            View.SYSTEM_UI_FLAG_HIDE_NAVIGATION |
            View.SYSTEM_UI_FLAG_FULLSCREEN;

    private void setFullScreen(boolean fullScreen)
    {
        int windowFlags = fullScreen ?
            mView.getSystemUiVisibility() | sFullscreenFlags :
            mView.getSystemUiVisibility() & ~sFullscreenFlags;
        mView.setSystemUiVisibility(windowFlags);
    }

    @Override protected void onDestroy() {
        mView.onDestroy();
        super.onDestroy();
        Process.killProcess(Process.myPid());
    }

    @Override public boolean onKeyUp(int keyCode, KeyEvent event)
    {
        UnityTinyAndroidJNILib.keyevent(event.getKeyCode(), event.getScanCode(), event.getAction(), event.getMetaState());
        // volume up/down keys need to be processed by system
        return event.getKeyCode() != KeyEvent.KEYCODE_VOLUME_DOWN &&
               event.getKeyCode() != KeyEvent.KEYCODE_VOLUME_UP;
    }

    @Override public boolean onKeyDown(int keyCode, KeyEvent event)
    {
        UnityTinyAndroidJNILib.keyevent(event.getKeyCode(), event.getScanCode(), event.getAction(), event.getMetaState());
        // volume up/down keys need to be processed by system
        return event.getKeyCode() != KeyEvent.KEYCODE_VOLUME_DOWN &&
               event.getKeyCode() != KeyEvent.KEYCODE_VOLUME_UP;
    }

    public static UnityTinyActivity getActivity()
    {
        return sActivity;
    }

    private final int k_AngleThreshold = 25;
    private boolean mIsOrientationLocked;
    private int mDeviceOrientation;
    private int mScreenOrientation;
    private int mNaturalOrientation;
    private void processOrientationChange(int angle)
    {
        if (angle == -1)
        {
            // angle unknown, do nothing
            return;
        }

        int deviceOrientation = mDeviceOrientation;
        if (mNaturalOrientation == ActivityInfo.SCREEN_ORIENTATION_PORTRAIT)
        {
            if (angle < k_AngleThreshold || angle > 360 - k_AngleThreshold)
            {
                deviceOrientation = ActivityInfo.SCREEN_ORIENTATION_PORTRAIT;
            }
            else if (angle > 90 - k_AngleThreshold && angle < 90 + k_AngleThreshold)
            {
                deviceOrientation = ActivityInfo.SCREEN_ORIENTATION_REVERSE_LANDSCAPE;
            }
            else if (angle > 180 - k_AngleThreshold && angle < 180 + k_AngleThreshold)
            {
                deviceOrientation = ActivityInfo.SCREEN_ORIENTATION_REVERSE_PORTRAIT;
            }
            else if (angle > 270 - k_AngleThreshold && angle < 270 + k_AngleThreshold)
            {
                deviceOrientation = ActivityInfo.SCREEN_ORIENTATION_LANDSCAPE;
            }
        }
        else // ActivityInfo.SCREEN_ORIENTATION_LANDSCAPE
        {
            if (angle < k_AngleThreshold || angle > 360 - k_AngleThreshold)
            {
                deviceOrientation = ActivityInfo.SCREEN_ORIENTATION_LANDSCAPE;
            }
            else if (angle > 90 - k_AngleThreshold && angle < 90 + k_AngleThreshold)
            {
                deviceOrientation = ActivityInfo.SCREEN_ORIENTATION_PORTRAIT;
            }
            else if (angle > 180 - k_AngleThreshold && angle < 180 + k_AngleThreshold)
            {
                deviceOrientation = ActivityInfo.SCREEN_ORIENTATION_REVERSE_LANDSCAPE;
            }
            else if (angle > 270 - k_AngleThreshold && angle < 270 + k_AngleThreshold)
            {
                deviceOrientation = ActivityInfo.SCREEN_ORIENTATION_REVERSE_PORTRAIT;
            }
        }
        if (deviceOrientation != mDeviceOrientation)
        {
            mDeviceOrientation = deviceOrientation;
            if (!mIsOrientationLocked && isAllowed(mDeviceOrientation))
            {
                mView.onOrientationChanged(mDeviceOrientation);
            }
        }
    }

    @Override
    public void onConfigurationChanged(Configuration newConfig)
    {
        super.onConfigurationChanged(newConfig);
        int newOrientation = getActualOrientation(newConfig.orientation);
        Log.d(TAG, "screenOrientationChanged " + newOrientation);
        UnityTinyAndroidJNILib.screenOrientationChanged(newOrientation);
    }

    public static void setResolution(int width, int height)
    {
        sActivity.runOnUiThread(()->
        {
            Log.d(TAG, "setFixedResolution " + width + " x " + height);
            sActivity.mView.setFixedResolution(width, height);
        });
    }

    public static boolean changeOrientation(int orientation)
    {
        if (isAllowed(orientation))
        {
            Log.d(TAG, "changeOrientation " + orientation);
            sActivity.changeOrientationInternal(orientation);
            return true;
        }
        return false;
    }

    public static int getNaturalOrientation()
    {
        return sActivity.mNaturalOrientation;
    }

    private void changeOrientationInternal(int orientation)
    {
        if (orientation != mScreenOrientation)
        {
            if (isLandscape(orientation) ^ isLandscape(mScreenOrientation))
            {
                // disabling surface until it is not updated if new and old orientations are not both portrait or landscape
                mView.surfaceDisabled();
            }
            mScreenOrientation = orientation;
            setRequestedOrientation(orientation);
        }
    }

    private boolean isLandscape(int orientation)
    {
        return orientation == ActivityInfo.SCREEN_ORIENTATION_LANDSCAPE || orientation == ActivityInfo.SCREEN_ORIENTATION_REVERSE_LANDSCAPE;
    }

    private boolean getOrientationLocked()
    {
        try
        {
            return Settings.System.getInt(getContentResolver(), Settings.System.ACCELEROMETER_ROTATION) == 0;
        }
        catch (Settings.SettingNotFoundException e)
        {
            return false;
        }
    }

    private int getNaturalOrientation(int orientation)
    {
        int angle = mWindowManager.getDefaultDisplay().getRotation();
        if (((angle == Surface.ROTATION_0 || angle == Surface.ROTATION_180) && orientation == Configuration.ORIENTATION_LANDSCAPE) ||
            ((angle == Surface.ROTATION_90 || angle == Surface.ROTATION_270) && orientation == Configuration.ORIENTATION_PORTRAIT))
        {
            return ActivityInfo.SCREEN_ORIENTATION_LANDSCAPE;
        }
        else
        {
            return ActivityInfo.SCREEN_ORIENTATION_PORTRAIT;
        }
    }

    private int getActualOrientation(int orientation)
    {
        int angle = mWindowManager.getDefaultDisplay().getRotation();
        if (mNaturalOrientation == ActivityInfo.SCREEN_ORIENTATION_PORTRAIT)
        {
            if (orientation == Configuration.ORIENTATION_LANDSCAPE)
            {
                if (angle == Surface.ROTATION_270)
                    return ActivityInfo.SCREEN_ORIENTATION_REVERSE_LANDSCAPE;
                else
                    return ActivityInfo.SCREEN_ORIENTATION_LANDSCAPE;
            }
            if (orientation == Configuration.ORIENTATION_PORTRAIT)
            {
                if (angle == Surface.ROTATION_180)
                    return ActivityInfo.SCREEN_ORIENTATION_REVERSE_PORTRAIT;
                else
                    return ActivityInfo.SCREEN_ORIENTATION_PORTRAIT;
            }
        }
        else // ActivityInfo.SCREEN_ORIENTATION_LANDSCAPE
        {
            if (orientation == Configuration.ORIENTATION_LANDSCAPE)
            {
                if (angle == Surface.ROTATION_180)
                    return ActivityInfo.SCREEN_ORIENTATION_REVERSE_LANDSCAPE;
                else
                    return ActivityInfo.SCREEN_ORIENTATION_LANDSCAPE;
            }
            if (orientation == Configuration.ORIENTATION_PORTRAIT)
            {
                if (angle == Surface.ROTATION_90)
                    return ActivityInfo.SCREEN_ORIENTATION_REVERSE_PORTRAIT;
                else
                    return ActivityInfo.SCREEN_ORIENTATION_PORTRAIT;
            }
        }
        // unknown
        return mNaturalOrientation;
    }

    public static boolean isAllowed(int orientation)
    {
        if (orientation == ActivityInfo.SCREEN_ORIENTATION_PORTRAIT)
        {
            return AllowedOrientations.AllowedPortrait;
        }
        if (orientation == ActivityInfo.SCREEN_ORIENTATION_REVERSE_PORTRAIT)
        {
            return AllowedOrientations.AllowedReversePortrait;
        }
        if (orientation == ActivityInfo.SCREEN_ORIENTATION_LANDSCAPE)
        {
            return AllowedOrientations.AllowedLandscape;
        }
        if (orientation == ActivityInfo.SCREEN_ORIENTATION_REVERSE_LANDSCAPE)
        {
            return AllowedOrientations.AllowedReverseLandscape;
        }
        return false;
    }

    private static int getBestAllowed(int orientation)
    {
        if (isAllowed(orientation))
        {
            return orientation;
        }
        if (orientation == ActivityInfo.SCREEN_ORIENTATION_PORTRAIT && isAllowed(ActivityInfo.SCREEN_ORIENTATION_REVERSE_PORTRAIT))
        {
            return ActivityInfo.SCREEN_ORIENTATION_REVERSE_PORTRAIT;
        }
        if (orientation == ActivityInfo.SCREEN_ORIENTATION_REVERSE_PORTRAIT && isAllowed(ActivityInfo.SCREEN_ORIENTATION_PORTRAIT))
        {
            return ActivityInfo.SCREEN_ORIENTATION_PORTRAIT;
        }
        if (orientation == ActivityInfo.SCREEN_ORIENTATION_LANDSCAPE && isAllowed(ActivityInfo.SCREEN_ORIENTATION_REVERSE_LANDSCAPE))
        {
            return ActivityInfo.SCREEN_ORIENTATION_REVERSE_LANDSCAPE;
        }
        if (orientation == ActivityInfo.SCREEN_ORIENTATION_REVERSE_LANDSCAPE && isAllowed(ActivityInfo.SCREEN_ORIENTATION_LANDSCAPE))
        {
            return ActivityInfo.SCREEN_ORIENTATION_LANDSCAPE;
        }
        if (isAllowed(ActivityInfo.SCREEN_ORIENTATION_PORTRAIT))
        {
            return ActivityInfo.SCREEN_ORIENTATION_PORTRAIT;
        }
        if (isAllowed(ActivityInfo.SCREEN_ORIENTATION_LANDSCAPE))
        {
            return ActivityInfo.SCREEN_ORIENTATION_LANDSCAPE;
        }
        if (isAllowed(ActivityInfo.SCREEN_ORIENTATION_REVERSE_PORTRAIT))
        {
            return ActivityInfo.SCREEN_ORIENTATION_REVERSE_PORTRAIT;
        }
        if (isAllowed(ActivityInfo.SCREEN_ORIENTATION_REVERSE_LANDSCAPE))
        {
            return ActivityInfo.SCREEN_ORIENTATION_REVERSE_LANDSCAPE;
        }
        //shoudn't happen
        return orientation;
    }

    private void startOrientationProcessing()
    {
        mIsOrientationLocked = getOrientationLocked();
        Log.d(TAG, "Orientation locked: "+ mIsOrientationLocked);

        Configuration config = getResources().getConfiguration();
        mDeviceOrientation = getActualOrientation(config.orientation);
        if (!mIsOrientationLocked && isAllowed(mDeviceOrientation))
        {
            mView.onOrientationChanged(mDeviceOrientation);
        }

        if (mOrientationListener.canDetectOrientation())
        {
            mOrientationListener.enable();
        }
        getContentResolver().registerContentObserver(Settings.System.getUriFor(Settings.System.ACCELEROMETER_ROTATION), false, mRotationObserver);
    }

    private void stopOrientationProcessing()
    {
        mOrientationListener.disable();
        getContentResolver().unregisterContentObserver(mRotationObserver);
    }

    private AlertDialog debugDialog;
    private final Semaphore dialogSemaphore = new Semaphore(0, true);
    private void debugDialog(String message)
    {
        debugDialog = null;
        Runnable debugDialogProcess = new Runnable()
        {
            public void run()
            {
                debugDialog = new AlertDialog.Builder(sActivity).create();
                debugDialog.setTitle("Debug");
                debugDialog.setMessage(message);
                debugDialog.setButton(DialogInterface.BUTTON_NEUTRAL, "OK",
                    new DialogInterface.OnClickListener()
                    {
                        @Override
                        public void onClick(DialogInterface dialog, int which)
                        {
                            dialogSemaphore.release();
                        }
                    });
                debugDialog.setCancelable(false);
                debugDialog.show();
            }
        };

        runOnUiThread(debugDialogProcess);

        try
        {
            boolean acquired = false;
            while (!acquired)
            {
                acquired = dialogSemaphore.tryAcquire(100, java.util.concurrent.TimeUnit.MILLISECONDS);
                if (!acquired)
                    UnityTinyAndroidJNILib.broadcastDebuggerMessage();
            }
        }
        catch (InterruptedException e)
        {
            if (debugDialog != null)
            {
                debugDialog.dismiss();
            }
        }
    }

    public static void showDebugDialog(String message)
    {
        sActivity.debugDialog(message);
    }
}
