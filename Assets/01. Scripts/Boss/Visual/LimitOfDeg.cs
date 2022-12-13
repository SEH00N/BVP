using System.Reflection;
using UnityEngine;

public class LimitOfDeg : AIDecision
{
    [SerializeField] Axis axis;
    [SerializeField] Transform targetObject;
    [SerializeField] float limitOfDeg = 30f;

    public override bool MakeDecision()
    {
        FieldInfo field = typeof(Vector3).GetField(axis.ToString().ToLower());
        float degOfAxis = (float)(field.GetValue(targetObject.eulerAngles));
        bool returnValue = degOfAxis >= limitOfDeg;

        if(returnValue)
            targetObject.eulerAngles = Vector3.zero;

        return returnValue;
    }
}
