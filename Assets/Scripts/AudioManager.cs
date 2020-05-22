using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class AudioManager : MonoBehaviour
{
    public List<Sound> soundList;
    public List<Sound> DeathSounds;
    System.Random rand;
    private void Awake()
    {
        foreach (Sound s in soundList)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;

            s.source.loop = s.loop;
        }

        foreach (Sound s in DeathSounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;

            s.source.loop = s.loop;
        }
        rand = new System.Random();
    }

    void Start()
    {

    }

    public void Play(string name)
    {
        Sound s = Array.Find(soundList.ToArray(), sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("There is no sound with" + name + " name");
            return;
        }
        s.source.Play();
    }

    public void PlayDeathSound()
    {
        Sound s = DeathSounds[rand.Next(DeathSounds.Count)];
        if (s == null)
        {
            Debug.LogWarning("There is no sound with" + name + " name");
            return;
        }
        s.source.Play();
    }

    public void Pause(string name)
    {
        Sound s = Array.Find(soundList.ToArray(), sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("There is no sound with" + name + " name");
            return;
        }
        s.source.Pause();
    }

    public bool IsPlaying(string name)
    {
        Sound s = Array.Find(soundList.ToArray(), sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("There is no sound with" + name + " name");
            return false;
        }
        return s.source.isPlaying;
    }

    public void StopAllPlaying()
    {
       soundList.ForEach(x => x.source.Stop());
    }
}
