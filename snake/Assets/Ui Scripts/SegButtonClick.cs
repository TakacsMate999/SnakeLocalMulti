using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SegButtonClick : MonoBehaviour
{
    public GameObject inputField;


    public void Click()
    {
        int value = Convert.ToInt32(inputField.GetComponent<Text>().text);
        GameHandler.startingSegmentCount = value;
        Debug.Log("Changed segment count to " + value);
    }
}
