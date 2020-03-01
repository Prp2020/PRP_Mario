using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBin : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<MeshRenderer>().material.color = Color.black;        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string objTag = collision.transform.gameObject.tag;
        if (objTag == "Block" || objTag == "direction" || objTag == "num" || objTag == "signs")
        {
            this.GetComponent<MeshRenderer>().material.color = Color.red;
            Debug.Log("enter");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        string objTag = collision.transform.gameObject.tag;
        if (objTag == "Block" || objTag == "direction" || objTag == "num" || objTag == "signs")
        {
            this.GetComponent<MeshRenderer>().material.color = Color.black;
            Debug.Log("exit");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        string objTag = collision.transform.gameObject.tag;

        // only when people release his mouse will the object be destroyed
        if ((objTag == "Block" || objTag == "direction" || objTag == "num" || objTag == "signs") && Input.GetMouseButtonUp(0))
            Destroy(collision.transform.gameObject);
    }
}
