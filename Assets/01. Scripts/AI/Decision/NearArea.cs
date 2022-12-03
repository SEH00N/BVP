using UnityEngine;

public class NearArea : AIDecision
{
    [Range(0f, 50f)] public float distance = 10f;
    public Transform target = null;

    public override bool MakeDecision()
    {
        float distanceWithTarget = Vector3.Distance(target.position, transform.position);

        return distanceWithTarget < distance;
    }

    #if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distance);
    }
    #endif
}
