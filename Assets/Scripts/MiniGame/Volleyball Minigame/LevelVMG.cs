using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelVMG : MonoBehaviour
{
    int currentLv;
    [SerializeField] GameObject[] lvs;
    [SerializeField] int customLv = 0;

    private void Awake()
    {
        PlayerPrefs.SetInt("LevelVMG", customLv);

        if (PlayerPrefs.GetInt("LevelVMG") == 0)
        {
            PlayerPrefs.SetInt("LevelVMG", 1);
        }
        currentLv = PlayerPrefs.GetInt("LevelVMG");
    }

    private void Start()
    {
        foreach (GameObject lv in lvs)
        {
            lv.SetActive(false);
        }

        lvs[currentLv - 1].SetActive(true);
    }

    public void Replay()
    {
        PopupManager.Instance.OnExitPopup();
    }
    public void NextLevel()
    {
        PopupManager.Instance.OnExitPopup();
       
        if(currentLv < lvs.Length)
            PlayerPrefs.SetInt("LevelVMG", PlayerPrefs.GetInt("LevelVMG")+1);
        currentLv = PlayerPrefs.GetInt("LevelVMG");
        Start();
    }
}
