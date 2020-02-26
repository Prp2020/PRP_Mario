using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_Clone : Block
{
    // Start is called before the first frame update
    public override void Start()
    {
        Pos = this.transform.position;
        Parent = this.transform.parent;
        Used = false;
    }

    // Update is called once per frame
    public override void Update()
    {
        Clone();
    }
}
