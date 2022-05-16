using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
public class AudioManager : Singleton<AudioManager>
{

    public Audio[] sounds;
    protected override void Awake()
    {
        base.Awake();
        foreach (Audio s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
        DontDestroyOnLoad(gameObject);
    }
    public void Stop(string audioName)
    {
        Audio s = Array.Find(sounds, sound => sound.audioName == audioName);

        s.source.Stop();
    }
    public string Randomize(string[] names)
    {
        int i = UnityEngine.Random.Range(0, names.Length);
        Play(names[i]);
        return names[i];
    }
    public void Play(string audioName)
    {
       Audio s = Array.Find(sounds, sound => sound.audioName == audioName);
        Debug.Log(audioName+": "+s.clip+": "+ s.source);
        s.source.Play();
    }
}
