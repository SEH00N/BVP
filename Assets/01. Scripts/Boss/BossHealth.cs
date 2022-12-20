using System;
using UnityEngine;

public class BossHealth : MonoBehaviour, IDamageable
{
    [SerializeField] float maxHp = 100f;
    [SerializeField] float currentHp = 0f;

    [Space(10f)] 
    [SerializeField] AIBrain targetAI = null;

    private Animator animator = null;

    public float CurrentHp { get => currentHp; set => currentHp = Mathf.Clamp(value, 0f, maxHp); }
    public float MaxhHp => maxHp;

    private void Awake()
    {
        animator = transform.parent.GetComponent<Animator>();
    }

    private void Start()
    {
        currentHp = maxHp;
    }
    
    public void OnDamage(float damage, Vector3 hitPos = default, Action callback = null)
    {
        currentHp -= damage;
        Debug.LogWarning("아얏");

        if(currentHp <= 0f)
            OnDie();
        else
            animator.SetTrigger("OnDamage");
    }

    private void OnDie()
    {
        animator.SetBool("OnDie", true);
        //이펙트

        if(targetAI != null)
        {
            targetAI.enabled = true;
            Debug.Log("asdad");
        }

        animator.SetTrigger("NextPhase");
        Destroy(gameObject);
    }
}
