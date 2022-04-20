using UnityEngine;
using System.Collections;

public class WorldItem : PhysicalItem
{


    private void Start()
    {
        StartCoroutine(LateStart());
    }
    protected override IEnumerator LateStart()
    {
        yield return null;
        Init(itemData.GetItemGroundSprite());
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                PickUp(collision.GetComponent<PlayerMovement>());
            }
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
