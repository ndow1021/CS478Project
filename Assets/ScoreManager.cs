using UnityEngine;
using TMPro;
using System;
using System.Linq.Expressions;
using UnityEngine.Scripting;

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
            //Debug.Log("Score text component not assigned.");  // Change back to LogError before pushing.
        }
    }

    void LoadScore()
    {
        score = PlayerPrefs.GetInt("CurrentScore", 0);  // Loads score, default to 0 if not set
    }

    public void SaveScore()
    {
        PlayerPrefs.SetInt("CurrentScore", score);  // Saves score to PlayerPrefs
        PlayerPrefs.Save();  // Make sure to save PlayerPrefs
    }

    public void OnBananaClicked()
    {
        score += 1;

        FirstBananaClickAchievement firstBananaClickAchievementInstance = new FirstBananaClickAchievement();
        HundredBananaClicksAchievement hundredBananaClicksAchievementInstance = new HundredBananaClicksAchievement();
        ThousandBananaClicksAchievement thousandBananaClicksAchievementInstance = new ThousandBananaClicksAchievement();

        if (!firstBananaClickAchievementInstance.hasBeenUnlocked)
        {
            // need to fix CheckAchievementGoal methods
            if (score >= 1) { firstBananaClickAchievementInstance.setAchievementStatusUnlocked(); }
        }
        if (!hundredBananaClicksAchievementInstance.hasBeenUnlocked)
        {
            if (score >= 100) { hundredBananaClicksAchievementInstance.setAchievementStatusUnlocked(); }
        }
        if (!thousandBananaClicksAchievementInstance.hasBeenUnlocked)
        {
            if (score >= 1000) { thousandBananaClicksAchievementInstance.setAchievementStatusUnlocked(); }
        }

        
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
