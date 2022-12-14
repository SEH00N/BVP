using UnityEngine;
using UnityEngine.AI;

public class IdleAction : AIAction
{
    private Rigidbody rb = null;
    private NavMeshAgent nav = null;

    protected override void Awake()
    {
        base.Awake();

        rb = brain.GetComponent<Rigidbody>();
        nav = brain.GetComponent<NavMeshAgent>();
    }

    public override void TakeAction()
    {
        nav.isStopped = true;
        nav.destination = transform.position;
        rb.velocity = Vector3.zero;
    }
}
