using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets;

public class snake : MonoBehaviour
{
    // Start is called before the first frame update

    public static snake Instance;

    int time = 0;

    List<Body_move> cells = new List<Body_move>();

    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    public void Update()
    {
        time++;
        if(time % 100 == 0)
        {
            Head_move.Instance.Act();
            foreach (Body_move m in cells)
            {
                m.Act();
            }
            Tail_move.Instance.Act();
        }
        
    }

    public void addCell(Body_move cell)
    {
        cells.Add(cell);
    }
}

public class MovementData
{
    public MovementData() { }

    public MovementData(Vector3 first, Vector3 second)
    {
        this.Position = first;
        this.Rotation = second;
    }

    public Vector3 Position { get; set; }
    public Vector3 Rotation { get; set; }
}
