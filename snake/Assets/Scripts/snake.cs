using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets;
using UnityEngine.SceneManagement;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;
using System.Threading;

//Ez kezeli jelenleg a k?gy? mozg?s?t. Elt?rolja a jelenlegi sejteket ?s minden 100. update h?v?sra l?pteti ?ket
public class Snake : MonoBehaviour
{
    public GameObject headPrefab;
    public GameObject tailPrefab;

    //A test sejtj?nek a prefabja. Ennek a seg?ts?g?vel tudunk ?jat l?trehozni.
    //nem biztos, hogy kell
    public GameObject segmentPrefab;
    public static GameHandler gameHandler;

    public int score;

    Head head;
    Tail tail;
    GameObject headObject;
    GameObject tailObject;

    public bool createCellSignal = false;

    public bool isAlive = true;


    //Kezd? sejt sz?m
    public static int startingSegmentCount;

    //Aktu?lis sejt sz?m. Jelenleg csak updatelem, de nem haszn?lom. Majd a pontsz?m?t?sn?l lesz r? sz?ks?g.
    public int segmentCount = 0;

    public static float speed = 0.2f;

    List<Body_Cell> cells = new List<Body_Cell>();

    Cell lastSegment;

    public void SetControllKeys(string up, string left, string down, string right)
    {
        head.setControllKeys(up, left, down, right);
    }

    void Start()
    {
        for(int i = 0; i < startingSegmentCount; i++)
        {
            CreateSegment();
        }
        score = 0;
        InvokeRepeating("MoveCells", 0, speed);
    }

    public static Snake CreateSnake(GameHandler g, int x, int y, GameObject snakePrefab)
    {
        Vector3Int headPos = new Vector3Int(x, y, -1);
        Vector3Int tailPos = new Vector3Int(x, y, 0);
        Snake s = Instantiate(snakePrefab).GetComponent<Snake>();
        s.CreateHeadTail(headPos, tailPos);
        gameHandler = g;

        return s;
    }

    public void CreateHeadTail(Vector3Int hpos, Vector3Int tpos)
    {
        headObject = Instantiate(headPrefab, hpos + gameObject.transform.position, Quaternion.Euler(new Vector3(-90, 0 ,0)), gameObject.transform);
        head = headObject.GetComponent<Head>();
        head.snake = this;
        lastSegment = head;
        tailObject = Instantiate(tailPrefab, tpos + gameObject.transform.position, Quaternion.Euler(new Vector3(-90, 0, 0)), gameObject.transform);
        tail = tailObject.GetComponent<Tail>();
        tail.Source = lastSegment;
    }

    //?j sejtet csin?lunk ?s betessz?k az utols? testsejt ut?n, de a farok el?.
    //Majd az elk?sz?lt sejtet betessz?k a k?gy?ba is(A snake list-j?be).
    public void CreateSegment()
    {
        //Kivonom a curr ?rt?ket, mert az lesz majd az elmozdul?sa k?vi ?llapotban
        //Cs?nya ?s m?shogy k?ne megcsin?lni, de most semmi m?s nem jut eszembe hirtelen.
        GameObject seg = Instantiate(segmentPrefab,
            lastSegment.transform.position - lastSegment.Current.Movement, lastSegment.transform.rotation, gameObject.transform);
        seg.name = "Body " + (++segmentCount).ToString();
        Body_Cell cell = seg.GetComponent<Body_Cell>();
        cell.Source = lastSegment;
        cell.Current = new MovementData(Movement.STOP, lastSegment.Current.Rotation);
        cell.Previous = lastSegment.Previous;
        seg.transform.parent = gameObject.transform;
        AddCell(cell);
        lastSegment = cell;
        tail.Source = lastSegment;      
    }

    // Update is called once per frame
    public void MoveCells()
    {
        if (createCellSignal)
        {
            CreateSegment();
            createCellSignal = false;
        }
        //Fontos, hogy fej, test sejtek, farok sorrendben t?rt?njen a h?v?s.
        head.Move();
        foreach (Body_Cell cell in cells)
        {
            cell.Move();
        }
        tail.Move();
        
    }

    public void AddCell(Body_Cell cell)
    {
        cells.Add(cell);
        gameHandler.AddScore(this);
    }

    public void Die()
    {
        if (isAlive)
        {
            isAlive = false;
            EndGame.winner = (2 - GameHandler.getSnakeIdx(this));
            gameHandler.EndTheGame();
            //head.DestroyGameObject();
            //foreach (Cell c in cells)
            //{
            //    c.DestroyGameObject();
            //}
            //tail.DestroyGameObject();
            print("Rip in peace");
            foreach (Cell cell in cells)
            {
                Destroy(cell.gameObject);
            }
            Destroy(gameObject);
            Destroy(this);
        }        
    }

}
