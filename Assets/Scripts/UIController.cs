using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public TMP_Text score_txt;

    // Visuals
    public GameObject death_screen;
    public Button retry_button;
    public Button main_menu;

    private float fixedDeltaTime;
    public bool pause;

    void Awake()
    {
        pause = false;
        this.fixedDeltaTime = Time.fixedDeltaTime;
        retry_button.onClick.AddListener(Retry);
        main_menu.onClick.AddListener(LoadMainMenu);
    }

    void Update()
    {
        score_txt.text = "Score: " + GameHandler.GH.score;
        GameHandler.GH.UImanager = this;

        if(!GameObject.Find("Food(Clone)"))
        {
            Debug.Log("YOU WIN");
            DeathScreen();
        }
    }

    public void DeathScreen()
    {
        if (pause)
        {
            death_screen.SetActive(true);
        }
        else
        {
            death_screen.SetActive(false);
        }

        //StopTime();
    }

    void Retry()
    {
        SceneManager.LoadScene("game");
    }

    void LoadMainMenu()
    {
        SceneManager.LoadSceneAsync("menu");
        //SceneManager.LoadScene("menu");
    }

    void StopTime()
    {
        if (Time.timeScale == 1.0f)
            Time.timeScale = 0f;
        else
            Time.timeScale = 1.0f;

        Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
    }
}
