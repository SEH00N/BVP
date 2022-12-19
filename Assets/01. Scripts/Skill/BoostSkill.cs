using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class BoostSkill : SkillAction
{
    private Rigidbody rb = null;
    private Movement movement = null;

    [SerializeField] float speed = 3f;
    [SerializeField] float duration = 0.1f;

    private void Awake()
    {
        rb = transform.parent.parent.GetComponent<Rigidbody>();
        movement = transform.parent.parent.GetComponent<Movement>();
    }

    public override void ActiveSkill()
    {
        if(movement.onBoost) return;

        movement.onBoost = true;

        rb.velocity = Vector3.zero;
        rb.useGravity = false;
        rb.AddForce(DEFINE.MainCam.transform.forward * speed, ForceMode.Impulse);

        StartCoroutine(EndBoostCoroutine(duration));
    }

    private IEnumerator EndBoostCoroutine(float delay)
    {
        yield return new WaitForSeconds(delay);

        movement.onBoost = false;
        rb.useGravity = true;

        Vector3 tempVelocity = rb.velocity;
        tempVelocity.y = 0f;
        rb.velocity = tempVelocity;
    }
}
