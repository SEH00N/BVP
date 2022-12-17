using UnityEngine;

public class GruntClear : AIDecision
{
    [SerializeField] GruntAction gruntAction = null;

    public override bool MakeDecision()
    {
        return gruntAction.CurrentGruntCount <= 0;
    }
}
