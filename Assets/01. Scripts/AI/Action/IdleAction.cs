using UnityEngine;

public class IdleAction : AIAction
{
    public override void TakeAction()
    {
        brain.MoveTo(transform.position);
    }
}
