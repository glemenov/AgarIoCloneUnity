using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameHandler
{
    public int score;
    //public int enemies;

    public AudioManager audioMan;
    public GameOver gameOver;
    public float overall_volume;

    public Color player_color;

    #region Singleton

    private static GameHandler _GH;

    public static GameHandler GH
    {
        get
        {
            if(_GH == null) { _GH = new GameHandler(); }

            return _GH;
        }

        set
        {
            if (value != null) { _GH = value; }
        }
    }

    #endregion
}
