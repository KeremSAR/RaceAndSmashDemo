using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Purple1 : Player1
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (!isColliding)
        {


            if (other.gameObject.tag == "Red")
            {
                WrongParts(other);
            }

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

        }
        if (other.CompareTag("Purple"))
        {
            
            
            CollidercubeParents[0].tag = "last";
            cubeParents[0].GetComponent<MeshRenderer>().enabled = true;
            
            //CollidercubeParents[0].SetActive(false);
            Destroy(other.gameObject);
        }
    }

    private void WrongParts(Collider other)
    {
       
        isColliding = true;
       
        //Destroy(other.gameObject);
        StartCoroutine(ISColliderToTrue());
    }
    IEnumerator ISColliderToTrue()
    {
        yield return new WaitForSeconds(0.5f);
        isColliding = false;
    }
}
