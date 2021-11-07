using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementData
{
    public MovementData() { }

    public MovementData(Vector3Int movement, Vector3Int rotation)
    {
        this.Movement = movement;
        this.Rotation = rotation;
    }

    public Vector3Int Movement { get; set; }
    public Vector3Int Rotation { get; set; }
}
