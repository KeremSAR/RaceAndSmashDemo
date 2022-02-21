using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowThePath : MonoBehaviour
{

    // Array of waypoints to walk from one to the next one
    [SerializeField]
    private Transform[] waypoints;

    // Walk speed that can be set in Inspector
    [SerializeField]
    private float moveSpeed = 2f;

    // Index of current waypoint from which Enemy walks
    // to the next one
    private int waypointIndex = 0;
    public bool go = false;


    public GameObject CubeAnim;
    private Rigidbody rb;
    private Animator _animator;
    private GameObject[] coll;
    private GameObject[] parts;




    // public GameObject coinPoint;
    [HideInInspector]
    public bool canMove;
    private CameraFallow CamSpeed;
    // private HealthSystem _currenthealth;
    public TextMesh Text;
    public GameObject pieceText;
    public int counterBot ;
    public GameObject particle;







    // Use this for initialization
    private void Start()
    {

        // Set position of Enemy as position of the first waypoint
        transform.position = waypoints[waypointIndex].transform.position;
        rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        //_currenthealth = GameObject.Find("Player").GetComponent<HealthSystem>();
        coll = GetComponentInChildren<Player1>().CollidercubeParents;
        parts = GameObject.Find("Parts").GetComponent<Parts>().partsGameObjects;
    }

    // Update is called once per frame
    private void Update()
    {

        if (canMove)
        {
            Move();
        }



        else if (!canMove)
        {
            StartCoroutine(Waitingfor());

            rb.velocity.Normalize();
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "checkpoint1")
        {
            coll[0].gameObject.SetActive(false);
            coll[1].gameObject.SetActive(true);
            // coinPoint.SetActive(false);

        }

        if (other.name == "checkpoint2")
        {
            coll[1].gameObject.SetActive(false);
            coll[2].gameObject.SetActive(true);
            //coinPoint.SetActive(false);
        }

        if (other.name == "checkpoint3")
        {
            coll[2].gameObject.SetActive(false);
            coll[3].gameObject.SetActive(true);
            // coinPoint.SetActive(false);
        }

        if (other.name == "checkpoint4")
        {
            coll[3].gameObject.SetActive(false);
            coll[4].gameObject.SetActive(true);
            // coinPoint.SetActive(false);
        }

        if (other.name == "checkpoint5")
        {
            coll[4].gameObject.SetActive(false);
            coll[5].gameObject.SetActive(true);
            // coinPoint.SetActive(false);
        }

        if (other.name == "checkpoint6")
        {
            coll[5].gameObject.SetActive(false);
            coll[6].gameObject.SetActive(true);
            //coinPoint.SetActive(false);
        }

        if (other.name == "checkpoint7")
        {
            coll[6].gameObject.SetActive(false);
            // coinPoint.SetActive(false);

        }

        if (other.name == "Finish")
        {
            var allCollisions = GameObject.Find("Player1").GetComponent<Player1>().CollidercubeParents;
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
                    counterBot++;
                }
                
                _animator.SetBool("ıdle", false);
                pieceText.SetActive(true);
                Text.text = " +" + counterBot;


            }

            /*  if (other.name=="finishing")
              {
      
                  _animator.SetBool("ıdle",false); 
                  GetComponent<BoxCollider>().enabled = false;
                 
                  var allCollisions = GameObject.Find("Player").GetComponent<Player>().CollidercubeParents;
                  foreach (var kl in allCollisions)
                  {
                     kl.SetActive(true);
                  }
      
                  for (int i = 0; i < coll.Length; i++)
                  {
                      if (coll[i].tag=="Player" )
                      {
                          coll[i].SetActive(false);
                      }
                      else
                      {
                          coll[i].SetActive(true);
                      }
                     
                  }
                  
           }*/
        }
    }


        private void Adjust()
        {
            coll[0].SetActive(true);
            _animator.SetBool("ıdle", true);
            CubeAnim.SetActive(false);
        }


        // Method that actually make Enemy walk
        private void Move()
        {
            // If Enemy didn't reach last waypoint it can move
            // If enemy reached last waypoint then it stops
            if (waypointIndex <= waypoints.Length - 1 && go == false)
            {

                // Move Enemy from current waypoint to the next one
                // using MoveTowards method
                transform.position = Vector3.MoveTowards(transform.position,
                    waypoints[waypointIndex].transform.position,
                    moveSpeed * Time.deltaTime);

                // If Enemy reaches position of waypoint he walked towards
                // then waypointIndex is increased by 1
                // and Enemy starts to walk to the next waypoint
                if (transform.position == waypoints[waypointIndex].transform.position)
                {
                    waypointIndex += 1;
                    // if (transform.position == waypoints[waypoints.Length-1].transform.position)
                    // {
                    //     _animator.SetBool("ıdle",false); 
                    //     
                    // }
                }
            }
        }

    
}

