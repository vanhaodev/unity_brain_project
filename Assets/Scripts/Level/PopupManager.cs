using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopupManager : MonoBehaviour
{
    public static PopupManager Instance;
    [SerializeField] GameObject popup;
    [SerializeField] GameObject btnNext;
    [SerializeField] TMP_Text popupContent;
    [SerializeField] GameObject winParticle;
    [SerializeField] GameObject winParticle2;
    [SerializeField] GameObject loseParticle;

    [SerializeField] GameObject[] hideUIObject;
    void Awake()
    {
        Instance = this;
    }
    public void FreezeTimeScale()
    {
        Time.timeScale = 0;
    }    
    public void HideUI()
    {
        foreach(GameObject ui in hideUIObject)
        {
            ui.SetActive(!ui.activeSelf);
        }    
    }    
    public void OnWin()
    {
        SoundManager.Instance.PlayWinSong();
        popup.SetActive(true);
        winParticle.SetActive(true);
        winParticle2.SetActive(true);
        loseParticle.SetActive(false);
        btnNext.SetActive(true);
        HideUI();
        popupContent.text = "You won!\n" +
            "<size=40>You're amazing!</size>";
    
    }   
    public void OnLose()
    {
        SoundManager.Instance.PlayLoseSong();
        popup.SetActive(true);
        winParticle.SetActive(false);
        winParticle2.SetActive(false);
        loseParticle.SetActive(true);
        btnNext.SetActive(false);
        HideUI();
        popupContent.text = "You lose!\n" +
            "<size=40>Don't cry!</size>";

    }    
    public void OnExitPopup()
    {
        SoundManager.Instance.PlayGameSong();
        HideUI();
        popup.SetActive(false);
        Time.timeScale = 1;
    }    
}
