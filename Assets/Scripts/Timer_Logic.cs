using TMPro;
using UnityEngine;

public class Timer_Logic : MonoBehaviour
{
    public static Timer_Logic Instance;
    public ScoreManager_Logic scoreManager;
    private bool isTimerRunning = true;

    [Header("Timer Settings")]
    public float timeRemaining = 4f; //Total Time in seconds
    public bool timerIsActive = true;

    [Header("UI Elements")]
    public TMP_Text timerText; //Reference to timer text component

    void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (timerIsActive)
        {
            if (timeRemaining > 0)
            { 
                //Subtract the time passed since the last frame
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsActive = false;
                DisplayTime(timeRemaining);
                TimerEnded();
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        // Add a safety check to prevent negative values from calculating
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        // Calculate minutes, seconds, and milliseconds
        // "%" is a Modulo Operator which calculates the remainder left over after division instead of performing the division
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float milliseconds = Mathf.FloorToInt((timeToDisplay % 60) * 100f);

        // Format the string as MM:SS (e.g., 05:09)
        timerText.text = string.Format("{0:00}:{1:00}.{2:000}", minutes, seconds, milliseconds);
    }
    public void AddTime(float amountToAdd)
    {
        if (isTimerRunning)
        {
            timeRemaining += amountToAdd;
            DisplayTime(timeRemaining);
        }
    }

    void TimerEnded()
    {
        scoreManager.HighScoreUpdate();
    }
}
