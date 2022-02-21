using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFallow : MonoBehaviour
{
    public float cameraSpeed = 0f;
    public Vector3 camVel;
    private Animator _animation;
    

        

    private void Start()
    {

        StartCoroutine(waiting());
        _animation = GetComponentInChildren<Animator>();
        
    }

    private void Update()
    {
        if (FindObjectOfType<PlayerMovement>().canMove)
        {
            if (FindObjectOfType<PlayerMovement>().ishit)
            {
                transform.position += Vector3.forward * cameraSpeed * Time.deltaTime;
            }
             
        }
       
        camVel = Vector3.forward * cameraSpeed * Time.deltaTime;
        _animation.SetBool("exit",true);
    }

    IEnumerator waiting()
    {
        
        yield return new WaitForSeconds(0.2f);
        GetComponent<HealthSystem>().enabled = true;

    }

    

}
