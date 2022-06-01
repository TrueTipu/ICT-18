using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class Lock : MonoBehaviour
{
    public bool open;
   
    [SerializeField] Image UI;

    int[] numbers = new int[] { 0, 0, 0, 0 };
    [SerializeField] int[] code;


    public void ShowUI()
    {
        UI.gameObject.SetActive(true);
    }
    public void AddNumber(int index)
    {
        numbers[index - 1] += 1;
        if (numbers[index - 1] > 10) numbers[index - 1] = 0;
    }
    
    public void DecreaseNumber(int index)
    {
        numbers[index - 1] -= 1;
        if (numbers[index - 1] < 0) numbers[index - 1] = 9;
    }

    public void Test()
    {
        if(code[0] == numbers[0] && code[1] == numbers[1] && code[2] == numbers[2] && code[3] == numbers[3])
        {
            TextBoxActivator.Guide("You opened lock. Now you can reach inside the case.");
            open = true;
            UI.gameObject.SetActive(false);
        }
        else
        {
            TextBoxActivator.Guide("Wrong code. Try again.");
        }
    }
}
