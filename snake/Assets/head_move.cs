using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using _snake;
using Assets;

public class Head_move : Move
{
    public Vector3 speed = new Vector3(0, 0, 0);
    public Vector3 rotation = new Vector3(-90, 0, 0);

    public Head_move Instance { get; private set; }

    Move lastSegment;
    Tail_move tail;

    public GameObject segmentPrefab;
    public int segmentCount;
    int segment_n = 0;

    int time = 0;

    // Start is called before the first frame update
    void Start()
    {
        lastSegment = this;
        Instance = this;
        tail = Tail_move.Instance;
        Curr = new MovementData(speed, rotation);
        Prev = Curr;
        tail.Source = lastSegment;
        for(int i = 0; i < segmentCount; i++)
        {
            CreateSegment();
        }
    }

    public void CreateSegment()
    {
        GameObject seg = Instantiate(segmentPrefab,
            new Vector3(lastSegment.transform.position.x,
            lastSegment.transform.position.y,
            lastSegment.transform.position.z), Quaternion.identity, this.transform.parent);
        seg.name = "Body " + (++segment_n).ToString();
        Body_move comp = seg.AddComponent<Body_move>();
        comp.Setup(lastSegment);
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
    override
    protected void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if(!speed.Equals(new Vector3(0, -1, 0)))
            {
                speed = new Vector3(0, 1, 0);
                rotation = new Vector3(-90, 0, 0);
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (!speed.Equals(new Vector3(1, 0, 0)))
            {
                speed = new Vector3(-1, 0, 0);
                rotation = new Vector3(0, -90, 90);
            }  
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (!speed.Equals(new Vector3(0, 1, 0)))
            {
                speed = new Vector3(0, -1, 0);
                rotation = new Vector3(90, 90, -90);
            }                
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (!speed.Equals(new Vector3(-1, 0, 0)))
            {
                speed = new Vector3(1, 0, 0);
                rotation = new Vector3(0, 90, -90);
            }                
        }

        time++;
        if (time % 100 == 0)
        {
            Prev = Curr;
            Curr = new MovementData(speed, rotation);
            base.Update();
        }
    }
}
