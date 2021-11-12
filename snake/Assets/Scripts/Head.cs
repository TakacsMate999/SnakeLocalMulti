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

    KeyCode up = KeyCode.W;
    KeyCode left = KeyCode.A;
    KeyCode down = KeyCode.S;
    KeyCode right = KeyCode.D;

    bool started = false;

    public Snake snake;

    //A kapott stringeket �ll�tja be az ir�ny�t�sra. Ha t�bb mint egy karakter a kapott string valamelyike akkor meghalunk. Nme k�ne, hogy ilyen legyen.
    public void setControllKeys(string up, string left, string down, string right)
    {
        this.up = (KeyCode)System.Enum.Parse(typeof(KeyCode), up);
        this.left = (KeyCode)System.Enum.Parse(typeof(KeyCode), left);
        this.down = (KeyCode)System.Enum.Parse(typeof(KeyCode), down);
        this.right = (KeyCode)System.Enum.Parse(typeof(KeyCode), right);
    }

    // Start is called before the first frame update
    void Start()
    {
        appleCollect = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown(up))
        {
            if(!Previous.Movement.Equals(Movement.DOWN))
            {
                movement = Movement.UP;
                rotation = Direction.UP;
            }
        }
        if (Input.GetKeyDown(left))
        {
            if (!Previous.Movement.Equals(Movement.RIGHT))
            {
                movement = Movement.LEFT;
                rotation = Direction.LEFT;
            }  
        }
        if (Input.GetKeyDown(down))
        {
            if (!Previous.Movement.Equals(Movement.UP))
            {
                movement = Movement.DOWN;
                rotation = Direction.DOWN;
            }                
        }
        if (Input.GetKeyDown(right))
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
        if (started)
        {
            if (target.tag == Tags.Apple)
            {
                SoundManager.PlaySound("apple");
                //snake.CreateSegment();
                snake.createCellSignal = true;
                Apple.createApple();
                Destroy(target.gameObject);
            }
            //K�gy� hozz��r mag�hoz
            if (target.tag == Tags.Snake)
            {
                snake.Die();
                SoundManager.PlaySound("gameOver");
            }
            //K�gy� hozz��r a falhoz
            if (target.tag == Tags.Wall)
            {
                snake.Die();
                SoundManager.PlaySound("gameOver");
            }
        }
        
    }
}
