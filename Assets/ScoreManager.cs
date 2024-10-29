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
        if (buyButton.farmBought == true)
        {
            scoreAdd = 2;
        }
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
}
