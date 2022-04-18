using UnityEngine;
using System.Collections;

public class InvItem : PhysicalItem
{
    public int id;
    private void Start()
    {
        StartCoroutine(LateStart());
    }
    protected override IEnumerator LateStart()
    {
        yield return null;
        Init(itemData.GetItemIcon());
    }

}
