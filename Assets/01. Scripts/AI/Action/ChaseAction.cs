using UnityEngine;

public class ChaseAction : AIAction
{
    [SerializeField] Transform target = null;

    public override void TakeAction()
    {
        brain.MoveTo(target.position);
    }
}
