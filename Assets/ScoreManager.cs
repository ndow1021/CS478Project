using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    private int score = 0;
    private int scoreAdd = 1;

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
        score += scoreAdd;
        
        UpdateScoreText();
    }

    void CheckUpgrades()
    {
        if (BuyButton.Instance != null && BuyButton.Instance.farmBought)
        {
            scoreAdd = 2;
        }
    }

}
