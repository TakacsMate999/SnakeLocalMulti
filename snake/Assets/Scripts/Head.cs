using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets;

//Singleton class
//Jókérdés, hogy hogy lesz majd pontosan megoldva, amikor több kígyó lesz :D
public class Head : Cell
{
    public Vector3Int movement = Movement.STOP;
    public Vector3Int rotation = Direction.UP;

    bool started = false;

    public static Head Instance { get; private set; }

    Cell lastSegment;
    Tail tail;
    Snake snake;

    public GameObject snakeObject;

    //A test sejtjének a prefabja. Ennek a segítségével tudunk újat létrehozni.
    public GameObject segmentPrefab;

    //Kezdõ sejt szám
    public int startingSegmentCount;

    //Aktuális sejt szám. Jelenleg csak updatelem, de nem használom. Majd a pontszámításnál lesz rá szükség.
    int segmentCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        lastSegment = this;
        snake = snake.GetComponent(typeof(Snake)) as Snake;
        tail = snake.tailObject.GetComponent(typeof(Tail)) as Tail; 
        Current = new MovementData(movement, rotation);
        Previous = Current;
        tail.Source = lastSegment;
        for(int i = 0; i < startingSegmentCount; i++)
        {
            CreateSegment();
        }
    }

    //Új sejtet csinálunk és betesszük az utolsó testsejt után, de a farok elé.
    //Majd az elkészült sejtet betesszük a kígyóba is(A snake list-jébe).
    public void CreateSegment()
    {
        //Kivonom a curr értéket, mert az lesz majd az elmozdulása kövi állapotban
        //Csúnya és máshogy kéne megcsinálni, de most semmi más nem jut eszembe hirtelen.
        GameObject seg = Instantiate(segmentPrefab,
            new Vector3(lastSegment.transform.position.x - lastSegment.Current.Movement.x,
            lastSegment.transform.position.y - lastSegment.Current.Movement.y,
            0), Quaternion.identity, this.transform.parent);
        seg.name = "Body " + (++segmentCount).ToString();
        (seg.GetComponent(typeof(Body_Cell)) as Body_Cell).Source = lastSegment;
        snake.addCell((Body_Cell)seg.GetComponent(typeof(Body_Cell)));
        lastSegment = seg.GetComponent(typeof(Body_Cell)) as Body_Cell;
        tail.Source = lastSegment;
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
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
            CreateSegment();
            Apple.createApple();
            Destroy(target.gameObject);
        }
        //Kígyó hozzáér magához
        if (target.tag == Tags.Snake && started)
        {
            snake.Die();
        }
        //Kígyó hozzáér magához
        if (target.tag == Tags.Wall)
        {
            snake.Die();
        }
    }
}
