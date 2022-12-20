using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] float maxHp = 100f;
    private float currentHp = 0f;

    public float CurrentHp { get => currentHp; set => currentHp = value; }
    public float MaxhHp => maxHp;

    private Player player = null;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    private void Start()
    {
        currentHp = maxHp;
    }

    public void OnDamage(float damage, Vector3 hitPos = default, Action callback = null)
    {
        currentHp -= damage;
        Debug.Log("사람이 아프다 이말이야");

        if (currentHp <= 0f)
        {
            Die();
        }
        else
        {
            player.Anim.SetTrigger("OnDamage");
        }
    }

    private void Die()
    {
        Debug.Log("죽었다 머저리야");
        //죽었다 머저리야
    }
}