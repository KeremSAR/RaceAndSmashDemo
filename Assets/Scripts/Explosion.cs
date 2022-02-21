using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyWaterBuoyancy;
using UnityEngine;
using Random = UnityEngine.Random;


public class Explosion : MonoBehaviour
{

    private AudioManager audio;
    
    public float cubeSize = 0.2f;
    public float cubesInRow = 2;

    float cubesPivotDistance;
    Vector3 cubesPivot;

    public float explosionForce = 50f;
    public float explosionRadius = 4f;
    public float explosionUpward = 0.4f;

    // Use this for initialization
    void Start()
    {

        audio = GameObject.Find("CameraParent").GetComponent<AudioManager>();
        //calculate pivot distance
        cubesPivotDistance = cubeSize * cubesInRow / 2;
        //use this value to create pivot vector)
        cubesPivot = new Vector3(cubesPivotDistance, cubesPivotDistance, cubesPivotDistance);
        

    }

    // Update is called once per frame
    void Update() {

    }

    private void OnTriggerEnter(Collider other) {
        /*if (other.gameObject.name == "Wall") 
        {
            explode();

        }*/
        
        if (other.gameObject.name == "x1")
        { 
            audio.Explode();
            cubesInRow = 2;
            explode();
           Destroy(other.gameObject);

        }
        if (other.gameObject.name == "x2")
        {
            audio.Explode();
            cubesInRow = 2.25f;
            explode();
            Destroy(other.gameObject);

        }
        if (other.gameObject.name == "x3")
        {
            audio.Explode();
            cubesInRow = 3.25f;
            explode();
            Destroy(other.gameObject);

        }
        if (other.gameObject.name == "x4")
        {
            audio.Explode();
            cubesInRow = 3.75f;
            explode();
            Destroy(other.gameObject);

        }

    }

    

    public void explode() {
        //make object disappear
        gameObject.SetActive(false);

        //loop 3 times to create 5x5x5 pieces in x,y,z coordinates
        for (int x = 0; x < cubesInRow; x++) {
            for (int y = 0; y < cubesInRow; y++) {
                for (int z = 0; z < cubesInRow; z++) {
                    createPiece(x, y, z);
                }
            }
        }

        //get explosion position
        Vector3 explosionPos = transform.position;
        //get colliders in that position and radius
        Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
        //add explosion force to all colliders in that overlap sphere
        foreach (Collider hit in colliders) {
            //get rigidbody from collider object
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null) {
                //add explosion force to this body with given parameters
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, explosionUpward);
            }
        }

    }

    void createPiece(int x, int y, int z) {

        //create piece
        GameObject piece;
        piece = GameObject.CreatePrimitive(PrimitiveType.Cube);

        //set piece position and scale
        piece.transform.position = transform.position + new Vector3(cubeSize * x, cubeSize * y, cubeSize * z) - cubesPivot;
        piece.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);

        //add rigidbody and set mass
        piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().mass = cubeSize;
        piece.tag = "balls";
        piece.GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value, 0.1f);
        piece.AddComponent<FloatingObject>();
    }

}
