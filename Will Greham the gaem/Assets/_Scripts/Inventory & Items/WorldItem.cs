using UnityEngine;
using System.Collections;

public class WorldItem : MonoBehaviour
{
    public Item itemData;

    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = itemData.GetItemGroundSprite();
        gameObject.name = itemData.Name();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
    //siirrä myöhemmin toiseen scriptiin
    //void SpawnNewWorldItem()
    //{
    //    WorldItem _newItem = Instantiate(itemData.GetItemGround(), transform).GetComponent<WorldItem>();
    //    _newItem.itemData = itemData;
    //}
}
