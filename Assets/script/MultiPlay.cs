using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiPlay : Mario
{
    private int Round_run = 0;
    private int Dir;
    //! THIS SPEED IS NOT WORKING. IT HAS NO EFFECT ON THE ACTUAL SPEED. NEED FURTHER EXAMINATION.
    public float speed = 0.0f;
    private float Time_ = 0;
    private Data ReadData;
    private Vector3 Origin;
    // Start is called before the first frame update
    public override void Start()
    {
        try
        {
            ReadData = (Data)GameObject.Find("DATA").GetComponent("Data");
        }
        catch (System.NullReferenceException)
        {
            return;
        }
        Origin = this.transform.position;
        Dir = ReadData.Position[0];
    }

    // Update is called once per frame
    public override void Update()
    {
        try
        {
            Data Try = (Data)GameObject.Find("DATA").GetComponent("Data");
        }
        catch (System.NullReferenceException)
        {
            return;
        }
        Time_ += Time.deltaTime;
        //在这个时间段内保持静止
        if (Time_ > EndTime_ && Time_ <= ResetTime_) return;
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
        if (Time_ > ResetTime_)
        {
            this.transform.position = Origin;
            Round_run++;
            Time_ = 0;
            if(Round_run<Round)
            Dir = ReadData.Position[Round_run];
        }
    }
}
