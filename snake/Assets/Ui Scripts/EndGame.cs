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

    public void Refresh()
    {
        text.GetComponent<Text>().text = ("The winner is: " + winner.ToString());
    }

    void OnEnable()
    {
        UnitySceneManager.sceneLoaded += OnSceneLoaded;
    }

    // called second
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Refresh();
    }

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
