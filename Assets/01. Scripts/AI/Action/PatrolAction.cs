using UnityEngine;
using UnityEngine.AI;

public class PatrolAction : AIAction
{
    [SerializeField] float patrolRadius = 10f;
    [SerializeField] float margin = 1f;
    private NavMeshAgent nav = null;

    [SerializeField] Vector3 patrolTarget = Vector3.zero;
    private Vector2 PlanePatrolTargetPosition => new Vector2(patrolTarget.x, patrolTarget.z);
    private Vector2 PlanePosition => new Vector2(transform.position.x, transform.position.z);

    protected override void Awake()
    {
        base.Awake();

        nav = brain.GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        patrolTarget = transform.position;
    }

    public override void TakeAction()
    {
        if(InnerRange(PlanePatrolTargetPosition, margin))
            patrolTarget = GetTargetPosition();

        nav.destination = patrolTarget;
        nav.isStopped = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, patrolRadius);
    }

    private Vector3 GetTargetPosition() => transform.position + (Random.insideUnitSphere * patrolRadius);
    private bool InnerRange(Vector2 center, float margin) => Vector2.Distance(PlanePosition, center) <= margin;
}
