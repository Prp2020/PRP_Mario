using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInZone : MonoBehaviour
{
    private GameObject leftzone;
    private GameObject rdblock;
    private GameObject saveButton;
    private bool isCounted = false;
    //the position is recorded referring the start block
    private GameObject referenceblock;
<<<<<<< Updated upstream
    public bool isinzone=false;
=======
    public bool isinzone = false;
>>>>>>> Stashed changes
    private bool isthissaved = false;
    // Start is called before the first frame update
    void Start()
    {
        leftzone = GameObject.Find("leftzone");
        rdblock = GameObject.Find("remain_Data");
        referenceblock = GameObject.Find("Start_Block");
        saveButton = GameObject.Find("ButtonSave");
    }

    // Update is called once per frame
    void Update()
    {
        isInZone();
        if (isinzone)
        {
            if (!isCounted)
            {
                isCounted = true;
                rdblock.GetComponent<remainData>().actualnum++;
<<<<<<< Updated upstream
            }
        }
        else
        {
            if (isCounted)
            {
                isCounted = false;
                rdblock.GetComponent<remainData>().actualnum--;
            }
        }
        //if the object is in left zone, save the data
        if (!isthissaved)
        {
            if (saveButton.GetComponent<Save>().saveAll == 1)
            {
                saveThis();
            }
        }
        else
        {
            if (saveButton.GetComponent<Save>().saveAll == 0)
            {
                isthissaved = false;
            }
            if (saveButton.GetComponent<Save>().saveAll == 2)
            {
                isthissaved = true;
=======
>>>>>>> Stashed changes
            }
        }
        else
        {
            if (isCounted)
            {
                isCounted = false;
                rdblock.GetComponent<remainData>().actualnum--;
            }
        }
        //if the object is in left zone, save the data
        if (!isthissaved)
        {
            if (saveButton.GetComponent<Save>().saveAll == 1)
            {
                saveThis();
            }
        }
        else
        {
            if (saveButton.GetComponent<Save>().saveAll == 0)
            {
                isthissaved = false;
            }
            if (saveButton.GetComponent<Save>().saveAll == 2)
            {
                isthissaved = true;
            }
        }

    }

    private void OnDestroy()
    {
        if (isinzone)
        {
            rdblock.GetComponent<remainData>().actualnum--;
        }
    }

    //to judge whether the object is in the left zone
    public void isInZone()
    {
        if ((Mathf.Abs(this.transform.position.x - leftzone.transform.position.x) < leftzone.GetComponent<left_zone>().l / 2) && (Mathf.Abs(this.transform.position.y - leftzone.transform.position.y) < leftzone.GetComponent<left_zone>().w / 2))
        {
            isinzone = true;
        }
<<<<<<< Updated upstream
        else 
        { 
            isinzone = false; 
=======
        else
        {
            isinzone = false;
>>>>>>> Stashed changes
        }
    }

    //to save the information of this object
    private void saveThis()
    {
        if (isinzone)
        {
            rdblock.GetComponent<remainData>().go_inleftzone[rdblock.GetComponent<remainData>().num_inleftzone] = nameCorrection(this.transform.name);
            rdblock.GetComponent<remainData>().gopos_inleftzone[rdblock.GetComponent<remainData>().num_inleftzone] = this.transform.position - referenceblock.transform.position;
            rdblock.GetComponent<remainData>().num_inleftzone++;
        }
        isthissaved = true;
    }

    //to fix bugs which is caused by names with one or more (clone)
    private string nameCorrection(string name1)
    {
        string name2 = name1;
        if (name1.Contains("Jump")) { name2 = "Jump_Block"; }
        if (name1.Contains("Assignment_Block")) { name2 = "Assignment_Block"; }
        if (name1.Contains("GetDir_Block")) { name2 = "GetDir_Block"; }
        if (name1.Contains("Up_Block")) { name2 = "Up_Block"; }
        if (name1.Contains("Left_Block")) { name2 = "Left_Block"; }
        if (name1.Contains("Right_Block")) { name2 = "Right_Block"; }
        if (name1.Contains("Down_Block")) { name2 = "Down_Block"; }
        if (name1.Contains("If_Block")) { name2 = "If_Block"; }
        if (name1.Contains("End_Block")) { name2 = "End_Block"; }
        if (name1.Contains("Else_Block")) { name2 = "Else_Block"; }
        if (name1.Contains("Equal_Block")) { name2 = "Equal_Block"; }
        if (name1.Contains("GT_Block")) { name2 = "GT_Block"; }
        if (name1.Contains("LT_Block")) { name2 = "LT_Block"; }
        if (name1.Contains("VarA_Block")) { name2 = "VarA_Block"; }
        if (name1.Contains("Num1_Block")) { name2 = "Num1_Block"; }
        if (name1.Contains("Num2_Block")) { name2 = "Num2_Block"; }
        return name2;
    }

}
