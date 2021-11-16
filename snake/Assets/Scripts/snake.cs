using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets;

//Ez kezeli jelenleg a k�gy� mozg�s�t. Elt�rolja a jelenlegi sejteket �s minden 100. update h�v�sra l�pteti �ket
public class Snake : MonoBehaviour
{
    public GameObject headPrefab;
    public GameObject tailPrefab;

    //A test sejtj�nek a prefabja. Ennek a seg�ts�g�vel tudunk �jat l�trehozni.
    //nem biztos, hogy kell
    public GameObject segmentPrefab;

    Head head;
    Tail tail;
    GameObject headObject;
    GameObject tailObject;

    public bool createCellSignal = false;


    //Kezd� sejt sz�m
    public static int startingSegmentCount;

    //Aktu�lis sejt sz�m. Jelenleg csak updatelem, de nem haszn�lom. Majd a pontsz�m�t�sn�l lesz r� sz�ks�g.
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

    //�j sejtet csin�lunk �s betessz�k az utols� testsejt ut�n, de a farok el�.
    //Majd az elk�sz�lt sejtet betessz�k a k�gy�ba is(A snake list-j�be).
    public void CreateSegment()
    {
        //Kivonom a curr �rt�ket, mert az lesz majd az elmozdul�sa k�vi �llapotban
        //Cs�nya �s m�shogy k�ne megcsin�lni, de most semmi m�s nem jut eszembe hirtelen.
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
        foreach(Cell cell in cells)
        {
            Destroy(cell.gameObject);
        }

        Destroy(gameObject);
    }
}
