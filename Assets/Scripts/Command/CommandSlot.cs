using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CommandSlot : MonoBehaviour
{
    public TMP_Text description;
    public CommandType commandType;
    public TMP_Text index;
    public Guid id;
    public void SetBackgroundColor()
    {
        switch(commandType)
        {
            case CommandType.VectorX:
                GetComponent<Image>().color = Color.cyan;
                break;
            case CommandType.VectorY:
                GetComponent<Image>().color = Color.gray;
                break;
            case CommandType.VectorZ:
                break;
            case CommandType.WaitMilliseconds:
                GetComponent<Image>().color = Color.green;
                break;
        }    
    }    
    public void OnMoveUp()
    {

    }   
    public void OnMoveDown()
    {

    }   
    public void OnDelete()
    {

    }    
}
