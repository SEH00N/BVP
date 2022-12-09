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

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Boss"))
        {
            Debug.Log("보스 맞췄다");
            //펑 이펙트
            PoolManager.Instance.Push(this);
        }
    }

    public override void Reset()
    {
        if(rb == null)
            rb = GetComponent<Rigidbody>();

        rb.velocity = Vector3.zero;
    }
}
