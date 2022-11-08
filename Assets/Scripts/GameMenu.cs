using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    [SerializeField] GameObject menuPanel;
    [SerializeField] GameObject mainCamera;
    [SerializeField] GameObject mapCamera;
    public void OnOpenMenu()
    {
        menuPanel.SetActive(true);

    }   
    public void OnExitMenu()
    {
        menuPanel.SetActive(false);

    }   
    public void OnHome()
    {
        try
        {
            SoundManager.currentScene = Scene.Menu; 
        }
        catch
        {

        }
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
    public void OnChooseLevel()
    {
        SceneManager.LoadScene("ChooseLevel", LoadSceneMode.Single);
    }
    public void OnCheckMap()
    {
        mapCamera.SetActive(true);
        mainCamera.SetActive(false);
    }
    public void OnExitCheckMap()
    {
        mapCamera.SetActive(false);
        mainCamera.SetActive(true);
    }

}
