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
        if (damage.type == DamageData.WeaponType.Weak && locked)
        {
            locked = false;
            Debug.Log("rikki");
            MissionDataManager.Instance.AddData(data);
            //t�h�n hajoamisanimaatio/��ni
        }
        else if (damage.type == DamageData.WeaponType.Medium || damage.type == DamageData.WeaponType.Strong)
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
            if (locked) //lis�� t�h�n avain my�hempiin kenttiin
            {
                Debug.Log("kiinni");
            }
            else
            {
                //aukea
                Debug.Log("auki");
                Destroy(gameObject);
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