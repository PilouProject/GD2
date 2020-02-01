using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    int i;
    public Slider HpJ1;
    public Slider HpJ2;
    public GameObject BackgroundJ1;
    public GameObject BackgroundJ2;
    public AudioSource InGameMusic;
    public AudioSource EndGameMusic;
    public GameObject HUD;
    public GameObject HUDCanva;
    public GameObject HUDendGame;
    public GameObject PlayersSprite;


    private void Start()
    {
        i = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (HpJ1.value >= 30 && i == 0)
        {
            i = 1;
            BackgroundJ2.SetActive(true);
            PlayersSprite.SetActive(false);
            InGameMusic.Stop();
            EndGameMusic.Play();
            HUD.SetActive(false);
            HUDCanva.SetActive(false);
            HUDendGame.SetActive(true);
        }

        if (HpJ2.value >= 30 && i == 0)
        {
            i = 1;
            BackgroundJ1.SetActive(true);
            PlayersSprite.SetActive(false);
            InGameMusic.Stop();
            EndGameMusic.Play();
            HUD.SetActive(false);
            HUDCanva.SetActive(false);
            HUDendGame.SetActive(true);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
