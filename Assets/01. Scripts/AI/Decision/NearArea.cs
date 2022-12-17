using UnityEngine;

public class NearArea : AIDecision
{
    [SerializeField, Range(0f, 50f)] float distance = 10f;
    private Transform target = null;

    [Header("Gizmo")]
    [SerializeField] Color sphereColor = Color.red;
    [SerializeField] Color lineColor = Color.green;

    private void Start()
    {
        target = brain.Target;
    }

    public override bool MakeDecision()
    {
        float distanceWithTarget = Vector3.Distance(target.position, transform.position);

        return distanceWithTarget < distance;
    }

    #if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = sphereColor;
        Gizmos.DrawWireSphere(transform.position, distance);

        if(target == null)
            return;

        Gizmos.color = lineColor;
        Gizmos.DrawLine(transform.position, target.position);
    }
    #endif
}
