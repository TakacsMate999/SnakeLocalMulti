using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class RestartGame : MonoBehaviour
{
    // Start is called before the first frame update
    public void Restart()
    {
        UnitySceneManager.LoadScene("GameScene");
    }
}
