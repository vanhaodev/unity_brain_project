using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class CalculatorGPC : MonoBehaviour
{
    [SerializeField] GameObject calLevelManager;
    [SerializeField] GameObject selectLevel;


    public void RePlay()
    {
        SceneManager.LoadScene("CalculatorGame", LoadSceneMode.Single);
    }

    public void SelectLevel()
    {
        PopupManager.Instance.OnExitPopup();
        PopupManager.Instance.HideUI();
        selectLevel.SetActive(true);
    }    
}
