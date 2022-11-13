using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSkin : MonoBehaviour
{
    public GameObject[] skins;
    void Start()
    {
        SetBallSkin();
    }
    void SetBallSkin()
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

}
