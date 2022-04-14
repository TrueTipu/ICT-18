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

    void Hit() { return; }
}
