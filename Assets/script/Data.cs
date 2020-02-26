using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : Mario
{
    //1 = left, 2 = up, 3 = right, 4 = down
    public int[] Position;
    public int[] Point;
    public int[][] Gold;
    public int Round_ran;
    public int[] Score;
    // Start is called before the first frame update
    public override void Start()
    {
        Position = new int[Round];
        Point = new int[Round];
        Gold = new int[Round][];
        Score = new int[Round];
    }

    // Update is called once per frame
    public override void Update()
    {
    }

    public void Reset()
    {
        Round_ran = 0;
    }
    public void WritePosition(int Pos)
    {
        Position[Round_ran] = Pos;
        if (Round_ran == 0)
        {
            Score[0] = Gold[Round_ran][Pos-1];
            return;
        }
        Score[Round_ran] = Score[Round_ran - 1] + Gold[Round_ran][Pos-1];
    }
}
