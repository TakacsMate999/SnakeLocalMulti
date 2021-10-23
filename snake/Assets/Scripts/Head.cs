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

    public static Head Instance { get; private set; }

    Cell lastSegment;
    Tail tail;

    //A test sejtj�nek a prefabja. Ennek a seg�ts�g�vel tudunk �jat l�trehozni.
    public GameObject segmentPrefab;

    //Kezd� sejt sz�m
    public int startingSegmentCount;

    //Aktu�lis sejt sz�m. Jelenleg csak updatelem, de nem haszn�lom. Majd a pontsz�m�t�sn�l lesz r� sz�ks�g.
    int segmentCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        lastSegment = this;
        Instance = this;
        tail = Tail.Instance;
        Current = new MovementData(movement, rotation);
        Previous = Current;
        tail.Source = lastSegment;
        for(int i = 0; i < startingSegmentCount; i++)
        {
            CreateSegment();
        }
    }

    //�j sejtet csin�lunk �s betessz�k az utols� testsejt ut�n, de a farok el�.
    //Majd az elk�sz�lt sejtet betessz�k a k�gy�ba is(A snake list-j�be).
    public void CreateSegment()
    {
        //Kivonom a curr �rt�ket, mert az lesz majd az elmozdul�sa k�vi �llapotban
        //Cs�nya �s m�shogy k�ne megcsin�lni, de most semmi m�s nem jut eszembe hirtelen.
        GameObject seg = Instantiate(segmentPrefab,
            new Vector3(lastSegment.transform.position.x - lastSegment.Current.Movement.x,
            lastSegment.transform.position.y - lastSegment.Current.Movement.y,
            lastSegment.transform.position.z - lastSegment.Current.Movement.z), Quaternion.identity, this.transform.parent);
        seg.name = "Body " + (++segmentCount).ToString();
        Body_Cell comp = seg.AddComponent<Body_Cell>();
        comp.Source = lastSegment;
        snake.Instance.addCell(comp);
        lastSegment = comp;
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
            if(!movement.Equals(Movement.DOWN))
            {
                movement = Movement.UP;
                rotation = Direction.UP;
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (!movement.Equals(Movement.RIGHT))
            {
                movement = Movement.LEFT;
                rotation = Direction.LEFT;
            }  
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (!movement.Equals(Movement.UP))
            {
                movement = Movement.DOWN;
                rotation = Direction.DOWN;
            }                
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (!movement.Equals(Movement.LEFT))
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
        base.Move();
    }

    private void OnTriggerEnter(Collider target)
    {
        if(target.tag == Tags.Apple)
        {
            CreateSegment();
        }
    }
}
