using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Throwing: MonoBehaviour
{
    public Transform Target;
    public float firingAngle = 45.0f;
    public float gravity = 9.8f;
     
    public Transform Projectile;      
    private Transform myTransform;
       
    void Awake()
    {
        myTransform = transform;      
    }
     
    void Start()
    {          
        StartCoroutine(SimulateProjectile());
    }

    IEnumerator SimulateProjectile()
    {
        // Short delay added before Projectile is thrown
        yield return new WaitForSeconds(0.01f);

        // Move projectile to the position of throwing object + add some offset if needed.
        Projectile.position = myTransform.position + new Vector3(0, 0.0f, 0);

        // Calculate distance to target
        float target_Distance = Vector3.Distance(Projectile.position, Target.position);

        // Calculate the velocity needed to throw the object to the target at specified angle.
        float projectile_Velocity = target_Distance / (Mathf.Sin(2 * firingAngle * Mathf.Deg2Rad) / gravity);

        // Extract the X  Y componenent of the velocity
        float Vx = Mathf.Sqrt(projectile_Velocity) * Mathf.Cos(firingAngle * Mathf.Deg2Rad);
        float Vy = Mathf.Sqrt(projectile_Velocity) * Mathf.Sin(firingAngle * Mathf.Deg2Rad);

        // Calculate flight time.
        float flightDuration = target_Distance / Vx;

        // Rotate projectile to face the target.
        Projectile.rotation = Quaternion.LookRotation(Target.position - Projectile.position);

        float elapse_time = 0;

        while (elapse_time < flightDuration)
        {
            Projectile.Translate(0, (Vy - (gravity * elapse_time)) * Time.deltaTime, Vx * Time.deltaTime);

            elapse_time += Time.deltaTime;

            yield return null;
        }
    }
    
}
/*using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwing : MonoBehaviour
{
    private Vector2 startPos, endPos, direction;
    private float touchTimeStart, touchTimeFinish, timeInterval;

    [SerializeField]
    private float throwForceInXandY = 1f;

    [SerializeField]
    private float throwForceInZ = 200f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))   // if (Input.touchCount>0 && Input.GetTouch(0).phase==TouchPhase.Began)
        {
            touchTimeStart = Time.time;
            startPos = Input.mousePosition; //Input.GetTouch(0).position;
        }

        if (Input.GetMouseButtonUp(0)) // if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            touchTimeFinish = Time.time;
            timeInterval = touchTimeFinish - touchTimeStart;

            endPos = Input.mousePosition; //Input.GetTouch(0).position;
            direction = endPos - startPos;
            direction.Normalize();
            rb.isKinematic = false;
            rb.AddForce(direction.x * throwForceInXandY, direction.y * throwForceInXandY, throwForceInZ / timeInterval);
            // Destroy(gameObject, 3f);
        }
    }
}*/
