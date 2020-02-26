using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : Mario
{
    int i;
    public float speed=0.05f;
    float Time_=0;
    // Start is called before the first frame update
    public override void Start()
    {
        Data readData = (Data) GameObject.Find("DATA").GetComponent("Data");
        i=readData.Position[0];
    }

    // Update is called once per frame
    public override void Update()
    {
        Time_ += Time.deltaTime;
        if (Time_ > 1.15f)
            return;
        switch(i)
        {
            case 1:
                this.transform.position += Vector3.left*speed;
                break;
            case 2:
                this.transform.position += Vector3.up * speed;
                break;
            case 3:
                this.transform.position -= Vector3.left * speed;
                break;
            case 4:
                this.transform.position -= Vector3.up * speed;
                break;

        }
    }
}
