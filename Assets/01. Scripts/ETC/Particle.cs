using UnityEngine;

public class Particle : PoolableMono
{
    [SerializeField] float lifeTime = 1f;
    private float currentTimer = 0f;

    public override void Reset()
    {
        currentTimer = 0f;
    }

    private void Update()
    {
        currentTimer += Time.deltaTime;
        if(currentTimer >= lifeTime)
        {
            PoolManager.Instance.Push(this);
        }
    }
}