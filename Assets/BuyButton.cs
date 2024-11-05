using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BuyButton : MonoBehaviour
{
    public TextMeshProUGUI FarmNumberOwned;
    public bool farmBought = false;
    public int farmCount = 0;

    public TextMeshProUGUI BananaNumberOwned;
    public bool bananaBought = false;
    public int bananaCount = 0;

    public TextMeshProUGUI MonkeyNumberOwned;
    public bool monkeyBought = false;
    public int monkeyCount = 0;

    public TextMeshProUGUI GoldenNumberOwned;
    public bool goldenBought = false;
    public int goldenCount = 0;

    public void BuyFarm()
    {
        farmBought = true;
        farmCount += 1;
        FarmNumberOwned.text = "Number Owned: " + farmCount;
    }

    public void BuyBanana()
    {
        bananaBought = true;
        bananaCount += 1;
        BananaNumberOwned.text = "Number Owned: " + bananaCount;
    }

    public void BuyMonkey()
    {
        monkeyBought = true;
        monkeyCount += 1;
        MonkeyNumberOwned.text = "Number Owned: " + monkeyCount;
    }

    public void BuyGolden()
    {
        goldenBought = true;
        goldenCount += 1;
        GoldenNumberOwned.text = "Number Owned: " + goldenCount;
    }

    public static BuyButton Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
