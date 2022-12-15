using System.Collections;
using UnityEngine;

public class EnforcerAttackAction : AIAction
{
    [SerializeField] Collider attackRange = null;
    [SerializeField] float startDelay = 1f;

    public override void TakeAction()
    {

    }

    private IEnumerator AttackCoroutine()
    {
        yield return null;
    }
}
