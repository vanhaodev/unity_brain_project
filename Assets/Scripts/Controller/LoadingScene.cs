using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour
{
    public static LoadingScene Instance;
    public GameObject loadingScreen;
    public Image loadingBarFill;
    public TMP_Text loadingPercent;
    private void Awake()
    {
        Instance = this;
    }
    public void LoadScene(string scene)
    {
        StartCoroutine(LoadSceneAsync(scene));
    }
    IEnumerator LoadSceneAsync(string scene)
    {
        //AsyncOperation operation = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Single);

        //loadingScreen.SetActive(true);
        //while (!operation.isDone)
        //{
        //    float progress = Mathf.Clamp01(operation.progress / 0.9f);
        //    loadingBarFill.fillAmount = progress;
        //    yield return null;
        //}
        yield return null;

        //Begin to load the Scene you specify
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(scene);
        //Don't let the Scene activate until you allow it to
        asyncOperation.allowSceneActivation = false;
        loadingScreen.SetActive(true);
        Debug.Log("Pro :" + asyncOperation.progress);
        //When the load is still in progress, output the Text and progress bar
        while (!asyncOperation.isDone)
        {
            //Output the current progress
            loadingPercent.text = (int)System.Math.Round((asyncOperation.progress * 100)) + "%";
            float progress = Mathf.Clamp01(asyncOperation.progress / 0.9f);
            loadingBarFill.fillAmount = progress;
            // Check if the load has finished
            if (asyncOperation.progress >= 0.9f)
            {
                asyncOperation.allowSceneActivation = true;
                loadingPercent.text = "100%";
                ////Change the Text to show the Scene is ready
                //loadingPercent.text = "Press the space bar to continue";
                ////Wait to you press the space key to activate the Scene
                //if (Input.GetKeyDown(KeyCode.Space))
                //    //Activate the Scene
                //    asyncOperation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
