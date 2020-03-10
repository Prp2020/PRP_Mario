using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMode_GoldNumber : Mario
{
    public GameObject[] cubes;
    public GameObject score;
    private TextMesh[] textMeshes;
    PlayMode_Data WriteData;
    private int[] num;
    private int scorenum;
    private float Time_ = 0;
    // Start is called before the first frame update
    public override void Start()
    {
        textMeshes = new TextMesh[4];
        try
        {
            WriteData = (PlayMode_Data)GameObject.Find("pool").GetComponent("PlayMode_Data");
        }
        catch (System.NullReferenceException)
        {
            return;
        }
        num = new int[4];
        for (int i = 0; i < 4; i++)
        {
            textMeshes[i] = cubes[i].gameObject.transform.GetChild(0).GetComponent<TextMesh>();
        }
    }

    // Update is called once per frame
    public override void Update()
    {
        Time_ += Time.deltaTime;
        if (Time_ > ResetTime_)
        {
            Time_ = 0;
        }
        for (int i = 0; i < 4; i++)
        {
            num[i] = WriteData.Gold[i];
            textMeshes[i].text = num[i].ToString();
        }
        scorenum = WriteData.Score;
        score.GetComponent<TextMesh>().text = "Score: " + scorenum.ToString();
    }
}