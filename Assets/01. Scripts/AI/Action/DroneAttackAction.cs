using UnityEngine;

public class DroneAttackAction : AIAction
{
    [SerializeField] Transform target = null;
    [SerializeField] Transform firePos = null;

    [Space(10f)]
    [SerializeField] float fireDelay = 1f;
    private float currentTimer = 0f;

    public override void TakeAction()
    {
        currentTimer += Time.deltaTime;
        if(currentTimer < fireDelay)
            return;
        
        currentTimer = 0f;

        Projectile bullet = PoolManager.Instance.Pop("DroneBullet") as Projectile;
        bullet.Init(firePos.position - target.position);
    }
}
