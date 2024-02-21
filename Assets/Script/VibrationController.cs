using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrationController : MonoBehaviour
{
    private AndroidJavaObject vibrator;

    public void StartVibration(float duration)
    {
        if (vibrator == null)
        {
            AndroidJavaClass unityPlayerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject currentActivity = unityPlayerClass.GetStatic<AndroidJavaObject>("currentActivity");
            vibrator = currentActivity.Call<AndroidJavaObject>("getSystemService", "vibrator");
        }

        long milliseconds = (long)(duration * 200); // Convert seconds to milliseconds

        if (vibrator.Call<bool>("hasVibrator") && milliseconds > 200)
        {
            vibrator.Call("vibrate", milliseconds);
            Invoke("StopVibration", duration);
        }
    }

    public void StopVibration()
    {
        if (vibrator != null)
        {
            vibrator.Call("cancel");
        }
    }
    
}

