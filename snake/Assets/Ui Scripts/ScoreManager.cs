using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text score1Text;
    public Text score2Text;
    public Text maxScoreText;

    static int score1 = 0;
    static int score2 = 0;
    static int maxScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        score1Text.text = score1.ToString();
        score2Text.text = score2.ToString();
        maxScore = GameHandler.winCon;
        maxScoreText.text = maxScore.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        score1Text.text = score1.ToString();
        score2Text.text = score2.ToString();
       
    }

    public static void AddPoint(int which)
    {
        if (which == 0)
        {
            score1++;
        }
        else
        {
            score2++;
        }
        Debug.Log($"Point added to{which}");
    }
    public static void ResetScores()
    {
        score1 = 0;
        score2 = 0;
    }
}
