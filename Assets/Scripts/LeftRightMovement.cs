using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class LeftRightMovement : MonoBehaviour
{
    public float speed;
    public GameObject[] prefab;
    public Transform point1;
    public Transform spawnPoint;
    private MeshRenderer mesh;
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
    }
    


    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, point1.position, speed);

        for (int i = 0; i < prefab.Length; i++)
        {
            if (prefab[i].GetComponent<MeshRenderer>().enabled==false)
            {
                prefab[i].GetComponent<MeshRenderer>().enabled = true;
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("duvar"))
        {
            this.gameObject.transform.position = spawnPoint.position;
//            this.mesh.enabled = false;
        }
    }

}
