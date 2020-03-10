using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMode_Data : Mario
{
    //1 = left, 2 = up, 3 = right, 4 = down
    //Gold中对应减一
    public int[] Gold;
    public int Score;
    // Start is called before the first frame update
    public override void Start()
    {
        Score = 0;
        Gold = new int[4];
    }

    // Update is called once per frame
    public override void Update()
    {
        
    }

    public void Reset()
    {
        int MAX_RANGE = 10;
        for (int i = 0; i < 4; i++) {
            Gold[i]=Random.Range(0,MAX_RANGE);
        }
    }

    public void MoveTo(int Dir)
    {
        Score += Gold[Dir - 1];
    }
}
