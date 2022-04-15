using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CycleCalculator : MonoBehaviour
{
    [SerializeField] int items;

    float fillSize;

    [SerializeField] Slot[] slots;
    //[SerializeField] Image[] images = new Image[6];
    //RectTransform[] slots;

    public Slot[] GetSlots()
    {
        return slots;
    }

    private void Start()
    {
        ReCalculate(items);
    }

    public void Increase(Item item)
    {
        items += 1;
        ReCalculate(items);
    }

    public void Decrease(int a)
    {
        items -= 1;
        ReCalculate(items);
    }

    //int changeCheck;
    //void Update()
    //{

    //    if(items != changeCheck)
    //    {
    //        ReCalculate(items);
    //    }

    //    changeCheck = items;
    //}

    void ReCalculate(int count)
    {
        int i = 0;
        float rotation = 0;
        float rotationStep = 360.0f / count;
        float slotRotate = 90 - 180.0f / count;
        foreach (Slot slot in slots)
        {
            if(i < count)
            {
                //muutetaan taustan koko ja rotaatio
                Image img = slot.Image;
                img.gameObject.SetActive(true);
                img.fillAmount = 1.0f / count;
                img.transform.eulerAngles = new Vector3(0, 0, rotation);
                //kasvatetaan rotaatiota
                rotation += rotationStep;
                //lasketaan keskikohdan rotaatio
                slot.SlotParent.gameObject.SetActive(true);
                slot.SlotParent.localEulerAngles = new Vector3(0, 0, slotRotate);
            }
            else
            {
                //sammutetaan ylijäävät
                slot.Image.gameObject.SetActive(false);

                slot.SlotParent.gameObject.SetActive(false);
            }
            i++;
        }
    }
}
