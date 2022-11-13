using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseMiniGame : MonoBehaviour
{
    public void ChooseVolleyball()
    {
        SceneManager.LoadScene("VolleyballGame", LoadSceneMode.Single);
    }

    public void ChooseCalculator()
    {
        SceneManager.LoadScene("CalculatorGame", LoadSceneMode.Single);
    }
}
