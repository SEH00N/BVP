using UnityEngine;

public class CoreActivator : MonoBehaviour
{
    [SerializeField] GameObject ringObject = null;

    public void ActiveCore()
    {
        Ring[] rings = ringObject.GetComponentsInChildren<Ring>();
        Ring targetRing = rings[Random.Range(0, rings.Length)];

        DEFINE.Core.SetColor(targetRing.ringColor);
    }
}
