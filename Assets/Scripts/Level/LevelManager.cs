using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    public int currentLevel;
    public bool thisLevelIsMax;
    void Awake()
    {
        Instance = this;
    }
    public void Replay()
    {
        PopupManager.Instance.OnExitPopup();
        CommandManager.Instance.OnCancel();
    }    
    public void NextLevel()
    {
        if (thisLevelIsMax) return;
        SceneManager.LoadScene("Level"+(currentLevel + 1), LoadSceneMode.Single);
    }    
}
