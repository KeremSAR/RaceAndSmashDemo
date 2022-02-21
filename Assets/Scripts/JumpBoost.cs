using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBoost : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    private bool isBool = true;
    [SerializeField]
    private float JumpHeight;

    private void Start()
    {
        playerRigidbody = GameObject.Find("yikik").GetComponent<Rigidbody>(); 
        
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("değdi");
            Physics.gravity= new Vector3(0,-100,0);
            playerRigidbody.AddForce(Vector3.up*JumpHeight,ForceMode.Impulse);
            StartCoroutine(gravityChange());
        }
    }

    IEnumerator gravityChange()
    {
        yield return new WaitForSeconds(1.5f);
        Physics.gravity=new Vector3(0f,-9.81f,0f);
    }

    
}

