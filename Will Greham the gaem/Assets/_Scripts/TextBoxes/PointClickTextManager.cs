using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class PointClickTextManager : TextManager, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Sprite mouseOverSprite;
    [SerializeField] UnityEvent Event;
    private void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ChangeLine();
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    { 
        if(Event != null)
        {
            Event.Invoke();
        }
         Open();

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Cursor.SetCursor(mouseOverSprite.texture, mouseOverSprite.pivot, CursorMode.Auto);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
