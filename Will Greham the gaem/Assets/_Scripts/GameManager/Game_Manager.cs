using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : Singleton<Game_Manager>
{
    public void Win()
    {
        Invoke("VictoryActivate", 3f);
    }

    void VictoryActivate()
    {
        Time.timeScale = 0;
    }
}
