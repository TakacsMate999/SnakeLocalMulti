using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets;

public class Body_Cell : Cell
{

    public Cell Source;

    // Update is called once per frame
    override
    public void Move()
    {
        Previous = Current;
        Current = new MovementData(Source.Previous.Movement, Source.Previous.Rotation);
        base.Move();
    }
}
