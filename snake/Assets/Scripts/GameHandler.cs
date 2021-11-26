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

    bool gameOver = false;
    public static int startingSegmentCount = 3;
    public static float speed = 0.2f;
    public static int winCon = 20;
    public static Vector2Int snake1StartPos = new Vector2Int(0, 0);
    public static Vector2Int snake2StartPos = new Vector2Int(10, 10);

    public static List<Snake> snakes;

    public 
    // Starting a new game
    void StartGame()
    {
        EndGame.gameHandler = this;

        gameOver = false;

        snakes = new List<Snake>();
        ScoreManager.ResetScores();
        Apple.Initialize(14, 14, applePrefab, particle);
        Apple.CreateApple();

        Snake.speed = speed;
        Snake.startingSegmentCount = startingSegmentCount;

        Snake s1 = Snake.CreateSnake(this, snake1StartPos.x, snake1StartPos.y, snakePrefab);
        s1.SetControllKeys("W", "A", "S", "D");
        snakes.Add(s1);

        Snake s2 = Snake.CreateSnake(this, snake2StartPos.x, snake2StartPos.y, snakePrefab);
        s2.SetControllKeys("I", "J", "K", "L");
        snakes.Add(s2);
    }

    public void Start()
    {
        StartGame();
    }

    public void EndTheGame()
    {
        if (!gameOver)
        {
            SoundManager.PlaySound("gameOver");
            gameOver = true;
            Thread.Sleep(2000);
            UnitySceneManager.LoadScene(2);
            
        }
        
    }

    public static int getSnakeIdx(Snake s)
    {
        Debug.Log(snakes.IndexOf(s));
        return snakes.IndexOf(s);
    }

    void Update()
    {
        for(int i = 0; i < snakes.Count; i++)
        {
            if(snakes[i].segmentCount >= winCon)
            {
                EndGame.winner = i;
                EndTheGame();
            }    
        }
    }

    public void AddScore(Snake s)
    {
        ScoreManager.AddPoint(snakes.IndexOf(s));
    }
}
