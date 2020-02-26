using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class right_zone : MonoBehaviour
{
    public float l;
    public float w;
    // Start is called before the first frame update
    void Start()
    {
        //get the length and width of the current object
        l = this.GetComponent<Collider>().bounds.size.x;
        w = this.GetComponent<Collider>().bounds.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
