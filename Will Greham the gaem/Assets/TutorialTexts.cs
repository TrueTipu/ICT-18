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
        TextBoxActivator.Guide("Tervetuloa tutoriaaliin!");
        yield return new WaitForSeconds(2);
        TextBoxActivator.Guide("Sinun pit‰‰ selvitt‰‰ aluksi mit‰ on tapahtunut, (Edist‰ Dialogia painamalla Q)");
        while (!Input.GetKey(KeyCode.Q))
        {
            TextBoxActivator.Guide("Sinun pit‰‰ selvitt‰‰ aluksi mit‰ on tapahtunut, (Edist‰ Dialogia painamalla Q)");
            yield return null;
        }
        TextBoxActivator.Guide("Aloita tutkimalla kaikki ovet (voit zoomata ja tutkia ovia klikkaamalla suurennuslasin ilmestyess‰)");
        doorActivate1.SetActive(true);
        doorActivate2.SetActive(true);
        doorActivate3.SetActive(true);

        while(message1 == false)
        {
            Debug.Log(code.Equals(new int[] { 1, 1, 1 }));
            if (code.Equals(new int[] { 1, 1, 1 }) && huone.activeSelf)
            {
                message1 = true;
            }
            yield return null;
        }

        TextBoxActivator.Guide("Voit nyt k‰‰nty‰ n‰p‰ytt‰m‰ll‰ nuolia huoneen sivuilla");
        arrowActivate1.SetActive(true);
        arrowActivate2.SetActive(true);


        while (message2 == false)
        {

            yield return null;
        }

        TextBoxActivator.Guide("Selvit‰ lis‰‰ tietoa tutkimalla aseita, kun koet olevasi valmis matkaa menneisyyteen toteuttamaan tekosi ruudun oikeasta alalaidasta");
        button.SetActive(true);
    }


}
