using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBin : Mario
{
    public GameObject Target;

    // Start is called before the first frame update
    public override void Start()
    {
        this.GetComponent<MeshRenderer>().material.color = Color.black;        
    }

    // Update is called once per frame
    public override void Update()
    {
        if (Input.GetMouseButtonUp(0) && Target != null)
            Destroy(Target);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string objTag = collision.transform.gameObject.tag;
        if (objTag == "Block" || objTag == "direction" || objTag == "num" || objTag == "signs")
        {
            this.GetComponent<MeshRenderer>().material.color = Color.red;
            Target = collision.transform.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        string objTag = collision.transform.gameObject.tag;
        if (objTag == "Block" || objTag == "direction" || objTag == "num" || objTag == "signs")
        {
            this.GetComponent<MeshRenderer>().material.color = Color.black;
            Target = null;
        }
    }
    
}
