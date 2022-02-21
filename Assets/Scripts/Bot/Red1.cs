using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Red1 : Player1
{
   
    private void Start()
    {
        //health = GameObject.Find("Player").GetComponent<HealthSystem>();
       // audio = GameObject.Find("CameraParent").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isColliding)
        {
            if (other.gameObject.tag == "Orange")
            {
                WrongParts(other);
            }

            if (other.gameObject.tag == "Yellow")
            {
                WrongParts(other);
            }

            if (other.gameObject.tag == "Green")
            {
                WrongParts(other);
            }

            if (other.gameObject.tag == "Blue")
            {
                WrongParts(other);
            }

            if (other.gameObject.tag == "Black")
            {
                WrongParts(other);
            }

            if (other.gameObject.tag == "Purple")
            {
                WrongParts(other);
            }
        }
        if (other.gameObject.tag == "Red")
        {
            
            CollidercubeParents[0].tag = "last";
           // audio.TrueSound();
            cubeParents[0].GetComponent<MeshRenderer>().enabled = true;
            //coinPoint.SetActive(true);
            //CollidercubeParents[0].SetActive(false);
            Destroy(other.gameObject);
        }

    }

    private void WrongParts(Collider other)
    {
      
        isColliding = true;
        //health.TakeDamage(1);
        //audio.WrongSound();
        //Debug.Log("wrong part!!!!"); //add animation later
        //Destroy(other.gameObject);
        StartCoroutine(ISColliderToTrue());
    }

    IEnumerator ISColliderToTrue()
    {
        yield return new WaitForSeconds(0.5f);
        isColliding = false;
    }
}