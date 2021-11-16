using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public GameObject snakePrefab;
    public GameObject applePrefab;

    public static int startingSegmentCount = 3;
    public static int speed = 70;
    public static int winCon = 20;
    public static Vector2Int snake1StartPos = new Vector2Int(0, 0);
    public static Vector2Int snake2StartPos = new Vector2Int(10, 10);

    public 
    // Start is called before the first frame update
    void Start()
    {
        Apple.Initialize(14, 14, applePrefab);
        Apple.createApple();
        Snake.CreateSnake(snake1StartPos.x, snake1StartPos.y, snakePrefab).setControllKeys("W", "A", "S", "D");
        Snake.CreateSnake(snake2StartPos.x, snake2StartPos.y, snakePrefab).setControllKeys("I", "J", "K", "L");
    }

    // Update is called once per frame
    void Update()
    {
        //Vizsgáljuk, hogy nyertünk el
    }
}
