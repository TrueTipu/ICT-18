using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : Singleton<Game_Manager>
{
    [SerializeField] MissionDataWinScreen winScreen;
    [SerializeField] GameObject LoseScreen;

    [SerializeField] bool chillMusic;


    private void Start()
    {
        print("" + (!chillMusic));
        AudioManager.Instance.Stop("" + (!chillMusic));
        AudioManager.Instance.Play("" + (chillMusic));
        
    }

    int deaths = 0;
    public void Win()
    {
        Invoke("VictoryActivate", 3f);
    }
    public void AddDeath()
    {
        deaths += 1;
        if(deaths == 3)
        {
            Win();
        }
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
