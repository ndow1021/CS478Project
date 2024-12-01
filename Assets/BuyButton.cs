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
    public int goldenCount = 0;
    public int goldenPrice = 1000;

    public void BuyFarm()
    {
        farmBought = true;
        farmCount += 1;
        farmPrice = 20 * (int)Math.Pow(2, 1 + farmCount);
        Debug.Log("Farm upgrade bought");
        UpdateUI();
    }

    public void BuyBanana()
    {
        bananaBought = true;
        bananaCount += 1;
        bananaPrice = 2000 * (int)Math.Pow(2, 1 + bananaCount);
        UpdateUI();
    }

    public void BuyMonkey()
    {
        monkeyBought = true;
        monkeyCount += 1;
        monkeyPrice = 1000 * (int)Math.Pow(2, 1 + monkeyCount);
        UpdateUI();
    }

    public void BuyGolden()
    {
        goldenBought = true;
        goldenCount += 1;
        goldenPrice = 200 * (int)Math.Pow(2, 1 + goldenCount);
        UpdateUI();
    }

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

    private void UpdateOnClicks()
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
        SceneManager.sceneLoaded += OnSceneLoaded;
        Debug.Log("The scene is loaded");
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        Debug.Log("The scene is unloaded");
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        FarmNumberOwned = GameObject.Find("FarmNumberOwned").GetComponent<TextMeshProUGUI>();
        FarmCost = GameObject.Find("FarmCost").GetComponent<TextMeshProUGUI>();

        BananaNumberOwned = GameObject.Find("OwnedBananaClickers").GetComponent<TextMeshProUGUI>();
        BananaCost = GameObject.Find("BananaClickerCost").GetComponent<TextMeshProUGUI>();

        MonkeyNumberOwned = GameObject.Find("OwnedMonkeyClickers").GetComponent<TextMeshProUGUI>();
        MonkeyCost = GameObject.Find("MonkeyHelperCost").GetComponent<TextMeshProUGUI>();

        GoldenNumberOwned = GameObject.Find("OwnedGoldenBanana").GetComponent<TextMeshProUGUI>();
        GoldenCost = GameObject.Find("GoldenBananaCost").GetComponent<TextMeshProUGUI>();

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
        Debug.Log("the UI has been updated");
    }

}
