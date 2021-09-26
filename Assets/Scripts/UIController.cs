using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    public TMP_Text score_txt;

    void Update()
    {
        score_txt.text = "Score: " + GameHandler.GH.score;
    }
}
