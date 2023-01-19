using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.VFX;

public class EnforcerAttackAction : AIAction
{
    [SerializeField] BoxCollider attackRange = null;
    [SerializeField] float damage = 10f;
    [SerializeField] float startDelay = 1f;

    [Space(10f)]
    [SerializeField] float stopSlip = 5f;
    [SerializeField] float attackDelay = 3f;
    [Space(3f)]
    [SerializeField] float radius1 = 0.1f;
    [Space(3f)]
    [SerializeField] float radius2 = 1f;
    [SerializeField] VisualEffect vfx;
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
        if(currentTimer >= attackDelay)
            return;
        

        nav.velocity = Vector3.Lerp(nav.velocity, Vector3.zero, stopSlip * Time.deltaTime);
        nav.destination = target.position;

        vfx.SetFloat("CreateParticleRadius",radius1);
        vfx.SetFloat("ConformParticleRadius",radius2);
        vfx.gameObject.SetActive(true);
        currentTimer += Time.deltaTime;
        if(currentTimer < attackDelay)
            return;
        

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
        vfx.SetFloat("CreateParticleRadius",radius2);
        vfx.SetFloat("ConformParticleRadius",radius1);
        List<IDamageable> targets = new List<IDamageable>();
        foreach(Collider c in detectedTargets)
        {
            if(c.TryGetComponent<IDamageable>(out IDamageable id))
            {
                if(!targets.Contains(id))
                {
                    targets.Add(id);
                    id.OnDamage(damage);
                    
                }
            }
        }
        yield return new WaitForSeconds(0.2f);
        vfx.gameObject.SetActive(false);
        currentTimer = 0f;
    }
}
