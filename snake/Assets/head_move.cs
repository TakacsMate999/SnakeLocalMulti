using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using _snake;

public class Head_move : Move
{
    public Vector3 speed = new Vector3(0, 0, 0);
    public Vector3 rotation = new Vector3(-90, 0, 0);

    public static Head_move Instance;

    public GameObject segmentPrefab;
    public int segmentCount;

    int time = 0;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        Curr = new MovementData(speed, rotation);
        Prev = Curr;
        Body_move[] components = new Body_move[segmentCount];
        GameObject seg = Instantiate(segmentPrefab, 
            new Vector3(gameObject.transform.position.x,
            gameObject.transform.position.y,
            gameObject.transform.position.z), Quaternion.identity);
        seg.name = "Body 0";
        Body_move comp = seg.AddComponent<Body_move>();
        comp.Setup(this);
        components[0] = comp;
        for(int i = 1; i < segmentCount; i++)
        {
            seg = Instantiate(segmentPrefab,
            new Vector3(gameObject.transform.position.x,
            gameObject.transform.position.y,
            gameObject.transform.position.z), Quaternion.identity);
            seg.name = "Body " + i.ToString();
            comp = seg.AddComponent<Body_move>();
            comp.Setup(components[i - 1]);
            components[i] = comp;
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
