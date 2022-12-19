using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.VFX;

public class Sword : Weapon
{
    [SerializeField] float startDelay, duration;
    [SerializeField] List<BoxCollider> colliders = new List<BoxCollider>();
    [SerializeField] List<Slash> slashes = new List<Slash>();
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
    private bool onDetermination = false;
    private int attackCnt;

    private void Awake()
    {
        animator = transform.root.GetComponent<Animator>();
        player = transform.root;
        head = player.Find("Head");
    }

    public override void ActiveWeapon()
    {
        if(onDetermination) return;
        if(attackCnt >= 3) return;
        animator.SetTrigger("OnSlash");
        attackCnt++;
        animator.SetInteger("AttackCnt",attackCnt);
        StartCoroutine(DeterminateCoroutine(startDelay, duration));
    }

    private IEnumerator DeterminateCoroutine(float startDelay, float duration)
    {
        onDetermination = true;
        yield return new WaitForSeconds(startDelay);

        slashes[attackCnt-1].gameObject.transform.position = head.position;
        slashes[attackCnt-1].gameObject.SetActive(true);
        Determinate();

        yield return new WaitForSeconds(duration);

        onDetermination = false;
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
