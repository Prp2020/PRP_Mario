using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Down_Suck : Mario
{
    public bool Enter;
    public GameObject Target;
    Vector3 Pos;
    Global GLOBAL;
    //Is_suck is true if the object sucks another object
    public bool Is_suck;
    public override void Start()
    {
        Enter = Is_suck =false;
        GLOBAL = (Global)GameObject.Find("Block").GetComponent<Global>();
    }

    public override void Update()
    {
        if (Target == null)
        {
            return;
        }
        //return if target is direction
        if (Target.CompareTag("direction"))
            return;
        //return if target is num
        if (Target.CompareTag("num"))
            return;
        //return if target is signs
        if (Target.CompareTag("signs"))
            return;
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
