using UnityEngine;

public class ChaseAction : AIAction
{
    [SerializeField] Transform target = null;
    private Material material = null;

    protected override void Awake()
    {
        base.Awake();

        material = transform.parent.parent.GetComponent<MeshRenderer>().material;
    }

    public override void TakeAction()
    {
        // brain.MoveTo(target.position);

        material.color = Color.red;
    }
}
