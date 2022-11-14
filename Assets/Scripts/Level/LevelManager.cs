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
    private void Start()
    {
        currentLevel = int.Parse(SceneManager.GetActiveScene().name[SceneManager.GetActiveScene().name.Length - 1].ToString());
    }
    public void Replay()
    {
        PopupManager.Instance.OnExitPopup();
        CommandManager.Instance.OnCancel();
    }
    public void UpdateLevel()
    {
        if (thisLevelIsMax) return;
        int level = currentLevel + 1;
        if (level > PlayerPrefs.GetInt("CurrentLevel"))
        {
            PlayerPrefs.SetInt("CurrentLevel", level);
        }
    }
    public void NextLevel()
    {
        //if (thisLevelIsMax) return;
        int level = currentLevel + 1;
        //if(level > PlayerPrefs.GetInt("CurrentLevel"))
        //{
        //    PlayerPrefs.SetInt("CurrentLevel", level);
        //}    
        SceneManager.LoadScene("Level"+level, LoadSceneMode.Single);
    }    
}
