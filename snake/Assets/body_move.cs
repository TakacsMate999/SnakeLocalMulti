using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets;

public class Body_move : Move
{

    public Move Source;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    override
    public void Act()
    {
        Prev = Curr;
        Curr = new MovementData(Source.Prev.Position, Source.Prev.Rotation);
        base.Act();
    }
}
