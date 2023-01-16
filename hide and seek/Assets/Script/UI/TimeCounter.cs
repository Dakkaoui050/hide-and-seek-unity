using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeCounter : MonoBehaviour
{
    public float timeLeft = 600.0f;
    public TextMeshProUGUI timerText;

    void Update()
    {
        timeLeft -= Time.deltaTime; //normal time speed
        int minutes = (int)timeLeft / 60; // time in minuts
        int seconds = (int)timeLeft % 60; // time in seconds
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds); // how it look in de display
        
        if (timeLeft < 0)
        {
            // do something when the time is up
        }
    }
}
