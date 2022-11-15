using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum Scene
{
    Menu, Level
}
public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    public static Scene currentScene;
    public AudioSource audioSource;
    public AudioClip mainMenuSong;
    public AudioClip[] gameSong;
    public AudioClip winSong;
    public AudioClip loseSong;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        audioSource.volume = PlayerPrefs.GetFloat("volume");

        if(currentScene == Scene.Menu)
        {
            audioSource.clip = mainMenuSong;
            
        }    
        else if(currentScene == Scene.Level)
        {
            audioSource.clip = gameSong[Random.Range(0, gameSong.Length)];
        }
        audioSource.Play();
    }
    public void PlayGameSong()
    {
        audioSource.clip = gameSong[Random.Range(0, gameSong.Length)];
        audioSource.Play();
    }    
    public void PlayWinSong()
    {
        audioSource.clip = winSong;
        audioSource.Play();
    }
    public void PlayLoseSong()
    {
        audioSource.clip = loseSong;
        audioSource.Play();
    }    
}
