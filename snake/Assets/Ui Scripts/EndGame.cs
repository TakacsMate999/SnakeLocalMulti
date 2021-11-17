using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class EndGame : MonoBehaviour
{
    public void Restart()
    {
        UnitySceneManager.LoadScene("GameScene");
    }

    public void LoadMenu()
    {
        UnitySceneManager.LoadScene("Menu");
    }
}
