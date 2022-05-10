using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class TextManager : MonoBehaviour
{
    protected TextMeshProUGUI text;
    protected GameObject textBc;
    protected virtual void Start()
    {
        textBc = CanvasHelper.Instance.textBc;
        text = CanvasHelper.Instance.text;
    }

    [SerializeField] protected string[] lines;
    [SerializeField] protected static bool textActive;


    [SerializeField] protected bool localText;


    int lineIndex;


    protected void Update()
    {
        if (textActive == true)
        {
            if (lines.Length > lineIndex)
            {
                if (text.text == lines[lineIndex])
                {
                    Invoke("Close", 3f);
                }
                else CancelInvoke();
            }
            else Invoke("Close", 3f);
        }
        else CancelInvoke();
    }
    protected void Open()
    {
        CancelInvoke();
        localText = true;
        textActive = true;
        lineIndex = 0;
        textBc.gameObject.SetActive(true);
        text.text = lines[lineIndex];
    }
    protected static void Open(string text)
    {
        textActive = true;
        CanvasHelper.Instance.textBc.gameObject.SetActive(true);
        CanvasHelper.Instance.text.text = text;
    }

    protected void ChangeLine()
    {
        if (!localText) return;
        lineIndex += 1;
        if (lineIndex < lines.Length)
        {
            text.text = lines[lineIndex];
        }
        else Close();
    }

    protected void Close()
    {
        CancelInvoke();
        localText = false;
        textActive = false;
        lineIndex = 0;
        textBc.gameObject.SetActive(false);
    }

}
