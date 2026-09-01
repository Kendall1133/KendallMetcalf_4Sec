using UnityEngine;

public class PopupManager_Logic : MonoBehaviour
{
    public int pointValue = 1;
    public float timeReward = 1;

    public static PopupManager_Logic Instance;
    public DifficultyManager_Logic difficultyManager;

    [Header("Timer Settings")]
    [SerializeField] private float duration = 5f; // Individual object lifetime
    public float timeRemaining;
    private bool timerIsRunning = false;

    private void OnMouseDown()
    {
        // 1. Only allow actions and new spawns if the main game timer hasn't run out
        if (Timer_Logic.Instance == null || Timer_Logic.Instance.timeRemaining <= 0) return;

        ScoreManager_Logic.Instance.ChangeScore(pointValue);
        Timer_Logic.Instance.AddTime(timeReward);
        DifficultyManager_Logic.Instance.SpawnRandomPrefab();
        Destroy(gameObject);
    }

    void Start()
    {
        timeRemaining = duration;
        timerIsRunning = true;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;

                // 2. Only spawn a replacement if the main game timer is still active
                if (Timer_Logic.Instance != null && Timer_Logic.Instance.timeRemaining > 0)
                {
                    DifficultyManager_Logic.Instance.SpawnRandomPrefab();
                }

                ObjectExpire();
            }
        }
    }

    void ObjectExpire()
    {
        Destroy(gameObject);
    }
}