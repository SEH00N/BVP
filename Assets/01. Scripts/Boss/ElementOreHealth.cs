using System;
using UnityEngine;

public class ElementOreHealth : MonoBehaviour, IDamageable
{
    [SerializeField] float maxHp = 100f;
    private float currentHp = 0f;

    public float CurrentHp { get => currentHp; set => currentHp = value; }
    public float MaxhHp => maxHp;

    private Ring oreRing;

    public void Reset(Ring ring) // 포탈 탈 때 실행시켜줘야 됨
    {
        gameObject.SetActive(true);
        oreRing = ring;
        currentHp = maxHp;
    }

    public void OnDamage(float damage, Vector3 hitPos = default, Action callback = null)
    {
        currentHp -= damage;

        if(currentHp <= 0f)
            Die();
    }

    private void Die()
    {
        if(DEFINE.Core.currentColor == oreRing.ringColor)
        {
            //링 부수기
        } else {
            //플레이어 데미지 받기
        } 

        gameObject.SetActive(false);
        //이펙트
    }
}
