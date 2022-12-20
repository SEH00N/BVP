using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnforcerAttackAction : AIAction
{
    [SerializeField] BoxCollider attackRange = null;
    [SerializeField] float damage = 10f;
    [SerializeField] float startDelay = 1f;

    [Space(10f)]
    [SerializeField] float stopSlip = 5f;
    [SerializeField] float attackDelay = 3f;
    private float currentTimer = 0f;

    private Transform target = null;
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
        if(currentTimer < attackDelay)
            return;
        
        currentTimer = 0f;

        //애니메이션

        StartCoroutine(AttackCoroutine());
    }

    private IEnumerator AttackCoroutine()
    {
        yield return new WaitForSeconds(startDelay);

        Collider[] detectedTargets = Physics.OverlapBox(
            attackRange.transform.position, 
            attackRange.transform.lossyScale, 
            attackRange.transform.rotation, 
            DEFINE.PlayerLayer
        );

        Debug.Log(attackRange.transform.lossyScale);

        Debug.Log(detectedTargets.Length);

        List<IDamageable> targets = new List<IDamageable>();
        foreach(Collider c in detectedTargets)
        {
            if(c.TryGetComponent<IDamageable>(out IDamageable id))
            {
                if(!targets.Contains(id))
                {
                    targets.Add(id);
                    id.OnDamage(damage);
                    //이펙트
                }
            }
        }
    }
}
