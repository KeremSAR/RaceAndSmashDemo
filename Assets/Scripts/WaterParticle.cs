using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterParticle : MonoBehaviour
{
    public GameObject waterParticle;
    public Transform waterpartpos;
    


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name=="Water")
        { 
            Instantiate(waterParticle, waterpartpos.position, Quaternion.Euler(90,0,0));
            FindObjectOfType<AudioManager>().DivingSound();
        }
    }
}
