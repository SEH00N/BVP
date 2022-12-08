using UnityEngine;

public class MeleeSkill : SkillAction
{
    [SerializeField] Weapon weapon = null;

    public override void ActiveSkill()
    {
        weapon.ActiveWeapon();
    }
}
