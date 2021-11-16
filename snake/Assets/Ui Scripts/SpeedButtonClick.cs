using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedButtonClick : MonoBehaviour
{
    public GameObject inputField;


    public void Click()
    {
        int value = Convert.ToInt32(inputField.GetComponent<Text>().text);
        GameHandler.speed = value;
        Debug.Log("Changed speed to " + value);
    }
}
