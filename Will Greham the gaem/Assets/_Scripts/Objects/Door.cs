using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IHittable, ButtonIcon
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
            //tähän hajoamisanimaatio/ääni
        }
        else if (damage.type == DamageData.WeaponType.Medium || damage.type == DamageData.WeaponType.Strong)
        {
            //hajoa
            Debug.Log("pum");
            Destroy(gameObject);
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
