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
        UpdateScoreText();
        CheckUpgrades();
    }

    void UpdateScoreText()
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

}
