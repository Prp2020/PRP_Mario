using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirData : Block
{
    public string state;//Store a string represents for direction

    // Start is called before the first frame update
    public override void Start()
    {
        state = null;//0 represents B is NULL
    }
}
