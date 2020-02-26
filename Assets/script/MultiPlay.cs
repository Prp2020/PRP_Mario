using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiPlay : Mario
{
    private int Round_run = 0;
    private int Dir;
    public float speed = 0.05f;
    private float Time_ = 0;
    private Data ReadData;
    private Vector3 Origin;
    // Start is called before the first frame update
    public override void Start()
    {
        ReadData = (Data)GameObject.Find("DATA").GetComponent("Data");
        Origin = this.transform.position;
        Dir = ReadData.Position[0];
    }

    // Update is called once per frame
    public override void Update()
    {
        Time_ += Time.deltaTime;
        if (Round_run < Round)
        {
            switch (Dir)
            {
                case 1:
                    this.transform.position += Vector3.left * speed;
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
        if (Time_ > 1.15f)
        {
            this.transform.position = Origin;
            Round_run++;
            Time_ = 0;
            if(Round_run<Round)
            Dir = ReadData.Position[Round_run];
        }
    }
}
