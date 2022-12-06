using System;
using UnityEngine;

public abstract class SkillAction : MonoBehaviour
{
    [field : NonSerializedAttribute]
    public int currentStack = 0;
    public KeyCode activeKey = KeyCode.Mouse0;

    [SerializeField] int stackAmount = 0;
    [SerializeField] float coolTime = 1f;
    private float currentTimer = 0f;

    public abstract void ActiveSkill();

    private void Update()
    {
        if(currentStack >= stackAmount)
            return;

        currentTimer += Time.deltaTime;

        if(currentTimer >= coolTime)
        {
            currentTimer = 0f;
            currentStack++;
        }
    }
}
