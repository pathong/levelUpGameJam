﻿ using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class SoundManager : MonoBehaviour
{
    public Sound[] sounds;
    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    private void Start()
    {
        
    }

    public void Play (string name)
    {
       Sound s = Array.Find(sounds, sound => sound.name == name);
       if (s == null)
        {
            Debug.LogWarning("Sound: " + name + "not found!");
            return;
        }
       s.source.Play();
    }
}
