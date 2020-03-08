using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class left_zone : Mario
{
    public float mouseScrollspeed = 1f;
    public float l;
    public float w;
    // Start is called before the first frame update
    public override void Start()
    {
        //get the length and width of the current object
        l = this.GetComponent<BoxCollider2D>().bounds.size.x;
        w = this.GetComponent<BoxCollider2D>().bounds.size.y;
    }

    // Update is called once per frame
    public override void Update()
    {
        //move the current object according to the mousescroll 
        if (Input.mouseScrollDelta.y < 0)
        {
            this.transform.position -= new Vector3(0, 0.5f, 0) * mouseScrollspeed;
        }
        if (Input.mouseScrollDelta.y > 0)
        {
            this.transform.position += new Vector3(0, 0.5f, 0) * mouseScrollspeed;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        int Count_ = collision.transform.childCount;
        for (int i = 0; i < Count_; ++i)
        {
            if (collision.transform.GetChild(i).GetComponent<BoxCollider2D>() == null)
                continue;
            collision.transform.GetChild(i).GetComponent<BoxCollider2D>().enabled = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        int Count_ = collision.transform.childCount;
        for (int i = 0; i < Count_; ++i)
        {
            try
            {
                collision.transform.GetChild(i);
            }
            catch(System.Exception)
            {
                continue;
            }
            if (collision.transform.GetChild(i).GetComponent<BoxCollider2D>() == null)
                continue;
            collision.transform.GetChild(i).GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
