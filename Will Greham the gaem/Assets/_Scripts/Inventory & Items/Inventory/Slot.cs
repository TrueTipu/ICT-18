using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] private Transform _slotPos;
    public Transform SlotPos
    {
        get { return _slotPos; }
        set { _slotPos = value; }
    }

    [SerializeField] private RectTransform _slotParent;
    public RectTransform SlotParent
    {
        get { return _slotParent; }
        set { _slotParent = value; }
    }

    [SerializeField] private Image _image;
    public Image Image
    {
        get { return _image; }
        set { _image = value; }
    }

    [HideInInspector] public InvItem item;
}
