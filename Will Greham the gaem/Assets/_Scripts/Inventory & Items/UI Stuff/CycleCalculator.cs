using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CycleCalculator : MonoBehaviour
{
    [SerializeField] int items;

    float fillSize;

    [SerializeField] Image[] images = new Image[6];
    [SerializeField] RectTransform[] slots = new RectTransform[0];

    private void Start()
    {
        ReCalculate(items);
    }

    int changeCheck;
    void Update()
    {

        if(items != changeCheck)
        {
            ReCalculate(items);
        }

        changeCheck = items;
    }

    void ReCalculate(int count)
    {
        int i = 0;
        float rotation = 0;
        float rotationStep = 360.0f / count;
        float slotRotate = 90 - 180.0f / count;
        foreach (Image slot in images)
        {
            if(i < count)
            {
                slot.gameObject.SetActive(true);
                slot.fillAmount = 1.0f / count;
                slot.transform.eulerAngles = new Vector3(0, 0, rotation);
                rotation += rotationStep;
                slots[i].gameObject.SetActive(true);
                slots[i].localEulerAngles = new Vector3(0, 0, slotRotate);
            }
            else
            {
                slot.gameObject.SetActive(false);
                slots[i].gameObject.SetActive(false);
            }
            i++;
        }
    }
}
