using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class Nowstart : Mario
{
    Vector3 This_pos;
    // Start is called before the first frame update
    public override void Start()
    {
    }

    // Update is called once per frame
    public override void Update()
    {
        This_pos = this.transform.position;
        if (Input.GetMouseButtonDown(0))
        {
            if (IsInside())
            { 
                SceneManager.LoadScene("Game1_Main");
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
}
