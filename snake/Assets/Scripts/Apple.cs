using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public GameObject apple_prefab;
    public Transform parent;


    void Start()
    {
        parent = gameObject.transform.parent;
    }

    // Start is called before the first frame update
    public void createApple()
    {
        //nem vagyok biztos abba hogy ez �gy j�
        float x = Random.Range(0, 12);
        //x felvehet� �rt�kek -8.49 <-> 5.49
        x -= 8.49f;

        //y felvehet� �rt�kek -6 <-> 7
        float y = Random.Range(-6, 7);

        Vector3 position = new Vector3(x, y, 0);

        GameObject app = Instantiate(apple_prefab, position, Quaternion.identity, parent);
        app.name = "apple";
    }
}
