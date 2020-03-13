using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Save : MonoBehaviour
{
    //when saveAll is 1, objects will be saved
    public int saveAll = 0;
    private Button saveBt;
    public Text saveT;

    private GameObject remain_Data;

    // Start is called before the first frame update
    void Start()
    {
        
        remain_Data = GameObject.Find("remain_Data");

        saveBt = this.GetComponent<Button>();
        saveBt.onClick.AddListener(OnClick);
        saveT = GameObject.Find("saveText").GetComponent<Text>();
        
    }
    // Update is called once per frame
    void Update()
    {
        reset();
    }

    private void OnClick()
    {
        if (saveAll==0)
        {
            saveAll = 1;
            saveT.text = "Clear";
        }
        else
        {
            saveAll = 0;
            saveT.text = "Save";
            remain_Data.GetComponent<remainData>().ClearInfo();
        }
    }

    private void reset()
    {
        if (remain_Data.GetComponent<remainData>().actualnum == 0)
        {
            if (remain_Data.GetComponent<remainData>().num_inleftzone != 0)
            {
                saveAll = 2;
                saveT.text = "Clear";
            }
        }
    }

}
