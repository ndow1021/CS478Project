using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class BuyButton : MonoBehaviour
{
    [SerializeField] private returnButton returnButtonScript;

    private int score = 0;
    public TextMeshProUGUI ScoreCount;
    public TextMeshProUGUI ShopkeepText;

    public TextMeshProUGUI FarmNumberOwned;
    public TextMeshProUGUI FarmCost;
    public bool farmBought = false;
    public int farmCount = 0;
    public int farmPrice = 20;

    public TextMeshProUGUI BananaNumberOwned;
    public TextMeshProUGUI BananaCost;
    public bool bananaBought = false;
    public int bananaCount = 0;
    public int bananaPrice = 2000;

    public TextMeshProUGUI MonkeyNumberOwned;
    public TextMeshProUGUI MonkeyCost;
    public bool monkeyBought = false;
    public int monkeyCount = 0;
    public int monkeyPrice = 200;

    public TextMeshProUGUI GoldenNumberOwned;
    public TextMeshProUGUI GoldenCost;
    public bool goldenBought = false;
    public int goldenCount = 0;  //this will show how many have been bought in total
    public int goldenPrice = 1000;
    public int currentGolden = 0; //this number will be subtracted from when the player wants to use thier golden banana

    void Start()
    {
        ShopkeepText.text = "Welcome to my shop!";
        //Debug.Log("scene started");
    }
    

    //the upgrade will be set to true, and the upgrade cost will be changed based on the formula
    public void BuyFarm()
    {
        if (score > farmPrice)
        {
            score -= farmPrice;
            farmBought = true;
            farmCount += 1;
            farmPrice = 20 * (int)Math.Pow(2, 1 + farmCount);
            UpdateUI();
            SaveScore();
            
            ShopkeepText.text = "The farm is always a good option.";
        }
        else
        {
            ShopkeepText.text = "You need more bananas for that!";
        }
        
    }

    public void BuyBanana()
    {
        if (score > bananaPrice)
        {
            score -= bananaPrice;
            bananaBought = true;
            bananaCount += 1;
            bananaPrice = 2000 * (int)Math.Pow(2, 1 + bananaCount);
            UpdateUI();
            SaveScore();
            ShopkeepText.text = "These are the best bananas in town!";
        }
        else
        {
            ShopkeepText.text = "I can't just give those out for free!";
        }
        
    }

    public void BuyMonkey()
    {
        if (score > monkeyPrice) 
        { 
            score -= monkeyPrice;
            monkeyBought = true;
            monkeyCount += 1;
            monkeyPrice = 200 * (int)Math.Pow(2, 1 + monkeyCount);
            UpdateUI();
            SaveScore();
            ShopkeepText.text = "Always great to have some help!";
        }
        else
        {
            ShopkeepText.text = "You need more bananas to pay them!";
        }
        
    }

    public void BuyGolden()
    {
        if (score > goldenPrice)
        {
            score -= goldenPrice;
            goldenBought = true;
            goldenCount += 1;
            currentGolden += 1;
            goldenPrice = 1000 * (int)Math.Pow(2, 1 + goldenCount);
            UpdateUI();
            SaveScore();
            ShopkeepText.text = "Use it wisely, they are hard to come by.";
        }
        else
        {
            ShopkeepText.text = "Are you trying to rob me?!?!";
        }
        
    }
    
    //makes it so the numbers in the shop will be remembered and accessable in the gameplay scene
    public static BuyButton Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
           

        } else if (Instance != this)
        {
            UpdateOnClicks();
            Destroy(gameObject);
         
        }
        
    }

    private void UpdateOnClicks() //when the shop is returned to it was deleting the on click command so this readds them
    {
        Button FarmButton = GameObject.Find("FarmButton").GetComponent<Button>();
        FarmButton.onClick.AddListener(Instance.BuyFarm);

        Button BananaClickerButton = GameObject.Find("Banana Clicker Button").GetComponent<Button>();
        BananaClickerButton.onClick.AddListener(Instance.BuyBanana);

        Button MonkeyHelperButton = GameObject.Find("MonkeyHelperButton").GetComponent<Button>();
        MonkeyHelperButton.onClick.AddListener(Instance.BuyMonkey);

        Button GoldenBananaButton = GameObject.Find("GoldenBananaButton").GetComponent<Button>();
        GoldenBananaButton.onClick.AddListener(Instance.BuyGolden);

        Button ReturnButton = GameObject.Find("ReturnButton").GetComponent<Button>();
        ReturnButton.onClick.AddListener(returnButtonScript.ReturnButton);
        
    }

    private void OnEnable()
    {

        Debug.Log("The scene is loaded");
        SceneManager.sceneLoaded += OnSceneLoaded;
        
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) //The text from text mesh pro was also being unlinked so this relinks them
    {
        

        FarmNumberOwned = GameObject.Find("FarmNumberOwned").GetComponent<TextMeshProUGUI>();
        FarmCost = GameObject.Find("FarmCost").GetComponent<TextMeshProUGUI>();

        BananaNumberOwned = GameObject.Find("OwnedBananaClickers").GetComponent<TextMeshProUGUI>();
        BananaCost = GameObject.Find("BananaClickerCost").GetComponent<TextMeshProUGUI>();

        MonkeyNumberOwned = GameObject.Find("OwnedMonkeyClickers").GetComponent<TextMeshProUGUI>();
        MonkeyCost = GameObject.Find("MonkeyHelperCost").GetComponent<TextMeshProUGUI>();

        GoldenNumberOwned = GameObject.Find("OwnedGoldenBanana").GetComponent<TextMeshProUGUI>();
        GoldenCost = GameObject.Find("GoldenBananaCost").GetComponent<TextMeshProUGUI>();

        ScoreCount = GameObject.Find("CurrentScore").GetComponent<TextMeshProUGUI>();
        ShopkeepText = GameObject.Find("MrShopkeeperText").GetComponent<TextMeshProUGUI>();

        SetScore();
        SetScoreText();
        UpdateUI();
    }

    public void UpdateUI()
    {
        if (FarmNumberOwned != null) FarmNumberOwned.text = "Number Owned: " + farmCount;
        if (FarmCost != null) FarmCost.text = "Cost: " + farmPrice + " Bananas";

        if (BananaNumberOwned != null) BananaNumberOwned.text = "Number Owned: " + bananaCount;
        if (BananaCost != null) BananaCost.text = "Cost: " + bananaPrice + " Bananas";

        if (MonkeyNumberOwned != null) MonkeyNumberOwned.text = "Number Owned: " + monkeyCount;
        if (MonkeyCost != null) MonkeyCost.text = "Cost: " + monkeyPrice + " Bananas";

        if (GoldenNumberOwned != null) GoldenNumberOwned.text = "Number Owned: " + goldenCount;
        if (GoldenCost != null) GoldenCost.text = "Cost: " + goldenPrice + " Bananas";

        ScoreCount.text = "Bananas: " + score;
        Debug.Log("the UI has been updated");
    }

    public void SaveScore()
    {
        PlayerPrefs.SetInt("CurrentScore", score);  // Saves score to PlayerPrefs
        PlayerPrefs.Save();  // Make sure to save PlayerPrefs
        Debug.Log("score saved in shop as " + score);
    }

    public void SetScoreText()
    {
        ScoreCount.text = "Bananas: " + score;
    }

    public void SetScore()
    {
        score = PlayerPrefs.GetInt("CurrentScore", 0); // Loads score, default to 0 if not set
        ScoreCount.text = "Bananas: " + score;
        Debug.Log("score in shop loaded as " + score);
        //Debug.Log("score loaded in shop");
    }

    

}
