using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stay : Mario
{
    public static bool IsHaveUsed = false;
    // Use this for initialization
    public override void Start()
    {
        if (!IsHaveUsed)
        {
            IsHaveUsed = true;
            DontDestroyOnLoad(this);
        }
    }

    // Update is called once per frame
    public override void Update()
    {
    }
}
