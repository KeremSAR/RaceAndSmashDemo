using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject MainScreen;
    public GameObject SettingsScreen;
    public GameObject CharacterScreen;
    public GameObject Shop;
    

   public void DisableAll()
    {
        MainScreen.SetActive(false);
        CharacterScreen.SetActive(false);
        Shop.SetActive(false);
    }


    public void Show_MainScreen()
    {
        DisableAll();
        MainScreen.SetActive(true);
    }

    public void Show_Settings()
    {
        SettingsScreen.SetActive(true);
    }
    public void Hide_Settings()
    {
        SettingsScreen.SetActive(false);
    }

    public void Show_CharacterScreen()
    {
        DisableAll();
        CharacterScreen.SetActive(true);
    }
    
    public void Show_Shop()
    {
        DisableAll();
        Shop.SetActive(true);
    }
   
}
