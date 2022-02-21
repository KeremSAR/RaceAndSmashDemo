using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    private CameraFallow cam;
    private bool isBool=false;
    private float speedtime=0f;
    [SerializeField]
    private float SpeedDuration;
    [SerializeField]
    private float BoostSpeed;
    
    void Start()
    {
        cam = GameObject.Find("CameraParent").GetComponent<CameraFallow>(); 
    }

    private void FixedUpdate()
    {
        if (isBool)
        {
            speedtime+=1*Time.deltaTime;
            if (speedtime>=SpeedDuration)
            {
                isBool = false;
                cam.cameraSpeed =GameDataManager.GetSelectedCharacter ().speed ;
                speedtime = 0;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cam.cameraSpeed = BoostSpeed;
            isBool = true;
        }
    }

   
}
