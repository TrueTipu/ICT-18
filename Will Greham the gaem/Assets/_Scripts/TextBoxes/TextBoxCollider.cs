using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextBoxCollider : TextManager
{




    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ChangeLine();
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && textActive == false)
        {
            Open();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && textActive == true)
        {
            Close();
        }
    }
}
