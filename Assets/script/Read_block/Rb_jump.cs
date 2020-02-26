using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//REQUIRE: the child dest is the second child of the jump block
public class Rb_jump : Block
{
    public override Block Read_block()
    {
        GameObject Dest = this.transform.GetChild(1).GetComponent<Dest_Suck>().Target;
        string name = Dest.transform.name;
        Data WriteData = (Data)GameObject.Find("DATA").GetComponent("Data");
        switch (name[0])
        {
            case 'U':
                WriteData.WritePosition(2);
                break;
            case 'D':
                WriteData.WritePosition(4);
                break;
            case 'L':
                WriteData.WritePosition(1);
                break;
            case 'R':
                WriteData.WritePosition(3);
                break;
        }
        return Return_Next();
    }
}
