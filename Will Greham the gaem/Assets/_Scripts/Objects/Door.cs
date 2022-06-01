using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IHittable, ButtonIcon, SendData
{
    bool inTouch = false;
    Collider2D collider;

    [SerializeField] bool locked;

    [SerializeField] GameObject _iconObject;
    public GameObject IconObect
    {
        get { return _iconObject; }
        private set { _iconObject = value; }
    }

    [SerializeField]MissionData _data;
    [SerializeField] MissionData _data2;

    [SerializeField] BoxCollider2D boxCollider2D;

    public MissionData data { get { return _data; } }
    public MissionData data2 { get { return _data2; } }

    public void HideIcon()
    {
        IconObect.SetActive(false);
    }


    public void ShowIcon()
    {
        IconObect.SetActive(true);
    }

    public void TakeDamage(DamageData damage)
    {
        if (damage.type <= DamageData.WeaponType.Medium && locked)
        {
            locked = false;
            TextBoxActivator.Guide("You broke the lock.");
            MissionDataManager.Instance.AddData(data);
            //tähän hajoamisanimaatio/ääni
        }
        else if (damage.type >= DamageData.WeaponType.Strong)
        {
            //hajoa
            Debug.Log("pum");
            Destroy(gameObject);
            MissionDataManager.Instance.AddData(data2);
        }
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
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inTouch == true)
        {
            if (locked) //lisää tähän avain myöhempiin kenttiin
            {
                Debug.Log("kiinni");
                TextBoxActivator.Guide("Door is locked.");
                AudioManager.Instance.Play("DoorLock");
            }
            else
            {
                //aukea
                AudioManager.Instance.Play("Door");
                //Debug.Log("auki");
                boxCollider2D.enabled = false;
                transform.Rotate(new Vector3(0,0,90));
                transform.position = new Vector3(transform.position.x - 1f, transform.position.y - 0.5f);
            }
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
}
