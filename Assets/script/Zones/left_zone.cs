using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class left_zone : MonoBehaviour
{
    public float mouseScrollspeed = 1f;
    public float l;
    public float w;
    private GameObject remainData;
    private GameObject referenceblock;

    //to store the position and name of gameobjects in the left zone
    public string[] go_inleftzone;
    public Vector3[] gopos_inleftzone;
    public int num_inleftzone;

    // Start is called before the first frame update
    void Start()
    {
        referenceblock = GameObject.Find("Start_Block");
        remainData = GameObject.Find("remain_Data");
        gopos_inleftzone = new Vector3[100];
        go_inleftzone = new string[100];

        //copy data in remainData
        num_inleftzone = remainData.GetComponent<remainData>().num_inleftzone;
        gopos_inleftzone = remainData.GetComponent<remainData>().gopos_inleftzone;
        go_inleftzone = remainData.GetComponent<remainData>().go_inleftzone;

        //get the length and width of the current object
        l = this.GetComponent<Collider>().bounds.size.x;
        w = this.GetComponent<Collider>().bounds.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        //move the current object according to the mousescroll 
        if (Input.mouseScrollDelta.y < 0)
        {
            this.transform.position -= new Vector3(0, 0.5f, 0) * mouseScrollspeed;
        }
        if (Input.mouseScrollDelta.y > 0)
        {
            this.transform.position += new Vector3(0, 0.5f, 0) * mouseScrollspeed;
        }

<<<<<<< Updated upstream
        
        
=======


>>>>>>> Stashed changes
    }
    //generate object from data in remainData in leftzone
    public void reBuild()
    {
        if (num_inleftzone != 0)
        {
            for (int i = 0; i < num_inleftzone; i++)
            {
                GameObject newBlock = Instantiate(GameObject.Find(go_inleftzone[i]), gopos_inleftzone[i] + referenceblock.transform.position, this.transform.rotation);
                newBlock.GetComponent<Block_Clone>().isbuilt = true;
                newBlock.GetComponent<Block_Clone>().Used = true;
            }
        }
    }
}
