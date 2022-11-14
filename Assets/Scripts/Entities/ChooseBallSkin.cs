using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseBallSkin : MonoBehaviour
{
    public GameObject[] skins;
    void Start()
    {
        RefreshSkin();
    }
    void RefreshSkin()
    {
        for (int i = 0; i < skins.Length; i++)
        {
            if (PlayerPrefs.GetInt("BallSkin") == i)
            {
                skins[i].SetActive(true);
            }
            else
            {
                skins[i].SetActive(false);
            }
        }
    }    
    public void OnNextBallRight()
    {
        SetBall(true);
    }
    public void OnNextBallLeft()
    {
        SetBall(false);
    }
    void SetBall(bool right)
    {
        if(right)
        {
            if(PlayerPrefs.GetInt("BallSkin") < skins.Length - 1)
            {
                skins[PlayerPrefs.GetInt("BallSkin") + 1].SetActive(true);
                PlayerPrefs.SetInt("BallSkin", PlayerPrefs.GetInt("BallSkin") + 1);
            }    
            else if(PlayerPrefs.GetInt("BallSkin") == skins.Length - 1)
            {
                skins[0].SetActive(true);
                PlayerPrefs.SetInt("BallSkin", 0);
            }    

        }    
        else
        {
            if (PlayerPrefs.GetInt("BallSkin") > 0)
            {
                skins[PlayerPrefs.GetInt("BallSkin") - 1].SetActive(true);
                PlayerPrefs.SetInt("BallSkin", PlayerPrefs.GetInt("BallSkin") - 1);
            }
            else if (PlayerPrefs.GetInt("BallSkin") == 0)
            {
                skins[skins.Length - 1].SetActive(true);
                PlayerPrefs.SetInt("BallSkin", skins.Length - 1);
            }
        }    

        RefreshSkin();
    }    

}
