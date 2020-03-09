﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldNumber : Mario
{
    public GameObject[] cubes;
    public GameObject score;
    private TextMesh[] textMeshes;
    Data WriteData;
    private int[] num;
    private int scorenum;
    private int Round_run = 0;
    private float Time_ = 0;
    // Start is called before the first frame update
    public override void Start()
    {
        textMeshes = new TextMesh[4];
        try
        {
            WriteData = (Data)GameObject.Find("DATA").GetComponent("Data");
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
        try
        {
            WriteData = (Data)GameObject.Find("DATA").GetComponent("Data");
        }
        catch (System.NullReferenceException)
        {
            return;
        }
        
        if (Time_ > ResetTime_ && Round_run < 3)
        {           
            Round_run++;
            Time_ = 0;            
        }
        for (int i = 0; i < 4; i++)
        {
            num[i] = WriteData.Gold[Round_run][i];
            textMeshes[i].text = num[i].ToString();
        }
        scorenum = WriteData.Score[Round_run];
        score.GetComponent<TextMesh>().text = "Score: " + scorenum.ToString();
    }
}