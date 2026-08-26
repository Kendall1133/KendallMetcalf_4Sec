using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager_Logic : MonoBehaviour
{
    public int currentScore;

    public TMP_Text finalScoreText;
    public TMP_Text highScoreText;

    public static ScoreManager_Logic Instance;
    public TextMeshProUGUI scoreText;

    void Awake()
    {
        Instance = this;
    }

    public void ChangeScore(int points) //Updates score
    {
        currentScore += points; //Adds new points to total
        scoreText.text = currentScore.ToString(); //Updates UI
    }

    public void HighScoreUpdate()
    {
        //Is there already a highscore?
        if(PlayerPrefs.HasKey("SavedHighScore"))
        {
            //Is the new score higher than the saved one?
            if(currentScore > PlayerPrefs.GetInt("SavedHighScore"))
            {
                //Set a new high score
                PlayerPrefs.SetInt("SavedHighScore", currentScore);
            }
        }
        else
        {
            //If there is no highscore...set it
            PlayerPrefs.SetInt("SavedHighScore", currentScore);
        }

        //Update TMP

        finalScoreText.text = currentScore.ToString();
        highScoreText.text = PlayerPrefs.GetInt("SavedHighScore").ToString();
    }
}
