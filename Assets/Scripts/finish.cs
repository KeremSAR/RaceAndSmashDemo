using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class finish : MonoBehaviour
{
    private BoxCollider k;
    private CameraFallow cam;
    public GameObject none;
    private Animator Sad;
    private Rigidbody playerRB;
   

    private void Start()
    {
        k=GameObject.Find("Player").GetComponent<BoxCollider>();
        cam = GameObject.Find("CameraParent").GetComponent<CameraFallow>();
        Sad = GameObject.Find("yikik").GetComponent<Animator>();
        playerRB = GameObject.Find("yikik").GetComponent<Rigidbody>();
    }

    
    private void OnCollisionEnter(Collision other)
    {
        
        Debug.Log("dışarı");
        if (other.gameObject.tag=="last") 
        {
            Debug.Log("finish  ");
            cam.cameraSpeed = 0f;

            none.SetActive(false);
            k.enabled = true;
            Invoke("Delay",0.1f);
            

            GetComponent<BoxCollider>().isTrigger = true;
            
            var rb = GameObject.Find("Player").GetComponent<Rigidbody>();
            rb.constraints = RigidbodyConstraints.None;
            rb.constraints = RigidbodyConstraints.FreezePositionY|RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY |
                             RigidbodyConstraints.FreezeRotationZ;
           
            
            playerRB.constraints = RigidbodyConstraints.FreezeAll;
            Sad.SetBool("ıdle",false);
        }

        if (other.gameObject.tag=="None")
        {
            cam.cameraSpeed = 0f;
            Sad.SetTrigger("Sad");
            playerRB.constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    

    void Delay()
    {
        k.isTrigger = true;
    }

    
    
}
