using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class GameHandler : MonoBehaviour
{
    public GameObject snakePrefab;
    public GameObject applePrefab;
    public GameObject particle;

    public static int startingSegmentCount = 3;
    public static float speed = 0.2f;
    public static int winCon = 20;
    public static Vector2Int snake1StartPos = new Vector2Int(0, 0);
    public static Vector2Int snake2StartPos = new Vector2Int(10, 10);

    

    public 
    // Start is called before the first frame update
    void Start()
    {
        
        Apple.Initialize(14, 14, applePrefab, particle);
        Apple.createApple();

        Snake.speed = speed;
        Snake.startingSegmentCount = startingSegmentCount;

        Snake.CreateSnake(this,snake1StartPos.x, snake1StartPos.y, snakePrefab).setControllKeys("W", "A", "S", "D");
        Snake.CreateSnake(this,snake2StartPos.x, snake2StartPos.y, snakePrefab).setControllKeys("I", "J", "K", "L");
    }

    public void EndGame()
    {
        SoundManager.PlaySound("gameOver");
        Thread.Sleep(2000);
        UnitySceneManager.LoadScene("GameOver");
    }
    // Update is called once per frame
    void Update()
    {
        //Vizsgáljuk, hogy nyertünk el
    }
}
