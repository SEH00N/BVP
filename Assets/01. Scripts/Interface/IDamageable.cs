using System;
using UnityEngine;

public interface IDamageable
{
    public float CurrentHp { get; set; }
    public float MaxhHp { get; }
    public void OnDamage(float damage, Vector3 hitPos = default(Vector3), Action callback = null);
}
