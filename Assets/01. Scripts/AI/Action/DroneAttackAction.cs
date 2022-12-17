using UnityEngine;
using UnityEngine.AI;

public class DroneAttackAction : AIAction
{
    [SerializeField] Transform firePos = null;
    private Transform target = null;

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

    private void Start()
    {
        target = brain.Target;
    }

    public override void TakeAction()
    {
        nav.velocity = Vector3.Lerp(nav.velocity, Vector3.zero, stopSlip * Time.deltaTime);
        nav.destination = target.position;

        currentTimer += Time.deltaTime;
        if(currentTimer < fireDelay)
            return;
        
        currentTimer = 0f;

        Projectile bullet = PoolManager.Instance.Pop("DroneBullet") as Projectile;
        bullet.Init(firePos.position, target.position - firePos.position);
    }
}
