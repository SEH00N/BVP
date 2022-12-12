using System;
using UnityEngine;

public class IdleAction : AIAction
{
    private Rigidbody rb = null;

    protected override void Awake()
    {
        base.Awake();

        rb = transform.root.GetComponent<Rigidbody>();
    }

    public override void TakeAction()
    {
        rb.velocity = Vector3.zero;
    }
}
