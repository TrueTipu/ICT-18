using UnityEngine;
using System.Collections;

public class WorldItem : PhysicalItem, ButtonIcon
{
    bool inTouch = false;
    Collider2D collider;
    private void Start()
    {
        StartCoroutine(LateStart());
    }

    [SerializeField] GameObject _iconObject;
    public GameObject IconObect
    {
        get { return _iconObject; }
        private set { _iconObject = value; }
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
            inTouch = true;
            collider = collision;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inTouch = false;
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inTouch == true)
        {
            PickUp(collider.GetComponent<PlayerMovement>());
        }

        if (inTouch)
        {
            ShowIcon();
        }
        else
        {
            HideIcon();
        }
    }

    void PickUp(PlayerMovement player)
    {
        if (!player.GetInventory().CheckMax())
        {
            player.GetInventory().ItemAdded(itemData);
            Destroy(gameObject);
        }
        else return;
    }

    public void ShowIcon()
    {
        IconObect.SetActive(true);
    }

    public void HideIcon()
    {
        IconObect.SetActive(false);
    }
}
