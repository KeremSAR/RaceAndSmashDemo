using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckPointer : MonoBehaviour
{
    public int collisionBallCount = 0;
    public TextMesh ScoreText;
    public Animator _animator;
    private CoinsManager _coinsManager;

    public GameObject confetti;
    public GameObject levelCompletedPanel;
    public GameObject levelFailedPanel;
    public GameObject Walls;
    private bool isBool = true;
    public TMP_Text coin;
    public int currentLevel = 0;
    public TMP_Text LevelText;
    public void CompleteLevel()
    {
        confetti.SetActive(true);
    }
    
    
    
    
    
    void Start()
    {
        ScoreText.text = "3 / " + collisionBallCount;
        _animator = GameObject.Find("yikik").GetComponent<Animator>();
        _coinsManager = FindObjectOfType<CoinsManager>();
        currentLevel = PlayerPrefs.GetInt("Level");
        LevelText.text = "" + (currentLevel + 1);

    }



    void Update()
    {
        
        if (collisionBallCount>=100)
        {
            StartCoroutine(delay2());
            _animator.SetBool("ıdle",true);
            _animator.SetBool("Vana",false);
            var s = GameObject.Find("yikik").GetComponent<EndWaypoint>();
            s.enabled = true;
            CompleteLevel();
            Walls.SetActive(false);
        }
            
        if (collisionBallCount < 100 && isBool == false)
        {
            levelFailedPanel.SetActive(true);    
                
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("balls"))
        {
            StartCoroutine(delay());
            collisionBallCount += 1; // Collision oldukça topu 1 artırdık.
            
           // _coinsManager.AddCoins(other.transform.position,collisionBallCount);
           if (collisionBallCount>=100)
           {
               
               GameDataManager.AddCoins(1);
               GameSharedUI.Instance.UpdateCoinsUIText();
           }
           
            ScoreText.text = "100 / " + collisionBallCount; //Kaç Tane top atıldığını yazdırdık.
            
           
        }

    }
    IEnumerator delay()
    {
        yield return new  WaitForSeconds(3f);
        isBool = false;
    }
    IEnumerator delay2()
    {
        yield return new  WaitForSeconds(2f);
        levelCompletedPanel.SetActive(true);
        coin.text = "+ " + collisionBallCount;
        PlayerPrefs.SetInt("Level",currentLevel);

    }
    public void levelAtlama()
    {
        currentLevel++;
        PlayerPrefs.SetInt("Level", currentLevel);
    }
    

    


}

