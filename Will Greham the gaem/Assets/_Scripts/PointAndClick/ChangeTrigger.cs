using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChangeTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [Header("Edit these")]
    [SerializeField] Sprite mouseOverSprite;

    [SerializeField] GameObject destination;



    public void OnPointerClick(PointerEventData eventData)
    {
        destination.SetActive(true);
        GetComponentInParent<Image>().gameObject.SetActive(false);
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("moi");
        Cursor.SetCursor(mouseOverSprite.texture, Vector2.zero, CursorMode.Auto);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("heippa");
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

}
