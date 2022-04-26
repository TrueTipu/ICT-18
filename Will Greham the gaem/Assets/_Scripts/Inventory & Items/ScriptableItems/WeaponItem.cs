using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "new Weapon", menuName = "Item/Weapon")]
public class WeaponItem : Item
{
    public override ItemType itemType
    {
        get { return ItemType.Weapon; }
        protected set { return; }
    }

    [Header("Weapon")]
    [SerializeField] float hitRange;

    public DamageData damageData;

    public override WeaponItem GetWeapon() { return this; }
}
[System.Serializable]
public class DamageData
{
    [SerializeField] public int damage;
    [SerializeField] public float radius;
    [SerializeField] public string weaponName;

    [SerializeField] public WeaponType type;
    
    public enum WeaponType
    {
        Weak = 1,
        Medium = 2,
        Strong =4
    }

    public override string ToString()
    {
        return type.ToString() + " " + radius.ToString();
    }
}
