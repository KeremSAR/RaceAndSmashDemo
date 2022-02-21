using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceRotator : MonoBehaviour
{
    public float speed = 3f;
    public bool xAxis=false;
    public bool yAxis=false;
    public bool zAxis=false;

    void Update()
    {
        if (xAxis)
        {
            transform.Rotate( 0f,speed * Time.deltaTime / 0.01f,0f,Space.World);
        }
        if (yAxis)
        {
            transform.Rotate( 0f,0f,speed * Time.deltaTime / 0.01f,Space.World);
        }
        if (zAxis)
        {
            transform.Rotate( speed * Time.deltaTime / 0.01f,0f,0f,Space.World);
        }
        
    }
}
