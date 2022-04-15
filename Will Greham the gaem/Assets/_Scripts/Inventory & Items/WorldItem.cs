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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PickUp(collision.GetComponent<PlayerMovement>());
        }
    }

    void PickUp(PlayerMovement player)
    {
        if (!player.GetInventory().CheckMax())
        {
            player.GetInventory().AddItem(itemData);
            Destroy(gameObject);
        }
        else return;
    }
    //siirrä myöhemmin toiseen scriptiin
    //void SpawnNewWorldItem()
    //{
    //    WorldItem _newItem = Instantiate(itemData.GetItemGround(), transform).GetComponent<WorldItem>();
    //    _newItem.itemData = itemData;
    //}
}
