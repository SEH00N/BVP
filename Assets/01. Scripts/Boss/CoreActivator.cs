using UnityEngine;

public class CoreActivator : MonoBehaviour
{
    [SerializeField] GameObject ringObject = null;

    public void ActiveCore()
    {
        RingPortal[] rings = ringObject.GetComponentsInChildren<RingPortal>();
        RingPortal targetRing = rings[Random.Range(0, rings.Length)];

        DEFINE.Core.SetColor(targetRing.ringColor);
    }
}
