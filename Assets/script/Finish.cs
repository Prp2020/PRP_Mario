using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class Finish : Mario
{
    Vector3 This_pos;
    bool LoadScene;
    // Start is called before the first frame update
    public override void Start()
    {
        Data WriteData = (Data)GameObject.Find("DATA").GetComponent("Data");
        LoadScene = true;
        for (int i = 0; i < Round; i++)
        {
            WriteData.Score[i] = 0;
        }
        for (int i = 0; i < Round; i++)
        {
            WriteData.Gold[i] = new int[4];
            for (int j = 0; j < 4; j++)
            {
                WriteData.Gold[i][j] = Random.Range(0, 10);
            }
        }
    }

    // Update is called once per frame
    public override void Update()
    {
        Data TheData = (Data)GameObject.Find("DATA").GetComponent("Data");
        This_pos = this.transform.position;
        if (Input.GetMouseButtonDown(0))
        {
            if(IsInside())
            {
                LoadScene = true;
                for (TheData.Round_ran = 0; TheData.Round_ran < Round; TheData.Round_ran++)
                {
                    GenerateData();
                }
                if (LoadScene)
                {
                    Data WriteData = (Data)GameObject.Find("DATA").GetComponent("Data");
                    WriteData.Reset();
                    SceneManager.LoadScene(0);
                }
            }
        }
    }
    bool IsInside()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Distance(pos, This_pos) <= 0.5f)
        {
            return true;
        }
        return false;
    }

    private void GenerateData()
    {
        Data WriteData = (Data) GameObject.Find("DATA").GetComponent("Data");
        Block CURR = GameObject.Find("Start_Block").transform.GetComponent<Rb_start>();
        bool Jixu = true;
        while (Jixu&&LoadScene)
        {
            Block Prev = CURR;
            try
            {
                CURR = CURR.Read_block();
            }
            catch(UnassignedReferenceException)
            {
                Debug.Log("BUG!");
                Jixu = false;
                LoadScene = false;
            }
            //if the current block is the same as the previous block, we exit the loop
            if (Prev.gameObject.transform.name == CURR.gameObject.transform.name) Jixu = false;
        }
    }
}
