using System.Collections.Generic;
using UnityEngine;

public class BoxBasicRotateAction : AIAction
{
    [SerializeField] Axis axis;
    [SerializeField] Transform targetObject = null;
    [Space(10f)]
    [SerializeField] float increaseAngle = 10f;

    private Dictionary<Axis, Vector3> dirs = new Dictionary<Axis, Vector3>();

    protected override void Awake()
    {
        base.Awake();

        dirs[Axis.X] = targetObject.right;
        dirs[Axis.Y] = targetObject.up;
        dirs[Axis.Z] = targetObject.forward;
    }

    public override void TakeAction()
    {
        targetObject.rotation *= Quaternion.AngleAxis(increaseAngle * Time.deltaTime, dirs[axis]);
    }
}
