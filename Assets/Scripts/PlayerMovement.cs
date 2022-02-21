using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public GameObject CubeAnim;
    public float sensitivity = 0.16f, clampDelta = 42f;
    private Vector3 lastMousePos;
    public Rigidbody rb;
    public float xbounds = 5;
    public Animator _animator;
    private Material PlayerColorFromShop;
    private GameObject[] coll;
    private GameObject[] parts;
    public GameObject finish;
    public GameObject yikik;
    public Image[] image;
    public Camera camera2;
    public Camera maincamera;
    public GameObject coinPoint;
    [HideInInspector]
    public bool canMove;
    private CameraFallow CamSpeed;
    private Character character;
    public TextMesh Text;
    public GameObject pieceText;
    private int counter=0;
    private Rigidbody playerRB;
    public GameObject[] waypoints;
    public float speed;
    private bool isTouch = true;
    public GameObject LoseUI;
    public bool ishit=true;
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        CamSpeed = GameObject.Find("CameraParent").GetComponent<CameraFallow>();
        coll = GetComponentInChildren<Player>().CollidercubeParents;
        parts = GameObject.Find("Parts").GetComponent<Parts>().partsGameObjects;
        PlayerColorFromShop = GameObject.Find("yikik").GetComponentInChildren<SkinnedMeshRenderer>().material;
        character = GameDataManager.GetSelectedCharacter();
        ChangeSkin();
        playerRB = GameObject.Find("yikik").GetComponent<Rigidbody>();
        
    }

    void Update()
    {

        if (ishit)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -xbounds, xbounds), transform.position.y,
                        transform.position.z);
        }
        
        if (canMove)
        {
            if (ishit)
            {
                 transform.position += FindObjectOfType<CameraFallow>().camVel;
            }
           

        }



        else if (!canMove)
        {
            StartCoroutine(Waitingfor());
        }

        if (isTouch==false)
        {
            
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, waypoints[0].transform.position,
                        Time.deltaTime * speed);
        }
        
    }

    IEnumerator Waitingfor()
    {
        yield return new WaitForSeconds(2.80f);
        if (Input.GetMouseButtonDown(0))
        {
            canMove = true;
            Adjust();
            FindObjectOfType<GameManager>().RemoveUI();
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastMousePos = Input.mousePosition;
        }

        if (canMove)
        {
            if (ishit)
            {
                if (Input.GetMouseButton(0))
                {
                    Vector3 vector = lastMousePos - Input.mousePosition;
                    lastMousePos = Input.mousePosition;
                    vector = new Vector3(vector.x,0, 0);

                    Vector3 moveForce = Vector3.ClampMagnitude(vector, clampDelta);
                    rb.AddForce((-moveForce * sensitivity - rb.velocity / 5f), ForceMode.VelocityChange);
                }
                
            }
            
        }

        //rb.velocity.Normalize();

        if (waypoints[0].transform.position==yikik.transform.position)
        {
            isTouch = true;
           
          
        }
        if (finish.transform.position == yikik.transform.position)
        {
            _animator.SetTrigger("climb");
            StartCoroutine(YıkıkBoxColliderFixed());
        }
    }

   IEnumerator YıkıkBoxColliderFixed()
    {
        yield return new WaitForSeconds(2.50f);
        GetComponent<BoxCollider>().center = new Vector3(0.3f, 1.18f, 7.91f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "checkpoint1")
        {
            coll[0].gameObject.SetActive(false);
            coll[1].gameObject.SetActive(true);
            image[0].enabled = false;
            image[1].enabled = true;
            coinPoint.SetActive(false);

        }

        if (other.name == "checkpoint2")
        {
            coll[1].gameObject.SetActive(false);
            coll[2].gameObject.SetActive(true);
            image[1].enabled = false;
            image[2].enabled = true;
            coinPoint.SetActive(false);
        }

        if (other.name == "checkpoint3")
        {
            coll[2].gameObject.SetActive(false);
            coll[3].gameObject.SetActive(true);
            image[2].enabled = false;
            image[3].enabled = true;
            coinPoint.SetActive(false);
        }

        if (other.name == "checkpoint4")
        {
            coll[3].gameObject.SetActive(false);
            coll[4].gameObject.SetActive(true);
            image[3].enabled = false;
            image[4].enabled = true;
            coinPoint.SetActive(false);
        }

        if (other.name == "checkpoint5")
        {
            coll[4].gameObject.SetActive(false);
            coll[5].gameObject.SetActive(true);
            image[4].enabled = false;
            image[5].enabled = true;
            coinPoint.SetActive(false);
        }

        if (other.name == "checkpoint6")
        {
            coll[5].gameObject.SetActive(false);
            coll[6].gameObject.SetActive(true);
            image[5].enabled = false;
            image[6].enabled = true;
            coinPoint.SetActive(false);
        }

        if (other.name == "checkpoint7")
        {
            coll[6].gameObject.SetActive(false);
            image[6].enabled = false;
            camera2.gameObject.SetActive(true);
            maincamera.gameObject.SetActive(false);
            coinPoint.SetActive(false);
            WriteThisLastCheckPoint();
        }
/*
        if (other.name == "finishing")
        {

            //_animator.SetBool("ıdle",false); 
            // GetComponent<BoxCollider>().enabled = false;

           /* var allCollisions = GameObject.Find("Player").GetComponent<Player>().CollidercubeParents;
            foreach (var kl in allCollisions)
            {
                kl.SetActive(true);
            }
            
            
            for (int i = 0; i < coll.Length; i++)
            {
                if (coll[i].tag == "Player")
                {
                    coll[i].SetActive(false);
                }
                else
                {
                    coll[i].SetActive(true);
                    counter++;
                }

            }
            Debug.Log(counter+"taneeeeeeeeeee");
                */
            /*if (k>h)
            {
                
                
            }
            else
            {
              
                
            }
             
        }*/
        if (other.name == "Finish")
        {
            
            var allCollisions = GameObject.Find("Player").GetComponent<Player>().CollidercubeParents;
            foreach (var kl in allCollisions)
            {
                kl.SetActive(true);
            }
            
            
            for (int i = 0; i < coll.Length; i++)
            {
                if (coll[i].tag == "Player")
                {
                    coll[i].SetActive(false);
                    
                }
                else
                {
                    coll[i].SetActive(true);
                    counter++;
                }

            }
            
            _animator.SetBool("ıdle",false);
            CamSpeed.cameraSpeed = 0f;
            pieceText.SetActive(true);
            Text.text = " +" + counter;
            rb.constraints = RigidbodyConstraints.FreezeAll;
            StartCoroutine(CountDelay());
            

        }
    }

    IEnumerator CountDelay()
    {
        yield return new WaitForSeconds(2.5f);
        if (counter >= FindObjectOfType<FollowThePath>().counterBot)
        {
            _animator.SetBool("ıdle",true);
            Debug.Log("yessssssssssssssssssssssssssssssssssssssssssss");
            isTouch = false;
            
        }
        else
        {
            Debug.Log("Noooooooooooooooooooooooo");
            _animator.SetTrigger("Sad");
            Animator k=GameObject.Find("Bot").GetComponent<Animator>();
            k.SetTrigger("happy");
            FindObjectOfType<FollowThePath>().particle.SetActive(true);
            GameObject.Find("Player1").SetActive(false);
            LoseUI.SetActive(true);
        }
    }

    


    private void WriteThisLastCheckPoint()
    {
        gameObject.GetComponent<BoxCollider>().isTrigger = true;
        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
        GameObject.Find("qq").SetActive(false);
    }

    private void Adjust()
    {
        coll[0].SetActive(true);
        _animator.SetBool("ıdle", true);
        CubeAnim.SetActive(false);
    }

    void ChangeSkin()
    {
        
    
        if (character.name == "Ripley")
        {
            PlayerColorFromShop.color = Color.green;
            SpeedAndHealth(character);
           
        }
        else if (character.name == "John")
        {
            PlayerColorFromShop.color = Color.gray;
            SpeedAndHealth(character);
        }
        else if (character.name == "Blue")
        {
            PlayerColorFromShop.color = Color.blue;
            SpeedAndHealth(character);
        }
        else if (character.name == "Tyro")
        {
            PlayerColorFromShop.color = Color.red;
            SpeedAndHealth(character);
        }
        else if (character.name == "Harrower")
        {
            PlayerColorFromShop.color = Color.cyan;
            SpeedAndHealth(character);
        }
        else if (character.name == "Sam")
        {
            PlayerColorFromShop.color = Color.magenta;
            SpeedAndHealth(character);
        }
        else if (character.name == "Kesh")
        {
            PlayerColorFromShop.color = Color.yellow;
            SpeedAndHealth(character);
        }
        else if (character.name == "Mercury")
        {
            PlayerColorFromShop.color = Color.magenta;
            SpeedAndHealth(character);
        }

    }

    private void SpeedAndHealth(Character character)
    {
        CamSpeed.cameraSpeed = character.speed;
        PlayerPrefs.SetInt("heal",character.health);
    }
}
   
