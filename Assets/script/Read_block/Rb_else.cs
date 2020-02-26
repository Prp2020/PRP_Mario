using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rb_else : Block
{
    public override Block Read_block()
    {
        return Return_Next();
    }
}
