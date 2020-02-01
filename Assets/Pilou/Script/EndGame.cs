using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    int i;
    int j;
    public Slider HpJ1;
    public Slider HpJ2;
    public GameObject BackgroundJ1;
    public GameObject BackgroundJ2;
    public AudioSource InGameMusic;
    public AudioSource EndGameMusic;
    public AudioSource DeathSound;
    public AudioSource WinSound;
    public GameObject HUD;
    public GameObject HUDCanva;
    public GameObject HUDendGame;
    public GameObject PlayersSprite;
    public GameObject Player1;
    public GameObject Player2;
    float time;


    private void Start()
    {
        i = 0;
        j = 0;
        time = 6;
    }

    // Update is called once per frame
    void Update()
    {
        if (HpJ1.value >= 30)
        {
            InGameMusic.Stop();
            if (j == 0)
            {
                j = 1;
                Player1.GetComponent<PlayerAnimationController>().FireDeath();
                DeathSound.Play();
            }
            if (time <= 3 && j == 1)
            {
                Player2.GetComponent<PlayerAnimationController>().FireVictory();
                WinSound.Play();
            }
            time -= Time.deltaTime;
            if (time <= 0 && i == 0)
            {
                i = 1;
                BackgroundJ2.SetActive(true);
                PlayersSprite.SetActive(false);
                EndGameMusic.Play();
                HUD.SetActive(false);
                HUDCanva.SetActive(false);
                HUDendGame.SetActive(true);
            }
        }
        else if (HpJ2.value >= 30)
        {
            InGameMusic.Stop();
            if (j == 0)
            {
                j = 1;
                Player2.GetComponent<PlayerAnimationController>().FireDeath();
                DeathSound.Play();
            }
            if (time <= 3 && j == 1)
            {
                Player1.GetComponent<PlayerAnimationController>().FireVictory();
                WinSound.Play();
            }
            time -= Time.deltaTime;
            if (time <= 0 && i == 0)
            {
                i = 1;
                BackgroundJ1.SetActive(true);
                PlayersSprite.SetActive(false);
                EndGameMusic.Play();
                HUD.SetActive(false);
                HUDCanva.SetActive(false);
                HUDendGame.SetActive(true);
            }
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
