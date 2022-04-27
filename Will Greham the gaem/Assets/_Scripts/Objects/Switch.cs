using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour, ButtonIcon, SendData
{
    bool inTouch = false;
    Collider2D collider;

    [SerializeField] GameObject light;


    [SerializeField] GameObject _iconObject;

    [SerializeField] MissionData _data;

    bool first = false;

    public MissionData data { get { return _data; } private set { _data = value; } }
    public GameObject IconObect
    {
        get { return _iconObject; }
        private set { _iconObject = value; }
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
            light.SetActive(!light.activeSelf); //vaihda eventiksi multiusageen
            if (!first)
            {
                first = true;
                MissionDataManager.Instance.AddData(data);
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

    public void ShowIcon()
    {
        IconObect.SetActive(true);
    }

    public void HideIcon()
    {
        IconObect.SetActive(false);
    }
}
