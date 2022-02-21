using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Loading : MonoBehaviour
{
    public Image loadingFill;
    public GameObject ShopScreen;

  
    private void Start()
    {
        loadingFill.fillAmount = 0f;
        Invoke("Delay", 0.1f);

    }
    void Delay()
    {
        StartCoroutine(loading());
    }
    IEnumerator loading()
    {
        while (loadingFill.fillAmount < 1) {
            loadingFill.fillAmount += (0.01f/1f);
        yield return null;
        }
        StartGame();
        yield return 0;
    }

    void StartGame()
    {
        ShopScreen.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
