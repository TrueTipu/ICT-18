using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour
{ 
    Color defaultColor;
    private void Awake()
    {
        defaultColor = _image.color;
    }

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

    [SerializeField] Inventory inventory;
    [SerializeField] int number;

    [HideInInspector] public InvItem item;


    private void Update()
    {
        PointCheck();
    }
    public bool isPointed;

    public void PointCheck()
    {
        if (isPointed)
        {
            Debug.Log("moi");
            _image.color = Color.black;
            if (Input.GetMouseButtonDown(0))
            {
                inventory.ItemRemoved(number);
            }
        }
        else
        {
            _image.color = defaultColor;
        }
    }

}
