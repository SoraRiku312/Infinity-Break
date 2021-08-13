using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public List<Sound> sounds;
    
    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
//        Play("endlessmotion");
    }


    public void Play(string name)
    {
        Sound s = Array.Find(sounds.ToArray(), sound => sound.name == name);
        s.source.PlayOneShot(s.clip);
    }
    
    
}
