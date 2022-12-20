using System;
using UnityEngine;

public class GruntHealth : MonoBehaviour, IDamageable
{
    [SerializeField] float maxHp = 100f;
    [SerializeField] float currentHp = 0f;

    private Animator animator = null;
    private Grunt grunt = null;

    public float CurrentHp { get => currentHp; set => currentHp = Mathf.Clamp(value, 0f, maxHp); }
    public float MaxhHp => maxHp;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        grunt = GetComponent<Grunt>();
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
        grunt.Performer.CurrentGruntCount--;
        animator.SetBool("OnDie", true);

        PoolManager.Instance.Pop("Boom").transform.position = transform.position;
        PoolManager.Instance.Push(grunt);
    }
}
