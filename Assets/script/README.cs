using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 THIS FILE IS FOR INVARIANTS MAINTENANCE
 Last Modified: 2019/12/14/15:05

Block.cs:
    REQUIRE: the Down block is the first child of the current block

Rb_if.cs:
    the child "right" is the second child of IF
    the child "right" is the first child of Num1, Num2 and sign blocks (equal, greater than or less than)
    the child "dest" is the second child of GetDir

Rb_jump.cs:
    the child "dest" is the second child of the jump block
 */
public class README : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
