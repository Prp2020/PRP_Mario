using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_Clone : Block
{
    //to avoid that the new built object can be cloned
    public bool isbuilt = false;
    // Start is called before the first frame update
    public override void Start()
    {
        Pos = this.transform.position;
        Parent = this.transform.parent;
        //if the object is built, when starting, "Used" will not be set to false
        if (!isbuilt) { Used = false; }
    }

    // Update is called once per frame
    public override void Update()
    {
        Clone();
    }
}
