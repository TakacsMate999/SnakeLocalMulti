using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets;

//Ez kezeli jelenleg a kígyó mozgását. Eltárolja a jelenlegi sejteket és minden 100. update hívásra lépteti õket
public class Snake : MonoBehaviour
{
    public GameObject headObject;
    public GameObject tailObject;

    //A test sejtjének a prefabja. Ennek a segítségével tudunk újat létrehozni.
    public GameObject segmentPrefab;

    Head head;
    Tail tail;

    //Kezdõ sejt szám
    public int startingSegmentCount;

    //Aktuális sejt szám. Jelenleg csak updatelem, de nem használom. Majd a pontszámításnál lesz rá szükség.
    int segmentCount = 0;

    int speed = 70;
    int time = 0;

    List<Body_Cell> cells = new List<Body_Cell>();

    Cell lastSegment;

    void Start()
    {
        head = headObject.GetComponent<Head>();
        head.snake = this;
        tail = tailObject.GetComponent<Tail>();

        lastSegment = head;
        tail.Source = lastSegment;

        for(int i = 0; i < startingSegmentCount; i++)
        {
            CreateSegment();
        }
    }

    //Új sejtet csinálunk és betesszük az utolsó testsejt után, de a farok elé.
    //Majd az elkészült sejtet betesszük a kígyóba is(A snake list-jébe).
    public void CreateSegment()
    {
        //Kivonom a curr értéket, mert az lesz majd az elmozdulása kövi állapotban
        //Csúnya és máshogy kéne megcsinálni, de most semmi más nem jut eszembe hirtelen.
        GameObject seg = Instantiate(segmentPrefab,
            new Vector3(lastSegment.transform.position.x - lastSegment.Current.Movement.x,
            lastSegment.transform.position.y - lastSegment.Current.Movement.y,
            0), Quaternion.identity, this.transform.parent);
        seg.name = "Body " + (++segmentCount).ToString();
        seg.GetComponent<Body_Cell>().Source = lastSegment;
        seg.transform.parent = gameObject.transform;
        addCell(seg.GetComponent<Body_Cell>());
        lastSegment = seg.GetComponent<Body_Cell>();
        tail.Source = lastSegment;
    }

    // Update is called once per frame
    public void Update()
    {
        time++;
        if(time % speed == 0)
        {
            //Fontos, hogy fej, test sejtek, farok sorrendben történjen a hívás.
            head.Move();
            foreach (Body_Cell cell in cells)
            {
                cell.Move();
            }
            tail.Move();
        }
        
    }

    public void reposition(int x, int y)
    {
        if (head is null)
        {
            head = headObject.GetComponent<Head>();
        }       
        Vector3Int mov = new Vector3Int(x, y, head.Current.Movement.z);
        head.Current = new MovementData(mov, head.Current.Rotation);
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
        foreach(Cell cell in cells)
        {
            Destroy(cell.gameObject);
        }

        Destroy(gameObject);
    }
}
