using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : ScriptableObject
{
    [Header("General")]

    [SerializeField] string itemName;
    public string Name() { return itemName; }

    [SerializeField] Sprite itemIcon;
    public Sprite GetItemIcon() { return itemIcon; }


    [SerializeField] GameObject itemInv;
    public GameObject GetItemInv() { return itemInv; }

    [SerializeField] GameObject itemHold;
    public GameObject GetItemHold() { return itemHold; }

    [SerializeField] GameObject itemGround;
    public GameObject GetItemGround() { return itemGround; }



    [SerializeField] Sprite itemHoldSprite;
    public Sprite GetItemHoldSprite() { return itemHoldSprite; }

    [SerializeField] Sprite itemGroundSprite;
    public Sprite GetItemGroundSprite() { return itemGroundSprite; }



    public virtual WeaponItem GetWeapon() { return null; }

    public abstract ItemType itemType { get; protected set; }

    public enum ItemType
    {
        Weapon,
        Gun,
        other
    }

}

