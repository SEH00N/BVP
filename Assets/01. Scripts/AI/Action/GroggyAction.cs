using UnityEngine;

public class GroggyAction : AIAction
{
    private BossProperty property = null;

    protected override void Awake()
    {
        base.Awake();

        property = transform.root.GetComponent<BossProperty>();
    }

    public override void TakeAction()
    {   
        property.GroggyPercentage = 0f;

        // Debug.Log("It's on groggy, do nothing");
    }
}
