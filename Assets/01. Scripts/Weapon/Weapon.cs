using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected WeaponSO weaponSO;
    public abstract void ActiveWeapon();
}
