using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public abstract class PhysicalItem : MonoBehaviour
{
    public Item itemData;

    SpriteRenderer spriteRenderer;
    Image image;

    protected void Init(Sprite sprite)
    {
        if(TryGetComponent<SpriteRenderer>(out SpriteRenderer spriteRenderer)) spriteRenderer.sprite = sprite;
        else if (TryGetComponent<Image>(out Image image)) image.sprite = sprite;
        gameObject.name = itemData.Name();
    }
    protected abstract IEnumerator LateStart();
}
