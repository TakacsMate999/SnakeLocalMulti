using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets;

//Ez kezeli jelenleg a kígyó mozgását. Eltárolja a jelenlegi sejteket és minden 100. update hívásra lépteti õket
public class snake : MonoBehaviour
{
    // Start is called before the first frame update

    public static snake Instance;

    int time = 0;

    List<Body_Cell> cells = new List<Body_Cell>();

    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    public void Update()
    {
        time++;
        if(time % 100 == 0)
        {
            //Fontos, hogy fej, test sejtek, farok sorrendben történjen a hívás.
            Head.Instance.Move();
            foreach (Body_Cell cell in cells)
            {
                cell.Move();
            }
            Tail.Instance.Move();
        }
        
    }

    public void addCell(Body_Cell cell)
    {
        cells.Add(cell);
    }
}

//Ebben lehet eltárolni egy lépés adatait
//Movement: Merre mozgott a sejt
//Rotation: Milyen irányba fordult a sejt
public class MovementData
{
    public MovementData() { }

    public MovementData(Vector3Int first, Vector3Int second)
    {
        this.Movement = first;
        this.Rotation = second;
    }

    public Vector3Int Movement { get; set; }
    public Vector3Int Rotation { get; set; }
}
