using System.Collections;
using UnityEngine;

public class GroggyAction : AIAction
{
    [SerializeField] float startDelay = 0.5f;
    [SerializeField] float groggyTime = 3f;

    private BossProperty property = null;

    protected override void Awake()
    {
        base.Awake();

        property = transform.root.GetComponent<BossProperty>();
    }

    public override void TakeAction()
    {   
        property.GroggyPercentage = 0f;

        StartCoroutine(ToggleCoroutine());
    }

    private IEnumerator ToggleCoroutine()
    {
        yield return new WaitForSeconds(startDelay);

        brain.onGroggy = true;
        
        yield return new WaitForSeconds(groggyTime);
    
        brain.onGroggy = false;
    }
}
