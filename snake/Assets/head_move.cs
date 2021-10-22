using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class head_move : MonoBehaviour
{

    public Vector3 speed = new Vector3(0, 0, 0);
    public Vector3 rotation = new Vector3(-90, 0, 0);

    public snake.MovementData Curr;
    public snake.MovementData Prev;
    public static head_move Instance;

    int time = 0;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        Curr = new snake.MovementData(speed, rotation);
        Prev = Curr;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            speed = new Vector3(0, 1, 0);
            rotation = new Vector3(-90, 0, 0);
            //Debug.Log(speed.x + " " + speed.y + " " + speed.z);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            speed = new Vector3(-1, 0, 0);
            rotation = new Vector3(0, -90, 90);
            //Debug.Log(speed.x + " " + speed.y + " " + speed.z);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            speed = new Vector3(0, -1, 0);
            rotation = new Vector3(90, 90, -90);
            //Debug.Log(speed.x + " " + speed.y + " " + speed.z);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            speed = new Vector3(1, 0, 0);
            rotation = new Vector3(0, 90, -90);
            //Debug.Log(speed.x + " " + speed.y + " " + speed.z);
        }

        time++;
        if (time % 100 == 0)
        {
            Prev = Curr;
            Curr = new snake.MovementData(speed, rotation);
            gameObject.transform.position = new Vector3(
                gameObject.transform.position.x + speed.x,
                gameObject.transform.position.y + speed.y,
                gameObject.transform.position.z + speed.z
                );
            gameObject.transform.eulerAngles = rotation;
        }
    }
}
