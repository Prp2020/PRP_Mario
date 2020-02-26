using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rb_start : Block
{
    public override Block Read_block()
    {
        return Return_Next();
    }
}
