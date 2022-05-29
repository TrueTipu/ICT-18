using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTexts : MonoBehaviour
{
    [SerializeField] GameObject huone;
    [Header("Ovet")]
    [SerializeField] GameObject doorActivate1;
    [SerializeField] GameObject doorActivate2;
    [SerializeField] GameObject doorActivate3;

    [Header("Nuolet")]
    [SerializeField] GameObject arrowActivate1;
    [SerializeField] GameObject arrowActivate2;

    [Header("Nappi")]
    [SerializeField] GameObject button;

    bool message1 = false;
    bool message2 = false;

    int[] code = { 0, 0, 0 };
    public void DoorDone(int index)
    {
        code[index] = 1;
    }


    public void Arrow()
    {
        message2 = true;
    }
    // Start is called before the first frame update
    IEnumerator Start()
    {
        TextBoxActivator.Guide("Welcome to the tutorial!");
        yield return new WaitForSeconds(2);
        TextBoxActivator.Guide("First you need to inspect what has happened");
        yield return new WaitForSeconds(1);
        TextBoxActivator.Guide("Start by checking the front doors one by one, click the door while you see magnifying glass");
        doorActivate1.SetActive(true);
        doorActivate2.SetActive(true);
        doorActivate3.SetActive(true);

        while(message1 == false)
        {

            if (code[0] == 1 && code[1] == 1 && code[2] == 1 && huone.activeSelf)
            {
                message1 = true;
            }
            yield return null;
        }

        arrowActivate1.SetActive(true);
        arrowActivate2.SetActive(true);


        while (message2 == false)
        {

            TextBoxActivator.Guide("You can now explore other parts of the room by clicking arrows on the side of the screen");
            yield return null;
        }

        TextBoxActivator.Guide("Gather more information by checking weapons and shooting range, when you feel ready just click the progress button on bottom left");
        yield return new WaitForSeconds(2);
        button.SetActive(true);

    }


}
