using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public static GameObject apple_prefab;

    private static int xSize = 14;
    private static int ySize = 14;

    public static void Initialize(int x, int y, GameObject prefab)
    {
        xSize = x;
        ySize = y;
        apple_prefab = prefab;
    }

    public Apple() { }


    void Start()
    {
    }

    public static void createApple()
    {
        float x = Random.Range(0, xSize);
        x -= 8.48f;

        float y = Random.Range(0, ySize);
        y -= 6f;

        Vector3 position = new Vector3(x, y, 0);

        GameObject app = Instantiate(apple_prefab, position, Quaternion.identity);
        app.name = "apple";
    }
}
