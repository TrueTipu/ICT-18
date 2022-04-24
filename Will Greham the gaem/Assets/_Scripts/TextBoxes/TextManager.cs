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
    [SerializeField] protected bool textActive;



    int lineIndex;

    protected void Open()
    {
        textActive = true;
        lineIndex = 0;
        textBc.gameObject.SetActive(true);
        text.text = lines[lineIndex];
    }

    protected void ChangeLine()
    {
        if (!textActive) return;
        lineIndex += 1;
        if (lineIndex < lines.Length)
        {
            text.text = lines[lineIndex];
        }
        else Close();
    }

    protected void Close()
    {
        textActive = false;
        lineIndex = 0;
        textBc.gameObject.SetActive(false);
    }

}
