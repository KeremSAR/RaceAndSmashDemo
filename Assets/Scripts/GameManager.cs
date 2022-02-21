using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
     public Text SwipeText;
     public Image SwipeImage;

     public void RemoveUI()
     {
         Destroy(SwipeImage);
         Destroy(SwipeText);
     }
 

   

     
}
