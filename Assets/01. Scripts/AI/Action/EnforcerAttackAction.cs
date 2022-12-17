using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnforcerAttackAction : AIAction
{
    [SerializeField] BoxCollider attackRange = null;
    [SerializeField] float damage = 10f;
    [SerializeField] float startDelay = 1f;

    public override void TakeAction()
    {
        //애니메이션
        StartCoroutine(AttackCoroutine());
    }

    private IEnumerator AttackCoroutine()
    {
        yield return new WaitForSeconds(startDelay);

        Collider[] detectedTargets = Physics.OverlapBox(
            attackRange.bounds.center, 
            attackRange.size, 
            attackRange.transform.localRotation, 
            DEFINE.PlayerLayer
        );

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
