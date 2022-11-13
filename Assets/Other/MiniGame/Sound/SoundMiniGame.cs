using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundMiniGame : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip winSong;
    public AudioClip loseSong;

    void Start()
    {
        audioSource.volume = PlayerPrefs.GetFloat("volume");
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
