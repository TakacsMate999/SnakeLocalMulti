using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 speed = new Vector3(0, 0, 0);
    Vector3 rotation = new Vector3(-90, 0, 0);
    int time = 0;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            speed = new Vector3(0, 0.3f, 0);
            rotation = new Vector3(-90, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            speed = new Vector3(-0.3f, 0, 0);
            rotation = new Vector3(0, -90, 90);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            speed = new Vector3(0, -0.3f, 0);
            rotation = new Vector3(90, 90, -90);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            speed = new Vector3(0.3f, 0, 0);
            rotation = new Vector3(0, 90, -90);
        }
        time++;
        if(time % 30 == 0)
        {
            gameObject.transform.position = new Vector3(
                gameObject.transform.position.x + speed.x,
                gameObject.transform.position.y + speed.y,
                gameObject.transform.position.z + speed.z
                ) ;
            gameObject.transform.eulerAngles = rotation;
        }
    }
}
