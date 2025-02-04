﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
[System.Serializable]
public class Audio
{


    public string audioName;

    public AudioClip clip;

    public bool loop;

    [Range(.1f, 1f)]
    public float volume = 1;
    [Range(.1f, 3f)]
    public float pitch = 1;


    public AudioSource source;
}
