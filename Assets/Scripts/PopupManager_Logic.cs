using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class PopupManager_Logic : MonoBehaviour
{
    public int pointValue = 1; //Controls the value to be added to the ScoreManager_Logic script
    public int timeReward = 1; //Controls the value to be added to the Timer_logic script

    private float timeRemaining;
    private bool isInitialized = false;

    public ScoreManager_Logic scoreManager; //References the ScoreManager script
    public Timer_Logic timer; //References the Timer script
    public DifficultyManager_Logic difficultyManager; //References the Difficulty script


    private void OnMouseDown()
    {
        ScoreManager_Logic.Instance.ChangeScore(pointValue);
        Timer_Logic.Instance.AddTime(timeReward);
        DifficultyManager_Logic.Instance.OnObjectClicked();
        Destroy(gameObject); 
    }

    // Called by the GameManager right after spawning
    public void Initialize(float lifetime)
    {
        timeRemaining = lifetime;
        isInitialized = true;
    }

    private void Update()
    {
        if (!isInitialized) return;

        // Countdown over time
        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0)
        {
            GameOverOrMiss();
        }
    }

    private void GameOverOrMiss()
    {
        Debug.Log("Miss!");
        Destroy(gameObject);
    }
}
