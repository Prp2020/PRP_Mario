using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class Global : Mario
{
    private int i;
    Transform[] Glo;
    public bool Isclick;
    GameObject []Targetlist;
    public GameObject Target;
    int Count;
    private Vector3 lastMousePosition = Vector3.zero;
    Vector3 Pos_mouse;
    Vector3 This_pos;
    // Start is called before the first frame update
    public override void Start()
    {
        Targetlist = new GameObject[10];
    }

    // Update is called once per frame
    public override void Update()
    {
        This_pos = this.transform.position;
        //IsInside();
        
        Count = 0;
        for (int i = 0; i < 10; ++i)
        {
            Targetlist[i] = null;
        }
        Pos_mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Glo = this.transform.GetComponentsInChildren<Transform>();
        foreach (Transform t in Glo)
        {
            if (Check(t.gameObject))
            {
                if (Count > 10)
                    break;
                Targetlist[Count] = t.gameObject;
                ++Count;
            }
        }
        for (int i = 0; i < Count; ++i)//根据z轴排序
        {
            for (int j = i; j < Count; ++j)
            {
                if (Targetlist[i].transform.position.z > Targetlist[j].transform.position.z)
                {
                    GameObject temp = Targetlist[j];
                    Targetlist[j] = Targetlist[i];
                    Targetlist[i] = temp;
                }
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            Isclick = true;
            Target = Targetlist[0];
        }
        if (Input.GetMouseButtonUp(0))
        {
            Isclick = false;
            Target = null;
            lastMousePosition = Vector3.zero;
        }
        if (Isclick&&Target!=null)
        {
            if (lastMousePosition != Vector3.zero)
            {
                Vector3 offset = Camera.main.ScreenToWorldPoint(Input.mousePosition) - lastMousePosition;
                Target.transform.position += offset;
            }
            lastMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }


    }

    bool Check(GameObject t)//检查pos和鼠标的位置
    {
        if (!(t.transform.CompareTag("Block")||t.transform.CompareTag("direction")||t.transform.CompareTag("num")||t.transform.CompareTag("signs")  ))
            return false;
        float x_ = t.GetComponent<Renderer>().bounds.size.x / 2;
        float y_ = t.GetComponent<Renderer>().bounds.size.y / 2;

        if (t.transform.position.x - Pos_mouse.x <= x_ && t.transform.position.x - Pos_mouse.x >= -x_)
            if (t.transform.position.y - Pos_mouse.y <= y_ && t.transform.position.y - Pos_mouse.y >= -y_)
                return true;
        return false;
    }
    void IsInside()//获取鼠标位置下的物体列表
    {
        GameObject raycaster = GameObject.Find("Main Camera");
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
        pointerEventData.position = Input.mousePosition;
        Physics2DRaycaster pr = raycaster.GetComponent<Physics2DRaycaster>();
        List<RaycastResult> resultlist = new List<RaycastResult>();
        pr.Raycast(pointerEventData, resultlist);
        if(resultlist.Count!=0)
        {
            
            Count = resultlist.Count;
            if (Count > 10)
                Count = 10;
            for (int i=0;i<Count;++i)
            {
                Targetlist[i] = resultlist[i].gameObject;
            }

        }
    }
}
