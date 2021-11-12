using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public GameObject snakePrefab;
    public GameObject applePrefab;
    // Start is called before the first frame update
    void Start()
    {
        Apple.Initialize(14, 14, applePrefab);
        Apple.createApple();
        Snake.CreateSnake(5, 6, snakePrefab).setControllKeys("W", "A", "S", "D");
        Snake.CreateSnake(7, 8, snakePrefab).setControllKeys("I", "J", "K", "L");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
