using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConfig : MonoBehaviour
{
    private void Awake()
    {
        Application.targetFrameRate = 144;
#if UNITY_EDITOR
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetFloat("volume", 0.70f);
#endif
    }
}
