using UnityEngine;

public class CoreObjectControl : AIAction
{
    [SerializeField] Collider col = null;
    [SerializeField] bool active = false;

    public override void TakeAction()
    {
        if(col.enabled != active)
            col.enabled = active;
    }
}
