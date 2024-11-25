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

    public AchievementsDefinitionsClass achievementsObject = new();

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
            Debug.Log("Score text component not assigned.");
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

        CheckAchievements();

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

    void CheckAchievements() {
        try {
            bool firstClickHasBeenUnlocked = achievementsObject.achievementsDictionary["FirstClickAchievement"].Item2;
            bool hundredClicksHasBeenUnlocked = achievementsObject.achievementsDictionary["HundredClicksAchievement"].Item2;
            bool bananaBonanzaHasBeenUnlocked = achievementsObject.achievementsDictionary["BananaBonanzaAchievement"].Item2;
            bool hundredThousandClicksHasBeenUnlocked = achievementsObject.achievementsDictionary["HundredThousandBananasAchievement"].Item2;

            if (!firstClickHasBeenUnlocked) {
                if (score >= 1) {
                    achievementsObject.setAchievementStatusUnlocked("FirstClickAchievement");
                }
            }
            if (!hundredClicksHasBeenUnlocked) {
                if (score >= 100) {
                    achievementsObject.setAchievementStatusUnlocked("HundredClicksAchievement");
                }
            }
            if (!bananaBonanzaHasBeenUnlocked) {
                if (score >= 1000) {
                    achievementsObject.setAchievementStatusUnlocked("BananaBonanzaAchievement");
                }
            }
            if (!hundredThousandClicksHasBeenUnlocked) {
                if (score == 100000) {
                    achievementsObject.setAchievementStatusUnlocked("HundredThousandBananasAchievement");
                }
            }
        }
        catch (NullReferenceException e) {
            Debug.Log(e.Message + ": ScoreManager.cs in CheckAchievements()");
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
