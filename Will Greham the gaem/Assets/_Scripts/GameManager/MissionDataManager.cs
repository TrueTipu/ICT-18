using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionDataManager : StaticInstance<MissionDataManager>
{
    List<MissionData> missionDatas = new List<MissionData>();

    public void AddData(MissionData data)
    {
        missionDatas.Add(data);
    }
}

public class MissionData
{
    public string Name;
    string FailQuote;
}
