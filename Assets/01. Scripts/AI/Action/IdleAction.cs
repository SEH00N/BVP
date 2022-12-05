using UnityEngine;

public class IdleAction : AIAction
{
    private Material material = null;

    protected override void Awake()
    {
        base.Awake();

        material = transform.parent.parent.GetComponent<MeshRenderer>().material;
    }

    public override void TakeAction()
    {
        brain.MoveTo(transform.position);

        material.color = new Color(0.5f, 0.5f, 0.5f, 1f);
    }
}
