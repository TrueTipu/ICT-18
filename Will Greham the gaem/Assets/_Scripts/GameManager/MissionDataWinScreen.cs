using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MissionDataWinScreen : MonoBehaviour
{
    [SerializeField] List<MissionData> correctDatas;

    [SerializeField] GameObject textFieldTemplateGrey;
    [SerializeField] GameObject textFieldTemplateRed;
    [SerializeField] GameObject textFieldTemplateGreen;


    [SerializeField] Transform panel;
    [SerializeField] Transform panel2;

    [SerializeField] GameObject wonScreen;

    public void Init()
    {
        CreatePanel();
    }

    void CreatePanel()
    {
        bool noError = true;
        List<MissionData> _data = MissionDataManager.Instance.getData();
        for(int i = 0; i < _data.Count; i++)
        {
            UpdatePanel(_data[i], textFieldTemplateGrey, panel2); //hard mode panel
            MissionData correct; 
            //if (i >= correctDatas.Count) //siltä varalta että pelaaja tekee useamman action kuin listassa
            //{
            //    correct = new MissionData("-");
            //}
            //else correct = correctDatas[i];

            //aloitetaan varsinainen tarkistus
            if(ContainsStatus(correctDatas, _data[i]) && noError)
            {
                UpdatePanel(_data[i], textFieldTemplateGreen, panel);
            }
            else if(noError && !ContainsStatus(correctDatas, _data[i]))
            {
                noError = false;
                UpdatePanel(_data[i], textFieldTemplateRed, panel);
            }
            else
            {
                UpdatePanel(_data[i], textFieldTemplateGrey, panel);
            }
        }
        if (noError)
        {
            wonScreen.SetActive(true);
        }
    }
    private bool ContainsStatus(List<MissionData> dataSet, MissionData status)
    {
        foreach (MissionData value in dataSet)
        {
            if(status.Name == value.Name)
            return true;
        }

        return false;
    }

    private void UpdatePanel(MissionData data, GameObject template, Transform _panel)
    {
        TextMeshProUGUI textField = Instantiate(template, _panel, false).GetComponent<TextMeshProUGUI>();
        textField.text = data.Name;
    }

}
