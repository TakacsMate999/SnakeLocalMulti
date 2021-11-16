using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedButtonClick : MonoBehaviour
{
    public InputField inputField;


    public void Click()
    {
        double value = Convert.ToDouble(inputField.text);
        GameHandler.speed = (float)value;
        Debug.Log("Changed speed to " + value);
    }
}
