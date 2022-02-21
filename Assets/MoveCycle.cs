using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCycle : MonoBehaviour
{
    public Transform point2;
    public Transform point1;
    public float speed;
    public float speedup;
    public float speeddown;
    private bool isloop;
    public bool isX;
    public bool isY;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isX)
        {
            if (transform.position.x==point1.position.x)
            {
                isloop = true;
            }
            if (isloop==true)
            { transform.position = Vector3.MoveTowards(transform.position, point2.position, speed*Time.deltaTime);
            }
         
            if (transform.position.x==point2.position.x)
            {
                
                isloop = false;
            }
         
            if (isloop==false)
            {
                transform.position = Vector3.MoveTowards(transform.position, point1.position, speed * Time.deltaTime);
            }
            
        }

        if (isY)
        {
            if (transform.position.y==point1.position.y)
            {
                isloop = true;
            }
            if (isloop==true)
            { transform.position = Vector3.MoveTowards(transform.position, point2.position, speedup*Time.deltaTime);
            }
         
            if (transform.position.y==point2.position.y)
            {
                
                isloop = false;
            }
         
            if (isloop==false)
            {
                transform.position = Vector3.MoveTowards(transform.position, point1.position, speeddown * Time.deltaTime);
            }
        }

        
        
    }
}
