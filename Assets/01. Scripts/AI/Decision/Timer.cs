using UnityEngine;

public class Timer : AIDecision
{
    [SerializeField] float targetDelay = 10f;
    private float currentTimer = 0f;

    public override bool MakeDecision()
    {
        currentTimer += Time.deltaTime;

        bool returnValue = (currentTimer >= targetDelay);

        currentTimer -= returnValue ? currentTimer : 0f;

        return returnValue;
    }
}
