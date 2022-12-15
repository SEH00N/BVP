using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grunt : PoolableMono
{
    private GruntHealth health = null;
    public GruntHealth Heath => health;

    private void Awake()
    {
        health = GetComponent<GruntHealth>();
    }

    public override void Reset()
    {
        health.CurrentHp = health.MaxhHp;
    }
}
