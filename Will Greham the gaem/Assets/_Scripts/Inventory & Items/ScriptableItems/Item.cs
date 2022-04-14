using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : ScriptableObject
{
    [Header("General")]

    [SerializeField] string itemName;
    public string Name() { return itemName; }

    [SerializeField] Sprite itemIcon;


    [SerializeField] GameObject itemHold;
    public GameObject GetItemHold() { return itemHold; }

    [SerializeField] GameObject itemGround;
    public GameObject GetItemGround() { return itemGround; }



    [SerializeField] Sprite itemHoldSprite;
    public Sprite GetItemHoldSprite() { return itemHoldSprite; }

    [SerializeField] Sprite itemGroundSprite;
    public Sprite GetItemGroundSprite() { return itemGroundSprite; }



    public abstract ItemType itemType { get; protected set; }

    public enum ItemType
    {
        Weapon,
        Gun,
        other
    }

}

