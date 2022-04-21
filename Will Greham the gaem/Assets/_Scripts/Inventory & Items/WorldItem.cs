﻿using UnityEngine;
using System.Collections;

public class WorldItem : PhysicalItem
{
    bool inTouch = false;
    Collider2D collider;
    private void Start()
    {
        StartCoroutine(LateStart());
    }
    protected override IEnumerator LateStart()
    {
        yield return null;
        Init(itemData.GetItemGroundSprite());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inTouch = true;
            collider = collision;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inTouch = false;
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inTouch == true)
        {
            PickUp(collider.GetComponent<PlayerMovement>());
        }
    }

    void PickUp(PlayerMovement player)
    {
        if (!player.GetInventory().CheckMax())
        {
            player.GetInventory().ItemAdded(itemData);
            Destroy(gameObject);
        }
        else return;
    }

}
