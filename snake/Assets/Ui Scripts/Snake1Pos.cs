using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Snake1Pos : MonoBehaviour
{
    int x = 0;
    int y = 0;

    public TMP_Dropdown dropX;
    public TMP_Dropdown dropY;

    private void Start()
    {
        dropX.onValueChanged.AddListener(delegate
        {
            ClickX(dropX);
        });
        dropY.onValueChanged.AddListener(delegate
        {
            Clicky(dropY);
        });
    }

    public void ClickX(TMP_Dropdown sender)
    {
        x = Convert.ToInt32(sender.value);
        GameHandler.snake1StartPos = new Vector2Int(x, y);
        Debug.Log("Set snake1 pos: " + x + " " + y);
    }

    public void Clicky(TMP_Dropdown sender)
    {
        y = Convert.ToInt32(sender.value);
        GameHandler.snake1StartPos = new Vector2Int(x, y);
        Debug.Log("Set snake1 pos: " + x + " " + y);
    }
}
