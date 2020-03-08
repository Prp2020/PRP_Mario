using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
[System.Serializable]
public class save_class
{
    public bool Scoreboard;
    public int[] ScoreData = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };//仅储存前10名
    public int Test;
    public string Test_name;
    public string[] Player_Name_ = new string[10] { "Player1", "Player2", "Player3", "Player4", "Player5", "Player6", "Player7", "Player8", "Player9", "Player10" };
}
