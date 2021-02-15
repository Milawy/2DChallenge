using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    public TextMeshProUGUI CountDownTimerUI;
    public float timeRemaining = 10f;

    void Update()
    {
        if (timeRemaining > 0f)
        {
            timeRemaining -= Time.deltaTime;
            CountDownTimerUI.text = "Remaining time : " + timeRemaining + "s";
        }
        else
        {
            //Win screen because he survived
        }
    }

    public void ResetTimer()
    {

    }
}
