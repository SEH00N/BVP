using UnityEngine;

public class GruntClear : AIDecision
{
    [SerializeField] GruntAction gruntAction = null;

    public override bool MakeDecision()
    {
        return gruntAction.CurrentGruntCount <= 0;
    }
    public void OpenShell(bool toggle){
        brain.anim.SetBool("OpenShell",toggle);
    }
}
