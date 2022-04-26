using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MissionDataManager : Singleton<MissionDataManager>
{
    List<MissionData> missionDatas = new List<MissionData>();

    [SerializeField] GameObject textFieldTemplate;

    [SerializeField] Transform panel;

    public void AddData(MissionData data)
    {
        missionDatas.Add(data);
        UpdatePanel(data);
    }

    private void UpdatePanel(MissionData data)
    {
        TextMeshProUGUI textField = Instantiate(textFieldTemplate, panel, false).GetComponent<TextMeshProUGUI>();
        textField.text = data.Name;
    }

}
[System.Serializable]
public class MissionData
{
    public string Name;
    string FailQuote;
}

public interface SendData
{
    MissionData data { get; }
}
