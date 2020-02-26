using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInZone : MonoBehaviour
{
    private GameObject leftzone;
    private GameObject rightzone;
    private GameObject ALL;
    // Start is called before the first frame update
    void Start()
    {
        leftzone = GameObject.Find("leftzone");
        rightzone = GameObject.Find("rightzone");
        ALL = GameObject.Find("Block");
    }

    // Update is called once per frame
    void Update()
    {
        if((Mathf.Abs(this.transform.position.x-leftzone.transform.position.x)<leftzone.GetComponent<left_zone>().l/2)&& (Mathf.Abs(this.transform.position.y - leftzone.transform.position.y) < leftzone.GetComponent<left_zone>().w / 2))
        {
            this.GetComponent<Collider2D>().enabled = false;
        }
        else
        {
            this.GetComponent<Collider2D>().enabled = true;
        }



        if ((Mathf.Abs(this.transform.position.x - rightzone.transform.position.x) < rightzone.GetComponent<right_zone>().l / 2) && (Mathf.Abs(this.transform.position.y - rightzone.transform.position.y) < rightzone.GetComponent<right_zone>().w / 2))
        {
            this.transform.SetParent(leftzone.transform);
        }
        else
        {
            this.transform.SetParent(ALL.transform);
        }
    }
}
