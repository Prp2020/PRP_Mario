using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class remainData : MonoBehaviour
{
    public string[] go_inleftzone;
    public Vector3[] gopos_inleftzone;
    public int num_inleftzone=0;
    // Start is called before the first frame update
    void Start()
    {
        gopos_inleftzone = new Vector3[100];
        go_inleftzone = new string[100];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            gopos_inleftzone = new Vector3[100];
            go_inleftzone = new string[100];
            num_inleftzone = 0;
        }
    }

   
}
