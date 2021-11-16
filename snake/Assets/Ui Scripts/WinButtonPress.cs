using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinButtonPress : MonoBehaviour
{
    public GameObject inputField;


    public void Click()
    {
        int value = Convert.ToInt32(inputField.GetComponent<Text>().text);
        GameHandler.winCon = value;
        Debug.Log("Changed wincon to " + value);
    }
}
