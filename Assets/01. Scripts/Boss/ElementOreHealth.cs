using System.Collections.Generic;
using UnityEngine;

public class ElementOreHealth : MonoBehaviour, IDamageable
{
    [SerializeField] int gruntCount = 10;
    [SerializeField] List<Grunt> grunts = new List<Grunt>();
    [SerializeField] float maxHp = 100f;
    private float currentHp = 0f;

    public float CurrentHp { get => currentHp; set => currentHp = value; }
    public float MaxhHp => maxHp;

    private RingPortal oreRing;

    [SerializeField] EndRoomPattern decision = null;

    [Header("Spawn Position")]
    [SerializeField] Transform minPos = null;
    [SerializeField] Transform maxPos = null;
    [SerializeField] Transform backPosition = null;

    public void Reset(RingPortal ring) // 포탈 탈 때 실행시켜줘야 됨
    {
        gameObject.SetActive(true);
        oreRing = ring;
        currentHp = maxHp;

        SpawnGrunt();
    }

    private void SpawnGrunt()
    {
        for(int i = 0; i < gruntCount; i ++)
            PoolManager.Instance.Pop(grunts[Random.Range(0, grunts.Count)]).transform.position = GetRandomPos();
    }

    private Vector3 GetRandomPos()
    {
        Vector3 randPos = Vector3.zero;
        randPos.x = Random.Range(minPos.position.x, maxPos.position.x);
        randPos.z = Random.Range(minPos.position.z, maxPos.position.z);
        randPos.y = minPos.position.y;

        return randPos;
    }

    public void OnDamage(float damage, Vector3 hitPos = default, System.Action callback = null)
    {
        currentHp -= damage;

        if(currentHp <= 0f)
            Die();
    }

    private void Die()
    {
        decision.isEnd = true;

        if(DEFINE.Core.currentColor == oreRing.ringColor)
        {
            //링 부수기
        } else {
            //플레이어 데미지 받기
        } 

        gameObject.SetActive(false);
        //이펙트
    }

    private void OutPortal()
    {
        DEFINE.Player.position = backPosition.position;
    }
}
