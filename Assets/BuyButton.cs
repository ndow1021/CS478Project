using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BuyButton : MonoBehaviour
{
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

    public AchievementsDefinitionsClass achievementsObject = new AchievementsDefinitionsClass();

    public void BuyFarm()
    {
        farmBought = true;
        farmCount += 1;
        FarmNumberOwned.text = "Number Owned: " + farmCount;
        farmPrice = (int)Math.Pow(20,1 + farmCount);
        FarmCost.text = "Cost: " + farmPrice + " Bananas";

        bool plantTenTreesHasBeenUnlocked = achievementsObject.achievementsDictionary["PlantTenTreesAchievement"].Item2;
        bool plantHundredTreesHasBeenUnlocked = achievementsObject.achievementsDictionary["PlantHundredTreesAchievement"].Item2;
        if (!plantTenTreesHasBeenUnlocked) {
            if (farmCount == 1) {
                achievementsObject.setAchievementStatusUnlocked("PlantTenTreesAchievement");
            }
        }

        if (!plantHundredTreesHasBeenUnlocked) {
            if (farmCount == 100) {
                achievementsObject.setAchievementStatusUnlocked("PlantHundredTreesAchievement");
            }
        }
    }

    public void BuyBanana()
    {
        bananaBought = true;
        bananaCount += 1;
        BananaNumberOwned.text = "Number Owned: " + bananaCount;

        bool firstBananaRocketHasBeenUnlocked = achievementsObject.achievementsDictionary["LaunchBananaRocketFirstTimeAchievement"].Item2;
        bool fiftyBananaRocketsHasBeenUnlocked = achievementsObject.achievementsDictionary["LaunchBananaRocketFiftyTimesAchievement"].Item2;

        if (!firstBananaRocketHasBeenUnlocked) {
            if (bananaCount == 1) {
                achievementsObject.setAchievementStatusUnlocked("LaunchBananaRocketFirstTimeAchievement");
            }
        }

        if (!fiftyBananaRocketsHasBeenUnlocked) {
            if (bananaCount == 50) {
                achievementsObject.setAchievementStatusUnlocked("LaunchBananaRocketFiftyTimesAchievement");
            }
        }
    }

    public void BuyMonkey()
    {
        monkeyBought = true;
        monkeyCount += 1;
        MonkeyNumberOwned.text = "Number Owned: " + monkeyCount;

        bool firstMonkeyHelperHasBeenUnlocked = achievementsObject.achievementsDictionary["FirstMonkeyHelperAchievement"].Item2;
        bool helperArmyHasBeenUnlocked = achievementsObject.achievementsDictionary["ObtainFiftyMonkeyHelpersAchievement"].Item2;

        if (!firstMonkeyHelperHasBeenUnlocked) {
            if (monkeyCount == 1) {
                achievementsObject.setAchievementStatusUnlocked("FirstMonkeyHelperAchievement");
            }
        }

        if (!helperArmyHasBeenUnlocked) {
            if (monkeyCount == 50) {
                achievementsObject.setAchievementStatusUnlocked("ObtainFiftyMonkeyHelpersAchievement");
            }
        }
    }

    public void BuyGolden()

    {
        goldenBought = true;
        goldenCount += 1;
        GoldenNumberOwned.text = "Number Owned: " + goldenCount;

        bool goldenBananaHasBeenUnlocked = achievementsObject.achievementsDictionary["UseGoldenBananaAchievement"].Item2;

        if (!goldenBananaHasBeenUnlocked) {
            if (goldenCount == 1) {
                achievementsObject.setAchievementStatusUnlocked("UseGoldenBananaAchievement");
            }
        }
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
