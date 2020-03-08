using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;//BinaryFormatter是序列化和反序列化用到的头文件

public class GoldNumber : Mario
{
    public GameObject[] cubes;
    public GameObject score;
    public GameObject Score_Board;
    private TextMesh[] textMeshes;
    Data WriteData;
    private int[] num;
    private int scorenum;
    private int Round_run = 0;
    private float Time_ = 0;
    private bool Already_Save = false;
    public bool Show_Board = false;
    private int[] Top_Scores = new int[10];
    private string[] Player_names = new string[10];
    private save_class sg = new save_class();
    private string path;//todo:persistentDataPath
    // Start is called before the first frame update
    public override void Start()
    {
        textMeshes = new TextMesh[4];
        WriteData = (Data)GameObject.Find("DATA").GetComponent("Data");
        num = new int[4];
        for (int i = 0; i < 4; i++)
        {
            textMeshes[i] = cubes[i].gameObject.transform.GetChild(0).GetComponent<TextMesh>();
        }
        path = Application.streamingAssetsPath + "/playerData.gd";//todo: persistentDataPath
    }

    // Update is called once per frame
    public override void Update()
    {
        Time_ += Time.deltaTime;
        WriteData = (Data)GameObject.Find("DATA").GetComponent("Data");

        if (Time_ > 1.15f && Round_run < 3)
        {
            Round_run++;
            Time_ = 0;
        }
        for (int i = 0; i < 4; i++)//显示四个方向的金币数
        {
            num[i] = WriteData.Gold[Round_run][i];
            textMeshes[i].text = num[i].ToString();
        }
        scorenum = WriteData.Score[Round_run];
        score.GetComponent<TextMesh>().text = "Score: " + scorenum.ToString();
        if (Round_run == 3 && (!Already_Save))
        {
            WriteScoreBoard(scorenum);
            ReadScoreBoard();
            Already_Save = true;
            Show_Board = true;
        }
        if (Input.GetKeyDown(KeyCode.B))//开关积分榜
        {
            Show_Board = !Show_Board;
        }
        switch (Show_Board)
        {
            case true:
                Score_Board.SetActive(true);
                break;
            case false:
                Score_Board.SetActive(false);
                break;
        }
    }
    public int rank;
    void WriteScoreBoard(int Totalscore)
    {
        //WriteData
        rank = 0;
        FileStream file;
        //SaveData
        BinaryFormatter bf = new BinaryFormatter();
        if (File.Exists(path))
        {
            //读取原有数据后删除
            file = File.Open(path, FileMode.Open);
            sg = (save_class)bf.Deserialize(file);
            file.Close();
            File.Delete(path);
        }
        else//没有数据
        {

        }
        file = File.Create(path);//创建新数据文件
        for (int i = 0; i < 10; ++i)//检查排名
        {
            if (sg.ScoreData[i] <= Totalscore)
            {
                rank = i + 1;
                break;
            }
        }
        //更改数据
        for (int i = 8; i >= rank - 1; --i)
        {
            sg.ScoreData[i + 1] = sg.ScoreData[i];
            sg.Player_Name_[i + 1] = sg.Player_Name_[i];
        }
        if (rank != 0)
        {
            sg.ScoreData[rank - 1] = Totalscore;
            sg.Player_Name_[rank - 1] = "You";//todo:更改为用户昵称
        }
        bf.Serialize(file, sg);  //数据序列化后写入存档文件
        file.Close();  //关闭流
        Debug.Log(path + " data saved");
    }
    void ReadScoreBoard()//读取分数榜信息
    {
        if (File.Exists(path))//如果有存档文件
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(path, FileMode.Open);
            save_class rg = (save_class)bf.Deserialize(file);
            file.Close();
            Debug.Log(path + " data read");
            //控制积分榜的刷新
            for (int i = 1; i <= 10; i++)//积分榜的10个位置
            {
                string _name = "Score (" + i.ToString()+")";//目标显示牌的名字
                GameObject Sc;
                Sc = Score_Board.transform.Find(_name).gameObject;
                Sc.GetComponent<TextMesh>().text = "Score" +i.ToString()+ ":" + rg.ScoreData[i - 1].ToString() + "  Name:" + rg.Player_Name_[i - 1];
            }
        }
    }

}