using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class Finish : Block
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
                    SceneManager.LoadScene("SampleScene");
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
        Data WriteData = (Data)GameObject.Find("DATA").GetComponent("Data");
        Block CURR = GameObject.Find("Start_Block").transform.GetComponent<Rb_start>();
        bool Jixu = true;
        WriteData.Jumped = false;
        while (Jixu&&LoadScene)
        {
            Block Prev = CURR;
            try
            {
                CURR = CURR.Read_block();
            }
            catch(UnassignedReferenceException)
            {
                Debug.Log("There is a command with no target! Exception type: 1");
                Jixu = false;
                LoadScene = false;
            }
            catch (System.NullReferenceException)
            {
                Debug.Log("There is a command with no target! Exception type: 2");
                Jixu = false;
                LoadScene = false;
            }
            catch (IfWithoutEndException)
            {
                Debug.Log("There is a IF without an End! Exception type: 3");
                Jixu = false;
                LoadScene = false;
            }
            catch (MultiJumpException)
            {
                Debug.Log("Too many JUMP executed. Exception type: 5");
                Jixu = false;
                LoadScene = false;
            }
            //if the current block is the same as the previous block, we exit the loop
            //If jumped is false, it means the player's program didn't execute any jumps
            if (Prev.gameObject.transform.name == CURR.gameObject.transform.name)
            {
                Jixu = false;
                if (!WriteData.Jumped)
                {
                    LoadScene = false;
                    Debug.Log("No JUMP executed! Exception type: 4");
                }
                WriteData.Jumped = false;
            }
        }
    }
}
