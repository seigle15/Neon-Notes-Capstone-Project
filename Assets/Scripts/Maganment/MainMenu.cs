using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    [SerializeField] private static AudioSource music;
    public List<AudioClip> musicDiff;
    public MusicManager _manager;
    private float difficultyBeats;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void SetDifficulty(int diff)
    {
       
        switch (diff)
        {
            case 0:
                if(musicDiff != null)
                    _manager.ChangeMusic(musicDiff[0]);
                Debug.Log("Easy Mode");
                difficultyBeats = .25f;
                break;
            case 1:
                if(musicDiff != null)
                    _manager.ChangeMusic(musicDiff[1]);
                Debug.Log("Medium Mode");
                difficultyBeats = .5f;
                break;
            case 2:
                if(musicDiff != null)
                    _manager.ChangeMusic(musicDiff[2]);
                Debug.Log("Easy Mode");
                difficultyBeats = .6f;
                break;
        }
        _manager.SetDifficulty(difficultyBeats);
        PlayGame();
    }
    
}
