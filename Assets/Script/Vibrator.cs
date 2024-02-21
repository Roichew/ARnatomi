using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vibrator : MonoBehaviour
{
#if UNITY_ANDROID && !UNITY_EDITOR
    public static AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
    public static AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
    public static AndroidJavaObject vibrator = currentActivity.Call<AndroidJavaObject>("getSystemService", "vibrator");
#endif

    public void Vibrate(long milliseconds = 250)
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        if (IsAndroid())
        {
            vibrator.Call("vibrate", milliseconds);
        }
#else
        Handheld.Vibrate();
#endif
    }

    public void Cancel()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        if (IsAndroid())
        {
            vibrator.Call("cancel");
        }
#endif
    }

    public bool IsAndroid()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        return true;
#else
        return false;
#endif
    }
}
