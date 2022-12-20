using System;
using UnityEngine;

public class BoxBomb : PoolableMono, IDamageable
{
    [SerializeField] float damage = 10f;
    [SerializeField] float moveSpeed = 10f;
    [Range(0f, 1f), SerializeField] float groggyPercent = 0.3f;
    private Rigidbody rb = null;

    [Space(10f)]
    [SerializeField] float lifeTime = 10f;
    private float curerntTimer = 0f;

    private BossProperty bossProperty = null;

    public float CurrentHp { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public float MaxhHp => throw new NotImplementedException();

    private void Update()
    {
        curerntTimer += Time.deltaTime;
        if(curerntTimer >= lifeTime)
        {
            //이펙트
            PoolManager.Instance.Pop("Boom").transform.position = transform.position;
            PoolManager.Instance.Push(this);
        }
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

        PoolManager.Instance.Pop("Boom").transform.position = transform.position;
        PoolManager.Instance.Push(this);
    }

    public override void Reset()
    {
        if(rb == null)
            rb = GetComponent<Rigidbody>();

        rb.velocity = Vector3.zero;
        curerntTimer = 0f;
    }
}
