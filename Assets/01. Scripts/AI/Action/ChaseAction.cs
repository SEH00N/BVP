using UnityEngine;
using UnityEngine.AI;

public class ChaseAction : AIAction
{
    private Transform target = null;
    private NavMeshAgent nav = null;

    protected override void Awake()
    {
        base.Awake();

        nav = brain.GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        target = brain.Target;
    }

    public override void TakeAction()
    {
        nav.destination = target.position;

        nav.isStopped = false;
    }
}
