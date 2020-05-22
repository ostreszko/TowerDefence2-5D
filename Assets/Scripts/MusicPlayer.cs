using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    GlobalGameMaster ggm;
    public string musicName;
    void Start()
    {
        ggm = GlobalGameMaster.GGM;
        playLocalMusic(musicName);
    }

    void playLocalMusic(string musicName)
    {
        if (!ggm.audioManager.IsPlaying(musicName))
        {
            ggm.audioManager.StopAllPlaying();
            ggm.audioManager.Play(musicName);
        }

    }

}
