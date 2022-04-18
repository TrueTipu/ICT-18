using UnityEngine;
using System.Collections;

public class HoldItem : PhysicalItem
{
    public int id;
    private void Start()
    {
        StartCoroutine(LateStart());
    }
    protected override IEnumerator LateStart()
    {
        yield return null;
        if(itemData != false)
        {
            Init(itemData.GetItemHoldSprite());
        }
    }

    public void CallInit(Sprite sprite)
    {
        Init(sprite);
    }
    public void Update()
    {
        if (itemData == null)
        {
            gameObject.SetActive(false);
        }
    }
}
