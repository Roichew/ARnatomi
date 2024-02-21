using System.Collections;
using System.Threading;
using UnityEngine;

public class FrameRateManager : MonoBehaviour
{
    [Header("Frame Settings")]
    public int MaxRate = 9999;
    public float TargetFrameRate = 60.0f;
    private float currentFrameTime;

    private void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = MaxRate;
        currentFrameTime = Time.realtimeSinceStartup;
        StartCoroutine(WaitForNextFrame());
    }

    private IEnumerator WaitForNextFrame()
    {
        while (true)
        {
            yield return new WaitForEndOfFrame();

            currentFrameTime += 1.0f / TargetFrameRate;
            var t = Time.realtimeSinceStartup;
            var sleepTime = currentFrameTime - t - 0.01f;

            if (sleepTime > 0)
                yield return new WaitForSeconds(sleepTime);
        }
    }
}