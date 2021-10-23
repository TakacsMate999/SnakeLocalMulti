using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets;

public class Body_Cell : Cell
{

    public Cell Source;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    override
    public void Move()
    {
        Previous = Current;
        Current = new MovementData(Source.Previous.Movement, Source.Previous.Rotation);
        base.Move();
    }
}
