using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacter : Mario
{
    private float Time_ = 1f;   //"1f" is just to make sure Time_ is initially big enough
    private readonly float Speed = 0.025f;
    private int dir;//dir = 0 -> move nowhere. 1-left;2-up;3-right;4-down.
    private Vector3 Origin;
    private PlayMode_Data TheData;
    private bool ResetGold;
    // Start is called before the first frame update
    public override void Start()
    {
        ResetGold = true;
        Origin = this.transform.position;
        dir = 0;
        TheData = (PlayMode_Data)GameObject.Find("pool").GetComponent("PlayMode_Data");
    }

    // Update is called once per frame
    public override void Update()
    {
        Time_ += Time.deltaTime;
        if (Time_ < EndTime_)
        {
            //Move if it should
            if (dir>0)
            {
                switch (dir)
                {
                    case 1:
                        this.transform.position += Vector3.left * Speed;
                        break;
                    case 2:
                        this.transform.position += Vector3.up * Speed;
                        break;
                    case 3:
                        this.transform.position -= Vector3.left * Speed;
                        break;
                    case 4:
                        this.transform.position -= Vector3.up * Speed;
                        break;
                }
            }
        }

        if (Time_ > ResetTime_)
        {
            this.transform.position = Origin;//重置角色位置
            if (ResetGold)
            {
                TheData.Reset();//重置金币数量
                ResetGold = false;
            }
            //移动角色
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Time_ = 0;
                dir = 3;
                this.transform.position -= Vector3.left * Speed;
                TheData.MoveTo(3);
                ResetGold = true;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Time_ = 0;
                dir = 1;
                this.transform.position += Vector3.left * Speed;
                TheData.MoveTo(1);
                ResetGold = true;
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Time_ = 0;
                dir = 2;
                this.transform.position += Vector3.up * Speed;
                TheData.MoveTo(2);
                ResetGold = true;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Time_ = 0;
                dir = 4;
                this.transform.position -= Vector3.up * Speed;
                TheData.MoveTo(4);
                ResetGold = true;
            }
        }
    }
}
