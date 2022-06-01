using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Number : MonoBehaviour
{

    [SerializeField]List<GameObject> numbers = new List<GameObject>();
    int value = 0;

    public void AddNum()
    {
        value += 1;
        if (value > 9) value = 0;

        foreach (GameObject number in numbers)
        {
            number.SetActive(false);
        }
        numbers[value].SetActive(true);
    }

    public void DelNum()
    {
        value -= 1;
        if (value < 0) value = 9;
        foreach (GameObject number in numbers)
        {
            number.SetActive(false);
        }
        numbers[value].SetActive(true);
    }

}
