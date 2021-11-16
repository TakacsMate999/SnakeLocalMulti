using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets;

//Ez kezeli jelenleg a kígyó mozgását. Eltárolja a jelenlegi sejteket és minden 100. update hívásra lépteti õket
public class Snake : MonoBehaviour
{
    public GameObject headPrefab;
    public GameObject tailPrefab;

    //A test sejtjének a prefabja. Ennek a segítségével tudunk újat létrehozni.
    //nem biztos, hogy kell
    public GameObject segmentPrefab;

    Head head;
    Tail tail;
    GameObject headObject;
    GameObject tailObject;

    public bool createCellSignal = false;


    //Kezdõ sejt szám
    public static int startingSegmentCount;

    //Aktuális sejt szám. Jelenleg csak updatelem, de nem használom. Majd a pontszámításnál lesz rá szükség.
    public static int segmentCount = 0;

    public static int speed = 70;
    int time = 0;

    List<Body_Cell> cells = new List<Body_Cell>();

    Cell lastSegment;

    public void setControllKeys(string up, string left, string down, string right)
    {
        head.setControllKeys(up, left, down, right);
    }

    void Start()
    {
        for(int i = 0; i < startingSegmentCount; i++)
        {
            CreateSegment();
        }
    }

    public static Snake CreateSnake(int x, int y, GameObject snakePrefab)
    {
        Vector3Int headPos = new Vector3Int(x, y, -1);
        Vector3Int tailPos = new Vector3Int(x, y, 0);
        Snake s = Instantiate(snakePrefab).GetComponent<Snake>();
        s.createHeadTail(headPos, tailPos);

        return s;
    }

    public void createHeadTail(Vector3Int hpos, Vector3Int tpos)
    {
        headObject = Instantiate(headPrefab, hpos + gameObject.transform.position, Quaternion.Euler(new Vector3(-90, 0 ,0)), gameObject.transform);
        head = headObject.GetComponent<Head>();
        head.snake = this;
        lastSegment = head;
        tailObject = Instantiate(tailPrefab, tpos + gameObject.transform.position, Quaternion.Euler(new Vector3(-90, 0, 0)), gameObject.transform);
        tail = tailObject.GetComponent<Tail>();
        tail.Source = lastSegment;
    }

    //Új sejtet csinálunk és betesszük az utolsó testsejt után, de a farok elé.
    //Majd az elkészült sejtet betesszük a kígyóba is(A snake list-jébe).
    public void CreateSegment()
    {
        //Kivonom a curr értéket, mert az lesz majd az elmozdulása kövi állapotban
        //Csúnya és máshogy kéne megcsinálni, de most semmi más nem jut eszembe hirtelen.
        GameObject seg = Instantiate(segmentPrefab,
            lastSegment.transform.position - lastSegment.Current.Movement, lastSegment.transform.rotation, gameObject.transform);
        seg.name = "Body " + (++segmentCount).ToString();
        Body_Cell cell = seg.GetComponent<Body_Cell>();
        cell.Source = lastSegment;
        cell.Current = new MovementData(Movement.STOP, lastSegment.Current.Rotation);
        cell.Previous = lastSegment.Previous;
        seg.transform.parent = gameObject.transform;
        addCell(cell);
        lastSegment = cell;
        tail.Source = lastSegment;
    }

    // Update is called once per frame
    public void Update()
    {
        time++;
        if(time % speed == 0)
        {
            if (createCellSignal)
            {
                CreateSegment();
                createCellSignal = false;
            }
            //Fontos, hogy fej, test sejtek, farok sorrendben történjen a hívás.
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
        foreach(Cell cell in cells)
        {
            Destroy(cell.gameObject);
        }

        Destroy(gameObject);
    }
}
