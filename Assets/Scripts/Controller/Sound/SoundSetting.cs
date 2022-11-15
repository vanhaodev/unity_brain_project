
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSetting : MonoBehaviour
{
    public Slider volumeSlider;
    private void Start()
    {
        try
        {
            if(volumeSlider != null)
            {
                volumeSlider.value = PlayerPrefs.GetFloat("volume");
            }    
        }
        catch (System.Exception e)
        {
            Debug.Log(e);
        }
    }
    public void OnChangeVolume()
    {
        
        try
        {
            PlayerPrefs.SetFloat("volume", volumeSlider.value);
            GetComponent<SoundManager>().audioSource.volume = PlayerPrefs.GetFloat("volume");
        }
        catch (System.Exception e)
        {
            Debug.Log(e);
        }
    }
}
