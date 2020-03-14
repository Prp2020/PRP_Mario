using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rebuild : MonoBehaviour
{
    private Button rebuildBt;
    private GameObject remain_Data;
    private GameObject leftzone;

    // Start is called before the first frame update
    void Start()
    {
        rebuildBt = this.GetComponent<Button>();
        rebuildBt.onClick.AddListener(OnClick);
        remain_Data = GameObject.Find("remain_Data");
        leftzone = GameObject.Find("leftzone");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnClick()
    {
        if (remain_Data.GetComponent<remainData>().actualnum == 0)
        {
            leftzone.GetComponent<left_zone>().reBuild();
        }
    }
}