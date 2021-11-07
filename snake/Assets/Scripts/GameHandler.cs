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
        this.createSnake(5, 6);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void createSnake(int x, int y)
    {
        Snake first = Instantiate(snakePrefab).GetComponent<Snake>();
        //first.reposition(x, y);
    }
}
