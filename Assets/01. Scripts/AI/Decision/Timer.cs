using UnityEngine;

public class Timer : AIDecision
{
    [SerializeField] float targetDelay = 10f;
    private float currentTimer = 0f;

    public override bool MakeDecision()
    {
        currentTimer += Time.deltaTime;

        return currentTimer >= targetDelay;
    }

    public void ResetTimer()
    {
        currentTimer = 0f;
    }
}
