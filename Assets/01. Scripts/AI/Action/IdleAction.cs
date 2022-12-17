using UnityEngine.AI;

public class IdleAction : AIAction
{
    private NavMeshAgent nav = null;

    protected override void Awake()
    {
        base.Awake();

        nav = brain.GetComponent<NavMeshAgent>();
    }

    public override void TakeAction()
    {
        nav.isStopped = true;
        nav.destination = transform.position;
    }
}
