using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : Singleton<Game_Manager>
{
    [SerializeField] MissionDataWinScreen winScreen;
    [SerializeField] GameObject LoseScreen;
    public void Win()
    {
        Invoke("VictoryActivate", 3f);
    }

    void VictoryActivate()
    {
        Time.timeScale = 0;
        winScreen.gameObject.SetActive(true);
        winScreen.Init();
    }

    public void SetGameOver()
    {
        Time.timeScale = 0;
        LoseScreen.SetActive(true);
    }
}
