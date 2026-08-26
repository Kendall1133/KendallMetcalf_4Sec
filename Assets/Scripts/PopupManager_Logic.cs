using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class PopupManager_Logic : MonoBehaviour
{
    public int pointValue = 1; //Controls the value to be added to the ScoreManager_Logic script
    public int timeReward = 1; //Controls the value to be added to the Timer_logic script

    public float minX = -5f;
    public float maxX = 5f;
    public float minY = -2f;
    public float maxY = 2f;

    public ScoreManager_Logic scoreManager; //References the ScoreManager script
    public Timer_Logic timer; //References the Timer script

    void Start()
    {
        MoveToRandomPosition();
    }

    public void MoveToRandomPosition()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        transform.position = new Vector3(randomX, randomY);
    }
    private void OnMouseDown()
    {
        ScoreManager_Logic.Instance.ChangeScore(pointValue);
        Timer_Logic.Instance.AddTime(timeReward);
        Destroy(gameObject); 
    }
}
