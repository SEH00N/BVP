using UnityEngine;

public class Projectile : PoolableMono
{
    [SerializeField] float damage = 10f;
    [SerializeField] float lifeTime = 5f;
    [SerializeField] float speed = 20f;
    private float timer = 0f;

    private Rigidbody rb = null;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public override void Reset()
    {
        transform.localEulerAngles = Vector3.zero;
        timer = 0f;
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        timer += Time.deltaTime;

        if(timer >= lifeTime)
            PoolManager.Instance.Push(this);
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player"))
            if(other.transform.root.TryGetComponent<IDamageable>(out IDamageable id))
                id.OnDamage(damage);

        //이펙트
        PoolManager.Instance.Push(this);
    }

    public void Init(Vector3 dir)
    {
        transform.forward = dir.normalized;
    }
}
