using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitScript : MonoBehaviour
{
    public GameObject loseUI;
    private bool isbool=true;
    public float strength = 500f;
    void Start()
    {
        
    }

   
    
    private void OnCollisionEnter(Collision other)
    {
        
        
        if (other.gameObject.name=="yikik")
        { 
            Vector3 dir =other.transform.position - transform.position;
            FindObjectOfType<PlayerMovement>().ishit = false; 
            FindObjectOfType<PlayerMovement>().rb.constraints = RigidbodyConstraints.None ;
            if (isbool)
            {
                GameObject.Find("Player").SetActive(false);
                isbool = false;
            }
            GetComponent<Rigidbody>().AddForce(dir * strength, ForceMode.Impulse); 
            FindObjectOfType<PlayerMovement>()._animator.SetBool("ıdle",false);
            StartCoroutine(delay());
        }
       
        
       
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(2f);
        loseUI.SetActive(true);
    }
}
