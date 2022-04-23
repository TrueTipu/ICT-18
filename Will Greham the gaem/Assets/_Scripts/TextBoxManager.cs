using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextBoxManager : MonoBehaviour
{
    [SerializeField] string[] lines;
    [SerializeField] bool textActive;

    TextMeshProUGUI text;

    int lineIndex;

    private void Start()
    {
        text = CanvasHelper.Instance.text;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ChangeLine();
        }
    }
    void Open()
    {
        textActive = true;
        lineIndex = 0;
        text.gameObject.SetActive(true);
        text.text = lines[lineIndex];
    }

    void ChangeLine()
    {
        if (!textActive) return;
        lineIndex += 1;
        if (lineIndex < lines.Length)
        {
            text.text = lines[lineIndex];
        }
        else Close();
    }

    void Close()
    {
        textActive = false;
        lineIndex = 0;
        text.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
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
