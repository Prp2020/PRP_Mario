using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class right_zone : MonoBehaviour
{
    public float l;
    public float w;
    public GameObject Target;
    // Start is called before the first frame update
    void Start()
    {
        //get the length and width of the current object
        l = this.GetComponent<BoxCollider2D>().bounds.size.x;
        w = this.GetComponent<BoxCollider2D>().bounds.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision!=null)
        {
            Target = collision.gameObject;
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
