using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
    public helthBar helthBar;
    private static int currentHealth ;
    public GameObject loseUI;
  


    
    public void Start()
    {
        helthBar = GameObject.Find("Health Bar").GetComponent<helthBar>();
        currentHealth = PlayerPrefs.GetInt("heal");
        helthBar.SetMaxHealth(currentHealth);
        
    }


    private void FixedUpdate()
    {
        
        
        if (currentHealth==0)
        {
            GameObject.Find("CameraParent").GetComponent<CameraFallow>().cameraSpeed = 0f;
            GameObject.Find("yikik").GetComponent<Animator>().SetTrigger("Sad");
            loseUI.SetActive(true);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth =currentHealth-damage;
        helthBar.SetHealth(currentHealth);
    }

   
}
