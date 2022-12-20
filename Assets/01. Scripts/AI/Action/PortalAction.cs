using UnityEngine;

public class PortalAction : AIAction
{
    public override void TakeAction()
    {
        brain.anim.SetTrigger("PortalGenetate");
    }
}
