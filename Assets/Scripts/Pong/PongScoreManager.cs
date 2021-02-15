using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PongScoreManager : MonoBehaviour
{
    #region Variables

    [Header("UI")]
    public TextMeshProUGUI scoreUI;
    public GameObject pongVictoryUI;
    public GameObject pongLoseUI;

    [Header("Game Parameters")]
    public int scoreToBeat = 15;

    [Header("Booleans")]
    public bool displayVictoryUI = false;

    [Header("Values Checker")]
    public int currentScore = 15;
    
    #endregion

    void Start()
    {
        currentScore = scoreToBeat;
        if(scoreToBeat <= 1)
        {
            scoreUI.text = scoreToBeat + " touch left";
        }
        else scoreUI.text = scoreToBeat + " touches left";
    }

    public void ResetScore()
    {
        displayVictoryUI = false;
        pongVictoryUI.SetActive(false);
        pongLoseUI.SetActive(false);
        
        currentScore = scoreToBeat;
        if (scoreToBeat <= 1)
        {
            scoreUI.text = scoreToBeat + " touch left";
        }
        else scoreUI.text = scoreToBeat + " touches left";
    }

    public void UpdateScore()
    {
        currentScore--;
        if (currentScore <= 1)
        {
            scoreUI.text = currentScore + " touch left";
        }
        else scoreUI.text = currentScore + " touches left";

        if(currentScore == 0)
        {
            displayVictoryUI = true;
            pongVictoryUI.SetActive(true);
        }
    }
}
