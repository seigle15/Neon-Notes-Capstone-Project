using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource selectedMusic;
    static public float difficulty;
    static private MusicManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }

    public void ChangeMusic(AudioClip music)
    {
        if(selectedMusic.isPlaying)
            selectedMusic.Stop();
        
        selectedMusic.clip = music;
        selectedMusic.Play();
    }

    public void SetDifficulty(float setting)
    {
        difficulty = setting;
    }

    public float GetDifficulty()
    {
        return difficulty;
    }
}
