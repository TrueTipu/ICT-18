using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;

public class ChangeTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [Header("Edit these")]
    [SerializeField] Sprite mouseOverSprite;

    [SerializeField] GameObject destination;

    [SerializeField] UnityEvent Event;



    public void OnPointerClick(PointerEventData eventData)
    {
        destination.SetActive(true);
        GetComponentInParent<Image>().gameObject.SetActive(false);
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);

        if (Event != null)
        {
            Event.Invoke();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Cursor.SetCursor(mouseOverSprite.texture, mouseOverSprite.pivot, CursorMode.ForceSoftware);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

}
