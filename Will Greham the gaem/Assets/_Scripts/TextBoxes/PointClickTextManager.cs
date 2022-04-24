using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class PointClickTextManager : TextManager, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Sprite mouseOverSprite;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ChangeLine();
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    { 
        if(textActive == false)
        {
            Open();
            Invoke("Close", 3);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Cursor.SetCursor(mouseOverSprite.texture, Vector2.zero, CursorMode.Auto);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
