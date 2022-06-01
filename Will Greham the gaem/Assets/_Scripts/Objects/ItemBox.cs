using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : PhysicalItem, ButtonIcon, SendData
{
    bool inTouch = false;
    Collider2D collider;
    [SerializeField] Lock caseLock;

    [SerializeField]GameObject _iconObject;
    public GameObject IconObect {
        get { return _iconObject; }
        private set { _iconObject = value; }
    }
    [SerializeField] MissionData _data;

    public MissionData data { get { return _data; } private set { _data = value; } }


    protected override IEnumerator LateStart()
    {
        yield return null;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.CompareTag("Player"))
        {
            inTouch = true;
            collider = collision.collider;
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            inTouch = false;
        }

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inTouch == true)
        {
            if(caseLock != null)
            {
                if(!caseLock.open)
                {
                    caseLock.ShowUI();
                    return;
                }
            }
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
            AudioManager.Instance.Play("PickUp");
            player.GetInventory().ItemAdded(itemData);
            this.enabled = false;
            data.Name = data.Name + itemData.Name();
            MissionDataManager.Instance.AddData(data);
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
