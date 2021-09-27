using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Visuals
    public GameObject death_screen;
    public Button retry_button;

    void Start()
    {
        GameHandler.GH.gameOver = this;
        retry_button.onClick.AddListener(Retry);
    }

    public void DeathScreen()
    {
        death_screen.SetActive(true);
    }

    void Retry()
    {
        death_screen.SetActive(false);
        SceneManager.LoadScene("game");
    }
}
