using System.Collections;
using UnityEngine;

public class BoomAction : AIAction
{
    [SerializeField] float boomDistance = 10f;
    [SerializeField] float damage = 10f;
    [SerializeField] float power = 10f;
    [SerializeField] float knockbackDuration = 1f;

    private Player player = null;
    private Rigidbody playerRb = null;


    protected override void Awake()
    {
        base.Awake();

        player = DEFINE.Player.GetComponent<Player>();
        playerRb = DEFINE.Player.GetComponent<Rigidbody>();
    }

    public override void TakeAction()
    {
        if(Vector3.Distance(DEFINE.Player.position, transform.position) <= boomDistance)
        {
            player.PlayerHealth?.OnDamage(damage);
            StartCoroutine(KnockbackCoroutine(knockbackDuration));
        }
    }

    private IEnumerator KnockbackCoroutine(float duration)
    {
        player.Movement.onBoost = true;
        Vector3 dir = transform.position - DEFINE.Player.position;
        dir = -dir;
        dir.y = 0;
        playerRb.AddForce(dir.normalized * power, ForceMode.Impulse);

        yield return new WaitForSeconds(duration);

        player.Movement.onBoost = false;
    }
}
