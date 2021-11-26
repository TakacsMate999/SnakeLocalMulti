using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public static GameObject apple_prefab;

    public static GameObject particle;
    static GameObject currentParticle;

    public static int counter;

    public static int appleCount = 0;

    private static int xSize = 14;
    private static int ySize = 14;

    public static void Initialize(int x, int y, GameObject prefab, GameObject _particle)
    {
        counter = 0;
        xSize = x;
        ySize = y;
        apple_prefab = prefab;
        particle = _particle;
    }

    public static void CreateApple()
    {
        if(appleCount <= 1)
        {
            float x = Random.Range(0, xSize);
            x -= 8.48f;

            float y = Random.Range(0, ySize);
            y -= 6f;

            Vector3 position = new Vector3(x, y, 0);

            GameObject app = Instantiate(apple_prefab, position, Quaternion.identity);
            app.name = "apple";
            if (counter != 0 && position != null)
            {
                CreateParticle(position);
            }
            appleCount++;
            counter++;
        }
    }

    
    // Start is called before the first frame update
    public static void CreateParticle(Vector3 v)
    {
        if(currentParticle != null)
        {
            Destroy(currentParticle);
        }
        currentParticle = Instantiate(particle, v, particle.transform.rotation);
    }
}
