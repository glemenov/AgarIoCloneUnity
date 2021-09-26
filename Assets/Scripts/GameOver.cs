using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    void Start()
    {
        GameHandler.GH.gameOver = this;
    }

    void DeathScreen()
    {
        // SHOW RETRY BUTTON
    }
}
