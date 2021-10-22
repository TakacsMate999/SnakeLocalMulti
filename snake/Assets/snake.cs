using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snake : MonoBehaviour
{
    // Start is called before the first frame update

    public static snake Instance;

    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    public void Update()
    {
        
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
