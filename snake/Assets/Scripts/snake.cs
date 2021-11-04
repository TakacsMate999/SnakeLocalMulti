using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets;

//Ez kezeli jelenleg a k�gy� mozg�s�t. Elt�rolja a jelenlegi sejteket �s minden 100. update h�v�sra l�pteti �ket
public class Snake : MonoBehaviour
{
    public GameObject applePrefab;

    public GameObject headObject;
    public GameObject tailObject;

    Head head;
    Tail tail;

    int time = 0;

    List<Body_Cell> cells = new List<Body_Cell>();

    void Start()
    {
        Apple.Initialize(14, 14, applePrefab);
        Apple.createApple();
    }

    // Update is called once per frame
    public void Update()
    {
        time++;
        if(time % 100 == 0)
        {
            //Fontos, hogy fej, test sejtek, farok sorrendben t�rt�njen a h�v�s.
            head.Move();
            foreach (Body_Cell cell in cells)
            {
                cell.Move();
            }
            tail.Move();
        }
        
    }

    public void addCell(Body_Cell cell)
    {
        cells.Add(cell);
    }

    public void Die()
    {
        head.DestroyGameObject();
        foreach(Cell c in cells)
        {
            c.DestroyGameObject();
        }
        tail.DestroyGameObject();
        print("Rip in peace");
        Destroy(this);
    }
}

//Ebben lehet elt�rolni egy l�p�s adatait
//Movement: Merre mozgott a sejt
//Rotation: Milyen ir�nyba fordult a sejt
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
