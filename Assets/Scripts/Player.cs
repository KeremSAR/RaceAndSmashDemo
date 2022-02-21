using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class Player:MonoBehaviour
{
    public GameObject[] cubeParents;
    public GameObject[] CollidercubeParents;
    public AudioManager audio;
    public GameObject coinPoint;
    public HealthSystem health;
    public bool isColliding=false;
    public bool isVibrate = true;
    public GameObject LoseUI;
    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "x1"||other.gameObject.name == "x2"||other.gameObject.name == "x3"||other.gameObject.name == "x4")
        {
            GameObject.Find("Smash's Background").tag = "duvar";
        }
        if (other.CompareTag("Wall"))
        {
            Destroy(this.gameObject,0.5f);
            LoseUI.SetActive(true);
        }
        
    }
   
   
    
}



/* void Start()
 {
     StartCoroutine(ColorChangingTime());
     InvokeRepeating("Change",0.1f,2f);
     
 }

 private void Change()
 {
     if (i-1<cubeParents.Length-1)
     {
         var selectedObject = cubeParents[i];
         Debug.Log(i+"i");
         i++;
         obj = selectedObject.gameObject.GetComponent<MeshRenderer>();
        
     }
     if (k-1<CollidercubeParents.Length-1)
     {
         var selectedcolObject = CollidercubeParents[i];
         Debug.Log(k+"k");
         k++;
         ColObj = selectedcolObject.gameObject;
         
     }
 }

 private void Update()
 {
     
     if (isBool)
     {

         if (obj.enabled==false)
         {
             ColObj.SetActive(true);
             obj.enabled = true;
             obj.material.color=Color.blue;
             isBool = false; Debug.Log("kaç kere");
         }
         
     }

 }*/

   /* void FixedUpdate()
    {
        
    }

   

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectable"))
        {
            string itemType = other.gameObject.GetComponent<Collectable>().itemType;
            items.Add(itemType);

            if (items.Contains("iki"))
            {
                cubeParents[0].GetComponent<MeshRenderer>().enabled = true;
                CollidercubeParents[0].SetActive(false);
                
            }

            if (items.Contains("üç"))
            {
                cubeParents[1].GetComponent<MeshRenderer>().enabled = true;
                CollidercubeParents[1].SetActive(false);
            }

            if (items.Contains("dört"))
            {
                cubeParents[2].GetComponent<MeshRenderer>().enabled = true;
                CollidercubeParents[2].SetActive(false);
            }

            if (items.Contains("beş"))
            {
                cubeParents[3].GetComponent<MeshRenderer>().enabled = true;
                CollidercubeParents[3].SetActive(false);
            }

            if (items.Contains("altı"))
            {
                cubeParents[4].GetComponent<MeshRenderer>().enabled = true;
                CollidercubeParents[4].SetActive(false);
            }

            if (items.Contains("yedi"))
            {
                cubeParents[5].GetComponent<MeshRenderer>().enabled = true;
                CollidercubeParents[5].SetActive(false);
            }

            if (items.Contains("sekiz"))
            {
                cubeParents[6].GetComponent<MeshRenderer>().enabled = true;
                CollidercubeParents[6].SetActive(false);
            }

            Destroy(other.gameObject);
            
        }

        
    
   /* IEnumerator ColorChangingTime()
    {
        WaitForSeconds wait = new WaitForSeconds(2f);
        for (int i = 0; i < 14; i++)
        {
            yield return wait;
            isBool = true;
        }
        
    }*/

