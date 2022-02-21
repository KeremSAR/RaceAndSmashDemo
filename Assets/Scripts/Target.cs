using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Target : MonoBehaviour
{
    private Vector3 targetPosition;
    
    private Quaternion playerRot;
    private float rotSpeed = 5;
    private float speed = 10;
    private bool moving = false;
    public Camera cam2;
    

  void Update()
    {
        if (Input.GetMouseButton(0))
        {
            SetTargetPosition();
           
        }

        if (Input.GetMouseButtonUp(0))
        {
             FindObjectOfType<Throwing>().enabled = true;
        }

        if (moving)
        {
            Move();
        }
    }

    void SetTargetPosition()
    {
        Ray ray = cam2.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray,out hit,1000))
        {
            targetPosition = hit.point;
           
            moving = true;
        }
    }

    private void Move()
    {
       Vector3 pos =new Vector3(transform.position.x,transform.position.y,-1.76f);
        transform.position = Vector3.MoveTowards(pos, targetPosition, speed * Time.deltaTime);

       
        if (transform.position==targetPosition)
        {
            moving = false;
        }
        
        
    }
}
