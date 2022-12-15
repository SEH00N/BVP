using System;
using UnityEngine;

public class GruntHealth : MonoBehaviour, IDamageable
{
    [SerializeField] float maxHp = 100f;
    private float currentHp = 0f;

    private Animator animator = null;

    public float CurrentHp { get => currentHp; set => currentHp = Mathf.Clamp(value, 0f, maxHp); }
    public float MaxhHp => maxHp;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    
    public void OnDamage(float damage, Vector3 hitPos = default, Action callback = null)
    {
        currentHp -= damage;

        if(currentHp <= 0f)
            animator.SetBool("OnDie", true);
        else
            animator.SetTrigger("OnDamage");
    }
}
