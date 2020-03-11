using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : Mario
{
    protected Vector3 Pos;
    protected Transform Parent;
    public bool Used;
    public void Clone()
    {
        if (!Used&&Distance(this.transform.position, Pos) > 1.0f) {
            Used = true;
            GameObject Clone = Instantiate(this.gameObject, Parent);
            Clone.transform.position = Pos;
            Clone.GetComponent<Block>().Pos = Pos;
        }
    }

    //OVERVIEW: read the block, return the next block, if there's no next block, return the block itself
    public virtual Block Read_block() {
        return this;
    }

    //REQUIRE: the Down block is the first child of the current block
    //MODIFIE: none
    //EFFECT: return the target of the down block, which should be the next block linked to this block. If there is no next block, return the current block.
    protected Block Return_Next()
    {
        GameObject NEXT = this.gameObject.transform.GetChild(0).gameObject.GetComponent<Down_Suck>().Target;
        if (NEXT == null) return this;
        switch (NEXT.name.Substring(0,4))
        {
            case "Jump":
                return NEXT.GetComponent<Rb_jump>();
            case "If_B":
                return NEXT.GetComponent<Rb_if>();
            case "Else":
                return NEXT.GetComponent<Rb_else>();
            case "End_":
                return NEXT.GetComponent<Rb_end>();
            case "Assi":
                return NEXT.GetComponent<Rb_assign>();
            default:
                break;
        }
        return this;
    }

    protected int Compute_lr_value(GameObject Block_in)
    {
        string s = Block_in.name;
        switch (s.Substring(0, 3))
        {
            case "Var":
                return Block_in.GetComponent<VarData>().Var;
            case "Num":
                switch (s.Substring(3, 1))
                {
                    case "1":
                        return 1;
                    case "2":
                        return 2;
                    default:
                        break;
                }
                break;
            case "Get":
                GameObject Dest = Block_in.transform.GetChild(1).GetComponent<Dest_Suck>().Target;
                Data WriteData = (Data)GameObject.Find("DATA").GetComponent("Data");
                string Name = Dest.transform.name;
                if (Name.Substring(0, 4) == "VarB") Name = Dest.GetComponent<DirData>().state;
                switch (Name[0])
                {
                    case 'U':
                        return WriteData.Gold[WriteData.Round_ran][1];
                    case 'D':
                        return WriteData.Gold[WriteData.Round_ran][3];
                    case 'L':
                        return WriteData.Gold[WriteData.Round_ran][0];
                    case 'R':
                        return WriteData.Gold[WriteData.Round_ran][2];
                }
                break;
            default:
                break;
        }
        return -1;
    }
}
