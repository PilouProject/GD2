using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterractionMenu : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject DeckMenu;


    
    public void OnStartButton()
    {
        Debug.Log("Start");
    }

    public void OnDeckMenuButton()
    {
        MainMenu.SetActive(false);
        DeckMenu.SetActive(true);
    }

    public void OnBackButton()
    {
        DeckMenu.SetActive(false);
        MainMenu.SetActive(true);
    }

    public void OnQuitButton()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
