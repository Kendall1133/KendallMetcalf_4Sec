using UnityEngine;

public class PopupManager_Logic : MonoBehaviour
{
    public int pointValue = 1;
    public float timeReward = 1;

    public DifficultyManager_Logic difficultyManager;

    [Header ("Timer Settings")]
    [SerializeField] private float duration = 5f; // Timer length in seconds
    private float timeRemaining;
    private bool timerIsRunning = false;

    private void OnMouseDown()
    {
        ScoreManager_Logic.Instance.ChangeScore(pointValue);
        Timer_Logic.Instance.AddTime(timeReward);
        DifficultyManager_Logic.Instance.SpawnRandomPrefab();
        Destroy(gameObject);
    }
    void Start()
    {
        // Initialize and start the timer
        timeRemaining = duration;
        timerIsRunning = true;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                // Subtract the time passed since the last frame
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                DifficultyManager_Logic.Instance.SpawnRandomPrefab();
                ObjectExpire();
            }
        }
    }

    void ObjectExpire()
    {
        Destroy(gameObject);
    }

}
