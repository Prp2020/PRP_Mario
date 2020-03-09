using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mario : MonoBehaviour
{
    protected int Round = 4;
    //Some time constants for simulatino
    protected readonly float EndTime_ = 0.5f;
    protected readonly float ResetTime_ = 1.5f;
    public virtual void Start()
    {
        
    }

    public virtual void Update()
    {

    }

    public class IfWithoutEndException : System.Exception
    {

    }

    public class MultiJumpException : System.Exception
    {

    }

    //Require: two 3d vector
    //Modify: None
    //Effect: return the distance on xy plane of the two vectors as float
    public float Distance(Vector3 a1, Vector3 a2)
    {
        Vector2 a, b;
        a.x = a1.x;
        a.y = a1.y;
        b.x = a2.x;
        b.y = a2.y;
        return (b - a).magnitude;
    }
}

