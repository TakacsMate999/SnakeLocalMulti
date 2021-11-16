using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetPosition : MonoBehaviour
{

    public TMP_Dropdown dropXs1;
    public TMP_Dropdown dropYs1;

    public TMP_Dropdown dropXs2;
    public TMP_Dropdown dropYs2;

    public void Click()
    {
        int xS1 = Convert.ToInt32(dropXs1.options[dropXs1.value].text);
        int yS1 = Convert.ToInt32(dropXs1.options[dropYs1.value].text);
        int xS2 = Convert.ToInt32(dropXs2.options[dropXs2.value].text);
        int yS2 = Convert.ToInt32(dropYs2.options[dropYs2.value].text);

        GameHandler.snake1StartPos = new Vector2Int(xS1, yS1);
        GameHandler.snake2StartPos = new Vector2Int(xS2, yS2);
        Debug.Log("Set snake1 pos: " + xS1 + " " + yS1 + " snake2 pos: " + xS2 + " " + yS2);
    }
}
