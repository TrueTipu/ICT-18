using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : PhysicalItem
{
    bool inTouch = false;
    Collider2D collider;

    protected override IEnumerator LateStart()
    {
        yield return null;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.CompareTag("Player"))
        {
            inTouch = true;
            collider = collision.collider;
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
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
            this.enabled = false;
        }
        else return;
    }
}
