using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;
using UnityEngine.UIElements;
using TMPro;

public class ChooseLevelManager : MonoBehaviour
{
    [SerializeField] GameObject levelButtonSlotPrefab;
    [SerializeField] GameObject levelButtonSlotContainer;
    void OnEnable()
    {
        if (PlayerPrefs.GetInt("CurrentLevel") < 1)
        {
            PlayerPrefs.SetInt("CurrentLevel", 1);
        }    
        for(int i = 0; i < PlayerPrefs.GetInt("CurrentLevel"); i++)
        {
            GameObject slot = Instantiate(levelButtonSlotPrefab, levelButtonSlotContainer.transform);
            slot.GetComponent<ChooseLevelSlot>().level = i+1;
            slot.GetComponentInChildren<TMP_Text>().text = (i + 1).ToString();
        }

        levelButtonSlotContainer.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 360f + (360f * ((PlayerPrefs.GetInt("CurrentLevel")-1)/2)));
    }
}
