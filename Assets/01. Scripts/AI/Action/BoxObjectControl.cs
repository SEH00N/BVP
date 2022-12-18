using UnityEngine;

public class BoxObjectControl : AIAction
{
    [SerializeField] bool active = false;
    private Collider boxObject = null;

    protected override void Awake()
    {
        base.Awake();

        boxObject = transform.parent.parent.GetComponent<Collider>();
    }

    public override void TakeAction()
    {
        if(boxObject.enabled != active)
            boxObject.enabled = active;
    }
}
