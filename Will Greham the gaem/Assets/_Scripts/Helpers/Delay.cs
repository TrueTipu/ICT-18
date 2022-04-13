using System;
using System.Collections.Generic;
using UnityEngine;

public class Delay
{
    float time;
    float timer;
    public Delay(float _time)
    {
        time = _time;
    }
    public void Activate()
    {
        timer = time;
        Activated = true;
    }
    public void Tick()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            Activated = false;
        }
    }
    public bool Activated { get; private set; }

}
