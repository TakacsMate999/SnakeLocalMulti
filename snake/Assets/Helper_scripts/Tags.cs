using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tags
{
    public static string Apple = "Apple";
    public static string Snake = "Snake";
    public static string Wall = "Wall";
}

public class Movement
{
    public static Vector3Int UP = new Vector3Int(0, 1, 0);
    public static Vector3Int DOWN = new Vector3Int(0, -1, 0);
    public static Vector3Int LEFT = new Vector3Int(-1, 0, 0);
    public static Vector3Int RIGHT = new Vector3Int(1, 0, 0);
    public static Vector3Int STOP = new Vector3Int(0, 0, 0);
}

public class Direction
{
    public static Vector3Int UP = new Vector3Int(-90, 0, 0);
    public static Vector3Int RIGHT = new Vector3Int(180, -90, 90);
    public static Vector3Int DOWN = new Vector3Int(90, 90, -90);
    public static Vector3Int LEFT = new Vector3Int(180, 90, -90);

}
