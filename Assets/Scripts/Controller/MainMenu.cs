using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayGame()
    {
        try
        {
            SoundManager.currentScene = Scene.Level;
        }
        catch
        {

        }
        //SceneManager.LoadScene("ChooseLevel", LoadSceneMode.Single);
        LoadingScene.Instance.LoadScene("ChooseLevel");
        
    }

    public void PlayMiniGame()
    {
        //SceneManager.LoadScene("ChooseMiniGame", LoadSceneMode.Single);
        LoadingScene.Instance.LoadScene("ChooseMiniGame");
    }    
    public void Information()
    {
        try
        {
            Application.OpenURL("https://trello.com/b/uSVsyYFk/brainup");
        }
        catch
        {

        }
    }    
    public void SettingGame()
    {

    }    
    public void ExitGame()
    {
        Application.Quit();
    }    
}
