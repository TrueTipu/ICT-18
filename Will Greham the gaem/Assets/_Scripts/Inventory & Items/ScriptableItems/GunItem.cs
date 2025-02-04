﻿using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "new Weapon", menuName = "Item/Gun")]
public class GunItem : Item
{
    public override ItemType itemType
    {
        get { return ItemType.Gun; }
        protected set { return; }
    }


    [Header("Gun")]
    [SerializeField] GameObject bullet;


    public override GunItem GetGun() { return this; }

    public DamageData damageData;
}
