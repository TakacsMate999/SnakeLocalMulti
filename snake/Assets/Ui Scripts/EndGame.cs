using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    public static int winner = -1;
    public GameObject text;
    public static GameHandler gameHandler;

    /*public void Refresh()
    {
        if (text.GetComponent<Text>() != null)
        {
            text.GetComponent<Text>().text = ("The winner is: " + winner.ToString());
        }
        
    }*/

    void OnEnable()
    {
        //UnitySceneManager.sceneLoaded += OnSceneLoaded;
        if (text.GetComponent<Text>() != null)
        {
            text.GetComponent<Text>().text = ("The winner is: Player " + winner.ToString());
        }
    }

    // called second
    /*void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (text.GetComponent<Text>() != null)
        {
            text.GetComponent<Text>().text = ("The winner is: " + winner.ToString());
        }
    }*/

    public void Restart()
    {
        gameHandler.StartGame();
        UnitySceneManager.LoadScene(1);
    }

    public void LoadMenu()
    {
        gameHandler.StartGame();
        UnitySceneManager.LoadScene(0);
    }
}
