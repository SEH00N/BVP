using UnityEngine;
using UnityEngine.AI;

public class DroneAttackAction : AIAction
{
    [SerializeField] Transform target = null;
    [SerializeField] Transform firePos = null;

    [Space(10f)]
    [SerializeField] float fireDelay = 1f;
    [SerializeField] float currentTimer = 0f;

    [Space(10f)]
    [SerializeField] float stopSlip = 10f;

    private NavMeshAgent nav = null;

    protected override void Awake()
    {
        base.Awake();

        nav = brain.GetComponent<NavMeshAgent>();
    }

    public override void TakeAction()
    {
        nav.velocity = Vector3.Lerp(nav.velocity, Vector3.zero, stopSlip * Time.deltaTime);

        currentTimer += Time.deltaTime;
        if(currentTimer < fireDelay)
            return;
        
        currentTimer = 0f;

        Projectile bullet = PoolManager.Instance.Pop("DroneBullet") as Projectile;
        bullet.Init(firePos.position, target.position - firePos.position);
    }
}
