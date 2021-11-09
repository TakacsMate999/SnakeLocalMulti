using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets;

//Singleton class
//J�k�rd�s, hogy hogy lesz majd pontosan megoldva, amikor t�bb k�gy� lesz :D
public class Head : Cell
{
    public Vector3Int movement = Movement.STOP;
    public Vector3Int rotation = Direction.UP;
    public AudioSource appleCollect;

    bool started = false;

    public Snake snake;

    public GameObject snakeObject;

    // Start is called before the first frame update
    void Start()
    {
        Current = new MovementData(movement, rotation);
        Previous = Current;
        appleCollect=GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if(!Previous.Movement.Equals(Movement.DOWN))
            {
                movement = Movement.UP;
                rotation = Direction.UP;
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (!Previous.Movement.Equals(Movement.RIGHT))
            {
                movement = Movement.LEFT;
                rotation = Direction.LEFT;
            }  
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (!Previous.Movement.Equals(Movement.UP))
            {
                movement = Movement.DOWN;
                rotation = Direction.DOWN;
            }                
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (!Previous.Movement.Equals(Movement.LEFT))
            {
                movement = Movement.RIGHT;
                rotation = Direction.RIGHT;
            }                
        }
    }

    override
    public void Move()
    {
        Previous = Current;
        Current = new MovementData(movement, rotation);
        if (!Current.Movement.Equals(Movement.STOP))
        {
            started = true;
        }
        base.Move();
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        
        if(target.tag == Tags.Apple)
        {
            SoundManager.PlaySound("apple");
            snake.CreateSegment();
            Apple.createApple();            
            Destroy(target.gameObject);
        }
        //K�gy� hozz��r mag�hoz
        if (target.tag == Tags.Snake && started)
        {
            snake.Die();
            SoundManager.PlaySound("gameOver");
        }
        //K�gy� hozz��r mag�hoz
        if (target.tag == Tags.Wall)
        {
            snake.Die();
            SoundManager.PlaySound("gameOver");
        }
    }
}
