using System;
using UnityEngine;

public class BoxBomb : PoolableMono, IDamageable
{
    [SerializeField] float damage = 10f;
    [SerializeField] float moveSpeed = 10f;
    [Range(0f, 1f), SerializeField] float groggyPercent = 0.3f;
    private Rigidbody rb = null;

    private BossProperty bossProperty = null;

    private void Awake() //테스트 용도
    {
        Reset();
    }

    public void OnDamage(float damage, Vector3 hitPos, Action callback = null)
    {
        rb.velocity = (transform.position - hitPos).normalized * moveSpeed;

        callback?.Invoke();
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.layer == 7)
            return;

        if(other.gameObject.CompareTag("Boss"))
        {
            if(bossProperty == null)
                bossProperty = other.transform.root.GetComponent<BossProperty>();
            bossProperty.GroggyPercentage += groggyPercent;
        }
        else if(other.gameObject.CompareTag("Player"))
        {
            if(other.gameObject.TryGetComponent<IDamageable>(out IDamageable id))
                id.OnDamage(damage);
        }

        PoolManager.Instance.Push(this);
    }

    public override void Reset()
    {
        if(rb == null)
            rb = GetComponent<Rigidbody>();

        rb.velocity = Vector3.zero;
    }
}
