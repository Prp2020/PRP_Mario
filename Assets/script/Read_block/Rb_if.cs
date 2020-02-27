using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//REQUIRE:  the child "right" is the second child of IF
//          the child "down" is the first child of IF
//          the child "right" is the first child of Num1, Num2, GetDir and sign blocks (equal, greater than or less than)
//          the child "dest" is the second child of GetDir
public class Rb_if : Block
{
    private GameObject LeftB, RightB,Way;
    private int Lefti, Righti;
    bool TorF;
    public override Block Read_block()
    {
        //Left block is the right block of IF block
        //Left block is either var, num1 or num2
        LeftB = this.gameObject.transform.GetChild(1).GetComponent<Right_suck>().Target;
        //Way is the sign block, which is the right block of the left block
        //Way block is either =, > or <
        Way = LeftB.transform.GetChild(0).GetComponent<Right_suck>().Target;
        //Right block is the right block of the Way block
        //Right block is either var, num1 or num2
        RightB = Way.transform.GetChild(0).GetComponent<Right_suck>().Target;
        Lefti = Compute_lr_value(LeftB);
        Righti = Compute_lr_value(RightB);
        TorF = Compute_TorF();
        //For now, CURR is the next block
        Block CURR = Return_Next();
        if (TorF)
        {
            //Loop while the current block is not else or end
            //when the loop exits, CURR is an else block or an end block
            while (CURR.gameObject.name.Substring(0,4)!="Else" && CURR.gameObject.name.Substring(0, 4) != "End_")
            {
                DetectIfWithoutEnd(CURR);
                CURR = CURR.Read_block();
            }
            //Loop while the current block is not end
            //skip everything before end
            //when the loop ends, CURR is an end block
            while (CURR.gameObject.name.Substring(0,4) != "End_")
            {
                DetectIfWithoutEnd(CURR);
                CURR = Return_Next_of(CURR);
            }
        }
        else
        {
            //Loop until CURR is an else block or an end block
            //Skip everything
            while (CURR.gameObject.name.Substring(0,4) != "Else" && CURR.gameObject.name.Substring(0, 4) != "End_")
            {
                DetectIfWithoutEnd(CURR);
                CURR = Return_Next_of(CURR);
            }
            //Loop until CURR is an end block
            //do everything
            while (CURR.gameObject.name.Substring(0, 4) != "End_")
            {
                DetectIfWithoutEnd(CURR);
                CURR = CURR.Read_block();
            }
        }
        //return the block after the end block corresponding to this IF block
        return Return_Next_of(CURR) ;
    }
    
    private bool Compute_TorF()
    {
        bool Result = false;
        switch (Way.name.Substring(0, 2))
        {
            case "Eq":
                if (Lefti == Righti) Result = true;
                break;
            case "GT":
                if (Lefti > Righti) Result = true;
                break;
            case "LT":
                if (Lefti < Righti) Result = true;
                break;
            default:
                break;
        }
        return Result;
    }

    private Block Return_Next_of(Block CURR)
    {
        GameObject NEXT = CURR.gameObject.transform.GetChild(0).gameObject.GetComponent<Down_Suck>().Target;
        if (NEXT == null) return this;
        switch (NEXT.name.Substring(0, 4))
        {
            case "Jump":
                return NEXT.GetComponent<Rb_jump>();
            case "If_B":
                return NEXT.GetComponent<Rb_if>();
            case "Else":
                return NEXT.GetComponent<Rb_else>();
            case "End_":
                return NEXT.GetComponent<Rb_end>();
            default:
                break;
        }
        return this;
    }

    //OVERVIEW: if the target of 'down' is null, it means that the program executes to the last line and still find no 'END'.
    //          In such case, we have a exception.
    void DetectIfWithoutEnd(Block CURR)
    {
        if(CURR.gameObject.transform.GetChild(0).gameObject.GetComponent<Down_Suck>().Target == null)
        {
            throw (new IfWithoutEndException());
        }
    }
}
