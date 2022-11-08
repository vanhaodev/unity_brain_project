using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseLevelSlot : MonoBehaviour
{
    public int level;
    public void OnClick()
    {
        SceneManager.LoadScene("Level" + (level), LoadSceneMode.Single);
    }    
}
