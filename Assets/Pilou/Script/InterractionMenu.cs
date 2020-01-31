using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterractionMenu : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject DeckMenu;
    public GameObject HUDinGame;
    public GameObject HUDCArd;
    [Space]
    public AudioSource MenuMusic;
    public AudioSource InGameMusic;


    public void OnStartButton()
    {
        MainMenu.SetActive(false);
        MenuMusic.Stop();
        HUDinGame.SetActive(true);
        InGameMusic.Play();
        HUDCArd.SetActive(true);
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
