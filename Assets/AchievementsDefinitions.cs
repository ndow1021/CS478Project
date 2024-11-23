using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;

public class AchievementsBase : MonoBehaviour
{
    public AchievementsBase instance;

    public string achievementName;
    public bool hasBeenUnlocked;
    protected string requiredGoal;  // String message telling user what they needa do to unlock

    public AchievementsBase() { instance = this; }

    public string GetRequiredGoal() { return requiredGoal; }
    public virtual void CheckForAchievementGoal() { }  // Override for methods
    public virtual void setAchievementStatusUnlocked() {
        try
        {
            instance.hasBeenUnlocked = true;
            Debug.Log("Achievement has been unlocked!: " + instance.achievementName);
            PlayerPrefs.SetInt(instance.achievementName, 1);
            PlayerPrefs.Save();
        }
        catch (NullReferenceException)
        {
            Debug.LogError("AchievementsBase.instance is null");
        }
    }

    public void sendUserMessage()
    {
        // Sends a message to the user in-game informing them of unlocked achievement.
        //
    }
}


public class FirstBananaClickAchievement : AchievementsBase {
    public FirstBananaClickAchievement()
    {
        if (instance == null) { instance = this; }
        achievementName = "FirstBananaClick";
        requiredGoal = "Click the Banana One Time!";
    }

    public override void CheckForAchievementGoal()
    {
        // Check if user score > 0
        //int userScore = PlayerPrefs.GetInt("CurrentScore", 0);
        
        //if (userData >= 1)  // Only have > for testing since I keep starting off with score 100 and such.
        //{
        //    setAchievementStatusUnlocked();
        //    // SendUserMessage();  // Sends pop-up message to Main Camera
        //}
    }
}

public class HundredBananaClicksAchievement : AchievementsBase
{
    public HundredBananaClicksAchievement()
    {
        instance = this;
        achievementName = "100 Banana Clicks";
        requiredGoal = "Click the Banana One Hundred times";
    }

    public override void CheckForAchievementGoal()
    {
        int userScore = PlayerPrefs.GetInt("CurrentScore");
        if (userScore == 100 && !this.hasBeenUnlocked) {
            setAchievementStatusUnlocked();
        }
    }
}

public class ThousandBananaClicksAchievement : AchievementsBase
{
    public ThousandBananaClicksAchievement()
    {
        instance = this;
        achievementName = "BananaBonanza";
        requiredGoal = "Click the banana 1000 times";
    }

    public override void CheckForAchievementGoal()
    {
        int userScore = PlayerPrefs.GetInt("CurrentScore");
        if (userScore == 1000 && !this.hasBeenUnlocked) {
            setAchievementStatusUnlocked();
        }
    }
}

public class FirstUpgradePurchaseAchievement : AchievementsBase
{
    public FirstUpgradePurchaseAchievement()
    {
        instance = this;
        achievementName = "First upgrade purchased";
        requiredGoal = "Purchase your first upgrade";
    }

    public override void CheckForAchievementGoal()
    {
        // Do this when shit's updated.
    }
}

public class FirstMonkeyHelperAchievement : AchievementsBase
{
    public FirstMonkeyHelperAchievement()
    {
        instance = this;
        achievementName = "MonkeyBusiness";
        requiredGoal = "Hire your first Monkey Helper";
    }

    public override void CheckForAchievementGoal()
    {
        /// Get the status if a user has a Monkey Helper and if they only have one.
        /// Or I guess I could just implement when the user purchases one and check if they already have one.
        setAchievementStatusUnlocked();
    }
}

public class PlantTenTreesAchievement : AchievementsBase
{
    public PlantTenTreesAchievement()
    {
        instance = this;
        achievementName = "TreeHugger";
        requiredGoal = "Plant 10 Banana Trees";
    }
    public override void CheckForAchievementGoal()
    {
        /// Check if they have planted 10 trees.
    }
}

public class LaunchBananaRocketFirstTimeAchievement : AchievementsBase
{
    public LaunchBananaRocketFirstTimeAchievement()
    {
        instance = this;
        achievementName = "RocketScientist";
        requiredGoal = "Launch the Banana Rocket for the first time";
    }

    public override void CheckForAchievementGoal()
    {
        /// Check if they've launched the banana rocket and if its their first time then stop checking
    }
}

public class UseGoldenBananaAchievement : AchievementsBase
{
    public UseGoldenBananaAchievement()
    {
        instance = this;
        achievementName = "GoldenTouch";
        requiredGoal = "Use a Golden Banana to double production";
    }
    public override void CheckForAchievementGoal()
    {
        /// ... 
    }
}

public class HundredThousandBananasAchievement : AchievementsBase
{
    public HundredThousandBananasAchievement()
    {
        instance = this;
        achievementName = "BananaTycoon";
        requiredGoal = "Reach 100,000 bananas in total";
    }
    public override void CheckForAchievementGoal()
    {
        /// ... 
    }
}

public class ObtainFiftyMonkeyHelpersAchievement : AchievementsBase
{
    public ObtainFiftyMonkeyHelpersAchievement()
    {
        instance = this;
        achievementName = "HelperArmy";
        requiredGoal = "Have 50 Monkey Helpers working for you";
    }

    public override void CheckForAchievementGoal()
    {
        /// .. 
    }
}

public class PlantHundredTreesAchievement : AchievementsBase
{
    public PlantHundredTreesAchievement()
    {
        instance = this;
        achievementName = "ForestOfBananas";
        requiredGoal = "Plant 100 Banana Trees";
    }

    public override void CheckForAchievementGoal()
    {
        /// Check if there is 100 banana trees planted
    }
}

public class LaunchBananaRocketFiftyTimesAchievement : AchievementsBase
{
    public LaunchBananaRocketFiftyTimesAchievement()
    {
        instance = this;
        achievementName = "RocketMaster";
        requiredGoal = "Launch the Banana Rocket 50 times";
    }

    public override void CheckForAchievementGoal()
    {
        /// ....
    }
}
