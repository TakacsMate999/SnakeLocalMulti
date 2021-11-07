using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets;

//Ez kezeli jelenleg a k�gy� mozg�s�t. Elt�rolja a jelenlegi sejteket �s minden 100. update h�v�sra l�pteti �ket
public class Snake : MonoBehaviour
{
    public GameObject headObject;
    public GameObject tailObject;

    //A test sejtj�nek a prefabja. Ennek a seg�ts�g�vel tudunk �jat l�trehozni.
    public GameObject segmentPrefab;

    Head head;
    Tail tail;

    //Kezd� sejt sz�m
    public int startingSegmentCount;

    //Aktu�lis sejt sz�m. Jelenleg csak updatelem, de nem haszn�lom. Majd a pontsz�m�t�sn�l lesz r� sz�ks�g.
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

    //�j sejtet csin�lunk �s betessz�k az utols� testsejt ut�n, de a farok el�.
    //Majd az elk�sz�lt sejtet betessz�k a k�gy�ba is(A snake list-j�be).
    public void CreateSegment()
    {
        //Kivonom a curr �rt�ket, mert az lesz majd az elmozdul�sa k�vi �llapotban
        //Cs�nya �s m�shogy k�ne megcsin�lni, de most semmi m�s nem jut eszembe hirtelen.
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
            //Fontos, hogy fej, test sejtek, farok sorrendben t�rt�njen a h�v�s.
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
