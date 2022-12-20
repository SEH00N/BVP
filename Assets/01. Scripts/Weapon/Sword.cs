using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.VFX;

public class Sword : Weapon
{
    [SerializeField] float startDelay, duration;
    [SerializeField] List<BoxCollider> colliders = new List<BoxCollider>();
    [SerializeField] List<float> delaies = new List<float>();
    [SerializeField] List<float> durations = new List<float>();
    [SerializeField] GameObject slashParticle;

    [Header("Cam Shake")]
    [SerializeField] float frequency = 1f;
    [SerializeField] float defaultPower = 3f;
    [SerializeField] float additionalFactor = 0.5f;
    [SerializeField] float shakeDuration = 0.3f;

    [Header("Time")]
    [SerializeField] float delayDuration = 0.05f;
    [SerializeField] float delayAmount = 0.4f;

    private Transform player = null;
    private Transform head = null;
    private Animator animator = null;
    private int attackCnt;
    private bool isAttacking = false;
    private bool nextAttack = false;

    private void Awake()
    {
        animator = transform.root.GetComponent<Animator>();
        player = transform.root;
        head = player.Find("Head");
    }

    public override void ActiveWeapon()
    {
        if(!isAttacking) //공격 중이 아닐 때 (첫 공격일 때)
        {
            attackCnt = 0;
            animator.SetTrigger("OnSlash");
            StartCoroutine(DeterminateCoroutine(delaies[attackCnt], durations[attackCnt]));
        }
        else if(!nextAttack) {
            Debug.Log("Ready to nextattack");
            animator.SetTrigger("OnSlash");
            nextAttack = true;
        }
    }

    private IEnumerator DeterminateCoroutine(float startDelay, float duration)
    {
        isAttacking = true;
        yield return new WaitForSeconds(startDelay);

        Determinate();

        yield return new WaitForSeconds(duration);

        if(nextAttack)
        {
            attackCnt = (attackCnt + 1) % delaies.Count;
            StartCoroutine(DeterminateCoroutine(delaies[attackCnt], durations[attackCnt]));
        }
        else
            isAttacking = false;
        
        nextAttack = false;
    }

    private void Determinate()
    {
        List<IDamageable> ids = new List<IDamageable>();

        foreach(BoxCollider c in colliders)
        {
            foreach(Collider cc in Physics.OverlapBox(c.bounds.center, c.size, c.transform.rotation, DEFINE.EnemyLayer))
            {
                if(cc.TryGetComponent<IDamageable>(out IDamageable id))
                {
                    if(!ids.Contains(id))
                    {
                        ids.Add(id);
                        id.OnDamage(weaponSO.damage, cc.transform.position - DEFINE.MainCam.transform.forward);
                    }
                }
            }
        }

        if(ids.Count > 0)
        {
            CameraManager.Instance.ShakeCam(shakeDuration, defaultPower + (ids.Count * additionalFactor), frequency);
            TimeManager.Instance.TimeDelay(delayAmount, delayDuration);
        }
    }
}
