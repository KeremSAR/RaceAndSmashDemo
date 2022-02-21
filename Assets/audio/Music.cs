using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Music : MonoBehaviour
{
    private static Music vol = null;
    
    private void Awake()
    {
        if (vol == null)
        {
            vol = this;
            DontDestroyOnLoad(this);
        }
        else if (this != vol)
        {
            Destroy(gameObject);
        }
    }
    
    void OnDestroy()
    {
        SceneManager.sceneLoaded -= Loaded;
    }
     
    
    void Loaded( Scene scene, LoadSceneMode mode )
    {
        if( scene.name == "New" )
        {
            vol = null;
            Destroy( gameObject );
        }
    }
    
   
}
    
    

