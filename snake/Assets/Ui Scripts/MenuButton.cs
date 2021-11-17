using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class MenuButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadMenu()
    {
        UnitySceneManager.LoadScene("Menu");
    }
}
