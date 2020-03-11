using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stay2 : Mario
{
    public static bool IsHaveUsed2 = false;
    // Use this for initialization
    public override void Start()
    {
        if (!IsHaveUsed2)
        {
            IsHaveUsed2 = true;
            DontDestroyOnLoad(this);
        }
    }

    // Update is called once per frame
    public override void Update()
    {
    }
}
