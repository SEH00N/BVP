using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon
{
    [SerializeField] float startDelay, duration;
    [SerializeField] List<Collider> colliders = new List<Collider>();

    private bool onDetermination = false;

    public override void ActiveWeapon()
    {
        if(onDetermination) return;

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

        foreach(Collider c in colliders)
        {
            foreach(Collider cc in Physics.OverlapBox(c.bounds.center, c.bounds.size / 2f, transform.rotation))
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
