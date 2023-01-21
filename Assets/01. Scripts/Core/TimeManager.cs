using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private static TimeManager instance = null;
    public static TimeManager Instance {
        get {
            if(instance == null)
                instance = FindObjectOfType<TimeManager>();
            return instance;
        }
    }

    private bool onDelaying = false;

    public void TimeDelay(float percentage, float durtion)
    {
        if(onDelaying) return;

        onDelaying = true;
        Time.timeScale = percentage;

        StartCoroutine(TimeResetCoroutine(durtion));
    }

    public void Stop()
    {
        StopAllCoroutines();
        Time.timeScale = 1f;
    }

    private IEnumerator TimeResetCoroutine(float duration)
    {
        yield return new WaitForSecondsRealtime(duration);

        Time.timeScale = 1;
        onDelaying = false;
    }
}
