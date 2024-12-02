using UnityEngine;
using TMPro;
using System;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI goldenBananaCount;
    public TextMeshProUGUI goldenTimer;
    private int score = 0;
    private int scoreAdd = 1;
    private int scoreMultiply = 1;
    private int scorePerSecond = 0;
    private float timeReset = 0.0f;
    private float goldenTime = 0.0f;
    private bool goldenActive = false;

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
            //Debug.LogError("Score text component not assigned.");
        }
    }

    void LoadScore()
    {
        score = PlayerPrefs.GetInt("CurrentScore", 0);  // Loads score, default to 0 if not set
        Debug.Log("Loaded score " + " in gameplay");
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
        if (goldenActive == false)
        {
            score = score + (scoreAdd * scoreMultiply);
        }
        else
        {
            score = score + (scoreAdd * scoreMultiply * 2); //if golden is active it will multiply by 2
        }
        SaveScore();
        UpdateScoreText();
    }


    void CheckUpgrades() //if the shop has been visted and these updgrades have been bought they will activate
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

        if (BuyButton.Instance != null && BuyButton.Instance.monkeyBought)
        {
            scorePerSecond = BuyButton.Instance.monkeyCount;
        }

        if (BuyButton.Instance != null && BuyButton.Instance.goldenBought) 
        {
            goldenBananaCount.text = "Golden Bananas: " + BuyButton.Instance.currentGolden;
        }


    }

    void Update()
    {
        timeReset += Time.deltaTime;
        if (BuyButton.Instance != null && BuyButton.Instance.monkeyBought && timeReset >= 1.0f)       //it counts up to a second then resets 
        {
            score += scorePerSecond; //When a second passes it will add to the score based on how many monkey helpers are owned
            SaveScore();
            timeReset -= 1.0f;
            UpdateScoreText();
        }
        if (goldenTime > 0.0f) //when golden is active there is text that will countdown until its over
        {
             goldenActive = true;
             goldenTime -= Time.deltaTime;
             goldenTimer.text = "Time left: " + goldenTime;
        }
        
                
    }
                                     
    void OnDisable()            
    {     //prevents the banana (which for some reason doesnt get the score updated on itself) from also saving the score                           
        if (gameObject.tag == "BananaTag") //which lead to a 50/50 chance of the score being reset back to whatever it was 
        {                                  //when the gameplay scene was loaded
            Debug.Log("Banana OnDisable() skipped"); 
            return;
        }

        SaveScore();  // Save the score when the game object is disabled or the scene is unloaded
        Debug.Log("score in gameplay saved as " + score);
        Debug.Log("OnDisable called by " + gameObject.name);
    }

    void OnEnable()
    {
        LoadScore();  // Load the score when the game object is enabled
        Debug.Log("score loaded in game");
    }

    public void ResetScore()
    {
        score = 0; // Set score to zero
        UpdateScoreText(); // Update the score display
        SaveScore(); // Optionally save the reset score
    }

    public void GoldenBananaButton()
    {
        if(BuyButton.Instance.currentGolden > 0) //if a golden banana is owned you can click the button to start a 2x mult for 60 seconds
        {
            goldenTime += 60.0f;
            BuyButton.Instance.currentGolden -= 1;
            goldenBananaCount.text = "Golden Bananas: " + BuyButton.Instance.currentGolden;
        }
        else //if the golden count is zero the text will change to this when the button is pressed
        {
            goldenBananaCount.text = "No Golden Owned";
        }

    }
}
