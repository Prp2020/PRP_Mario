using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rb_assign : Block
{
    //REQUIRE: right block is the second child, left block is the third child
    public override Block Read_block()
    {
        GameObject RightB = this.transform.GetChild(1).GetComponent<Right_suck>().Target;
        GameObject LeftB = this.transform.GetChild(2).GetComponent<Right_suck>().Target;
        int Datum = Compute_lr_value(RightB);
        Transform[] Glo;
        Glo = GameObject.Find("Block").transform.GetComponentsInChildren<Transform>();
        foreach(Transform t in Glo)
        {
            if(t.name.Substring(0,4) == LeftB.name.Substring(0,4))
            {
                t.GetComponent<VarData>().Var = Compute_lr_value(RightB);
            }
        }
        return Return_Next();
    }
}
