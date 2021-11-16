using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public static GameObject apple_prefab;
    public static AppleHandler appleHandler;

    public static int counter;

    private static int xSize = 14;
    private static int ySize = 14;

    public static void Initialize(int x, int y, GameObject prefab, AppleHandler a)
    {
        counter = 0;
        xSize = x;
        ySize = y;
        apple_prefab = prefab;
        appleHandler = a;
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
        if (counter != 0&&position!=null)
        {
            appleHandler.createParticle(position);
        }
        counter++;
    }
}
