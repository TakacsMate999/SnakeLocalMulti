using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using _snake;

public class Body_move : Move
{

    public Move Source;

    int time = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Setup(Move source)
    {
        Source = source;
    }

    // Update is called once per frame
    override
    protected void Update()
    {
        time++;
        if (time % 100 == 0)
        {
            Prev = Curr;
            Curr = new MovementData(Source.Prev.Position, Source.Prev.Rotation);
            base.Update();
        }
    }
}
