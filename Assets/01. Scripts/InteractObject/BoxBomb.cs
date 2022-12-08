using System;
using UnityEngine;

public class BoxBomb : PoolableMono, IDamageable
{
    [SerializeField] float moveSpeed = 10f;
    private Rigidbody rb = null;

    private void Awake() //테스트 용도
    {
        Reset();
    }

    public void OnDamage(float damage, Vector3 hitPos, Action callback = null)
    {
        rb.velocity = (transform.position - hitPos).normalized * moveSpeed;

        callback?.Invoke();
    }

    public override void Reset()
    {
        if(rb == null)
            rb = GetComponent<Rigidbody>();
    }
}
