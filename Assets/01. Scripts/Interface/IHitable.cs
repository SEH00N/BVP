using System;
using UnityEngine;

public interface IDamageable
{
    public void OnDamage(float damage, Vector3 hitPos, Action callback = null);
}
