using System.Reflection;
using System.Collections.Generic;
using UnityEngine;

public class BoxBasicRotateAction : AIAction
{
    [SerializeField] Axis axis;
    [SerializeField] Transform targetObject = null;
    [Space(10f)]
    [SerializeField] float increaseAngle = 10f;

    private FieldInfo fInfo;

    protected override void Awake()
    {
        base.Awake();

        fInfo = typeof(Transform).GetField(axis.ToString().ToLower());
    }

    public override void TakeAction()
    {
        Vector3 axis = Vector3.zero;
        switch (this.axis) 
        {
            case Axis.Right:
                axis = targetObject.right;
                break;
            case Axis.Up:
                axis = targetObject.up;
                break;
            case Axis.Forward:
                axis = targetObject.forward;
                break;
        }   
        targetObject.rotation *= Quaternion.AngleAxis(increaseAngle * Time.deltaTime, axis);
    }
}
