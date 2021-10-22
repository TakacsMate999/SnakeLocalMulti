using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class body_move : MonoBehaviour
{
    public Vector3 Position = new Vector3(0, 0, 0);
    public Vector3 Rotation = new Vector3(-90, 0, 0);

    int time = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time++;
        if (time % 100 == 0)
        {
            Position = head_move.Instance.Curr.Position;
            Rotation = head_move.Instance.Curr.Rotation;
            gameObject.transform.position = new Vector3(
                gameObject.transform.position.x + Position.x,
                gameObject.transform.position.y + Position.y,
                gameObject.transform.position.z + Position.z
                );
            gameObject.transform.eulerAngles = Rotation;
        }
    }
}
