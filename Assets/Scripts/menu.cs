using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    // Main Menu
    public Button start_button;
    public Button options_button;

    // Options
    public Button mute_button;
    public Button back_button;

    public Button scroll_left;
    public Button scroll_right;

    // UI
    public GameObject mainMenu;
    public GameObject options;
    public Slider volume_slider;

    // Color Display
    public RawImage display;
    private List<Color> colors = new List<Color>();
    private int color_selection;

    void Start()
    {
        // Menu Buttons
        start_button.onClick.AddListener(PlayingScene);
        options_button.onClick.AddListener(OptionsScene);

        // Option Buttons
        mute_button.onClick.AddListener(Mute);
        back_button.onClick.AddListener(LoadMenu);

        scroll_left.onClick.AddListener(PreviousOption);
        scroll_right.onClick.AddListener(NextOption);

        // MainMenu audio
        GameHandler.GH.mute = false;
        GameHandler.GH.audioMan.Play("MainMenu");

        LoadColors();
        
        GameHandler.GH.player_color = display.color;
    }

    void Update()
    {
        // Synchronize the selected options with overall parameters
        GameHandler.GH.overall_volume = volume_slider.value;
        GameHandler.GH.audioMan.ChangeVolume("MainMenu", GameHandler.GH.overall_volume);
    }

    // Load "Game Scene"
    void PlayingScene()
    {
        SceneManager.LoadScene("game");
    }

    // Change appearance on the screen to show options
    void OptionsScene()
    {
        mainMenu.SetActive(false);
        options.SetActive(true);
    }

    // The Options "Back" button functionallity 
    void LoadMenu()
    {
        mainMenu.SetActive(true);
        options.SetActive(false);

        GameHandler.GH.player_color = display.color;
    }

    // Mute button
    void Mute()
    {
        if(!GameHandler.GH.mute)
        {
            GameHandler.GH.mute = true;
            GameHandler.GH.audioMan.Stop("MainMenu");
        }
        else
        {
            GameHandler.GH.mute = false;
            GameHandler.GH.audioMan.Play("MainMenu");
        }
    }

    // Color selection
    #region Color Selection

    // Cycle colours backwards
    void PreviousOption()
    {
        color_selection--;

        if (color_selection < 0)
            color_selection = colors.Count - 1;

        display.color = colors[color_selection];
    }

    // Cycle colours forward
    void NextOption()
    {
        color_selection++;

        if (color_selection >= colors.Count)
            color_selection = 0;


        display.color = colors[color_selection];
    }

    // Fill the array with colors to choose
    void LoadColors()
    {
        colors.Add(Color.white);
        colors.Add(Color.black);
        colors.Add(Color.yellow);
        colors.Add(Color.red);
    }

    #endregion
}
