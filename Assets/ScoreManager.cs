using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score = 0;

    void Start()
    {
        LoadScore();
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
        else
        {
            //Debug.LogError("Score text component not assigned.");
            scoreText = null;
        }
    }

    void LoadScore()
    {
        score = 0; //PlayerPrefs.GetInt("CurrentScore", 0);  // Loads score, default to 0 if not set
    }

    public void SaveScore()
    {
        PlayerPrefs.SetInt("CurrentScore", score);  // Saves score to PlayerPrefs
        PlayerPrefs.Save();  // Make sure to save PlayerPrefs
    }

    public void OnBananaClicked()
    {
        score += 1;
        UpdateScoreText();
    }

    void OnDisable()
    {
        SaveScore();  // Save the score when the game object is disabled or the scene is unloaded
    }

    void OnEnable()
    {
        LoadScore();  // Load the score when the game object is enabled
    }
}
