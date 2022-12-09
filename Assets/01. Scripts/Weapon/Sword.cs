using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon
{
    [SerializeField] float startDelay, duration;
    [SerializeField] List<BoxCollider> colliders = new List<BoxCollider>();

    private Animator animator = null;
    private bool onDetermination = false;

    private void Awake()
    {
        animator = transform.root.GetComponent<Animator>();
    }

    public override void ActiveWeapon()
    {
        if(onDetermination) return;

        animator.SetTrigger("OnSlash");
        StartCoroutine(DeterminateCoroutine(startDelay, duration));
    }

    private IEnumerator DeterminateCoroutine(float startDelay, float duration)
    {
        yield return new WaitForSeconds(startDelay);

        onDetermination = true;
        Determinate();

        yield return new WaitForSeconds(duration);

        onDetermination = false;
    }

    private void Determinate()
    {
        List<IDamageable> ids = new List<IDamageable>();

        foreach(BoxCollider c in colliders)
        {
            Debug.Log(c.size);
            foreach(Collider cc in Physics.OverlapBox(c.bounds.center, c.size, c.transform.rotation))
            {
                if(cc.TryGetComponent<IDamageable>(out IDamageable id))
                {
                    if(!ids.Contains(id))
                    {
                        ids.Add(id);
                        id.OnDamage(weaponSO.damage, c.transform.position);
                    }
                }
            }
        }
    }
}
