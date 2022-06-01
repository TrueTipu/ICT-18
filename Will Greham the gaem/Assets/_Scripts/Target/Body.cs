using UnityEngine;
using System.Collections;
using System;

public class Body : MonoBehaviour, ButtonIcon, SendData
{
    bool inTouch = false;
    Collider2D collider;

    [SerializeField] Transform[] rooms;

    [SerializeField] GameObject _iconObject;
    public GameObject IconObect
    {
        get { return _iconObject; }
        private set { _iconObject = value; }
    }

    [SerializeField] MissionData _data;

    public MissionData data { get { return _data; } private set { _data = value; } }

    bool carryed;
    Transform player;
    [SerializeField] Vector3 offset;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inTouch = true;
            collider = collision;
            // Debug.Log("mit");
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
        if (carryed)
        {
            HideIcon();
            transform.position = player.position + offset;
            return;
        }
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
        if (!player.HasBody)
        {
            player.SetBody(this);
            carryed = true;
            this.player = player.transform;
        }
    }

    public void ShowIcon()
    {
        IconObect.SetActive(true);
    }

    public void HideIcon()
    {
        IconObect.SetActive(false);
    }

    public void Leave()
    {
        carryed = false;
        if(TargetMovement.Distances(rooms, transform.position).name == "rotko")
        {
            MissionDataManager.Instance.AddData(new MissionData("You threw body out of balcony"));
            Destroy(gameObject);
        }
        MissionDataManager.Instance.AddData(new MissionData(data.Name + " " + TargetMovement.Distances(rooms, transform.position).name));
    }
}
