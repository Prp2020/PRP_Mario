using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Right_suck : Mario
{
    public bool Enter;
    public GameObject Target;
    Vector3 Pos;
    Global GLOBAL;
    //Is_suck is true if the object sucks another object
    public bool Is_suck;
    public override void Start()
    {
        Enter = Is_suck = false;
        GLOBAL = (Global)GameObject.Find("Block").GetComponent<Global>();
    }

    public override void Update()
    {
        if (Target == null)
        {
            return;
        }
        
        if (Target.CompareTag("direction"))//如果目标是方向，包括具体的方向和方向变量
        {
            //如果这是赋值下的右
            //那么继续
            if (this.transform.name == "right" && this.transform.parent.name.Substring(0, 6) == "Assign") {
                //keep going
            }
            //如果这是赋值下的左，且目标是方向变量
            //那么继续，否则不吸附
            else if (this.transform.name == "Left" && this.transform.parent.name.Substring(0, 6) == "Assign" && Target.transform.name.Substring(0, 4) == "VarB")
            {
                //keep going
            }
            else return;
        }

        if (this.transform.name == "Left" && Target.name.Substring(0, 3) != "Var") return;

        //如果这是num下的
        //如果目标不是signs
        //那么不吸附
        if (this.transform.parent.CompareTag("num"))
        {
            if (!Target.CompareTag("signs"))
            {
                return;
            }
        }

        //如果这是tag为Block的物体之下的，
        //如果目标也是Block或者目标是signs
        //那么不吸附
        if (this.transform.parent.CompareTag("Block"))
        {
            if (Target.CompareTag("Block") || Target.CompareTag("signs"))
            {
                return;
            }
        }

        if (this.transform.parent.CompareTag("signs"))
        {
            if (!Target.CompareTag("num"))
            {
                return;
            }
        }

        //鼠标点到这个物体时还原parent
        if (GLOBAL.Isclick && Target == GLOBAL.Target && Is_suck)
        {
            Target.transform.SetParent(GLOBAL.gameObject.transform);
            Is_suck = false;
        }
        //松开鼠标，吸附并设置parent
        if (!GLOBAL.Isclick && Target.transform.parent != this.transform.parent && Is_suck == false)
        {
            Target.transform.position = this.transform.position;
            Target.transform.SetParent(this.transform.parent);
            Is_suck = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Target == null)
        {
            Enter = true;
            Target = collision.gameObject;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject == Target)
        {
            Enter = false;
            Target = null;
            collision.transform.SetParent(GLOBAL.gameObject.transform);
        }
    }
}

