using UnityEngine;

public class Groggy : AIDecision
{
    private BossProperty property = null;

    protected override void Awake()
    {
        base.Awake();

        property = transform.root.GetComponent<BossProperty>();
    }

    public override bool MakeDecision()
    {
        return (property.GroggyPercentage >= 1f);
    }
    public void BoxAnimGrog(){
        brain.anim.SetTrigger("BoxGroggy");
    }
}
