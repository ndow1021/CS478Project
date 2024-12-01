using UnityEngine;
using TMPro;
using System;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score = 0;
    private int scoreAdd = 1;
    private int scoreMultiply = 1;

    public BuyButton buyButton;

    void Start()
    {
        LoadScore();
        UpdateScoreText();
        CheckUpgrades();
    }
    
    void UpdateScoreText() // Updates the score text in the main gamplay scene
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
        else
        {
            Debug.LogError("Score text component not assigned.");
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


    // Trigger event when the bananna is clicked it
    // increments the score by 1 multiplied or added
    // by the upgrades the user has
    public void OnBananaClicked() 
    {
        score = score + (scoreAdd * scoreMultiply);
        
        UpdateScoreText();
    }


    void CheckUpgrades()
    {
        if (BuyButton.Instance != null && BuyButton.Instance.farmBought)
        {
            scoreAdd = BuyButton.Instance.farmCount + 1;
        }

        if (BuyButton.Instance != null && BuyButton.Instance.bananaBought)
        {
            scoreMultiply = 2;
            scoreMultiply = (int)Math.Pow(scoreMultiply, BuyButton.Instance.bananaCount);
        }
    }


    void OnDisable()
    {
        SaveScore();  // Save the score when the game object is disabled or the scene is unloaded
    }

    void OnEnable()
    {
        LoadScore();  // Load the score when the game object is enabled
    }

    public void ResetScore()
    {
        score = 0; // Set score to zero
        UpdateScoreText(); // Update the score display
        SaveScore(); // Optionally save the reset score
    }


}
