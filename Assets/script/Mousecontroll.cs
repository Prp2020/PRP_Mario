using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mousecontroll : Mario
{
        
    private bool isMouseDown;
    private Vector3 lastMousePosition = Vector3.zero;
    Vector3 This_pos;
    float Edge;
    // Start is called before the first frame update
    public override void Start()
    {
        Edge = this.GetComponent<Renderer>().bounds.size.x / 2;
    }

    // Update is called once per frame
    public override void Update()
    {
            
        if (IsInside() || isMouseDown)
        {
            TwoDMove();
        }
        This_pos = this.transform.position;
    }
    public bool Is_;
    bool IsInside()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Distance(pos,This_pos)<= Edge)
        {
            Is_ = true;
            return true;
        }
        Is_ = false;
        return false;
    }
    private void TwoDMove()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isMouseDown = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isMouseDown = false;
            lastMousePosition = Vector3.zero;//这里要归零，不然会有漂移效果
        }
        if (isMouseDown)
        {
            if (lastMousePosition != Vector3.zero)
            {
                Vector3 offset = Camera.main.ScreenToWorldPoint(Input.mousePosition) - lastMousePosition;
                transform.position += offset;
            }
            lastMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);


        }
    }

}

