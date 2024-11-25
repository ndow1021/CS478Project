using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;
using TMPro;
using System.Threading;

public class AchievementsDefinitionsClass
{
    /// <summary>
    /// 
    /// Dictionary Structure:
    ///     Achievement name (Key): (achievement display name, has been unlocked status, required goal to achieve the achievement)
    /// 
    /// </summary>
    public Dictionary<string, (string, bool, string)> achievementsDictionary = new Dictionary<string, (string, bool, string)>();

    public AchievementsDefinitionsClass() {

        achievementsDictionary.Add("FirstClickAchievement",
            ("First Click", false, "Click the Banana One Time!"));
        
        achievementsDictionary.Add("HundredClicksAchievement",
            ("Hundred Clicks", false, "100 Banana Clicks"));
        
        achievementsDictionary.Add("BananaBonanzaAchievement",
            ("Banana Bonanza", false, "Click the banana 1000 times"));
        
        achievementsDictionary.Add("FirstUpgradeAchievement",
            ("First Upgrade", false, "Purchase your first upgrade"));
        
        achievementsDictionary.Add("FirstMonkeyHelperAchievement",
            ("Monkey Business", false, "Hire your first Monkey Helper"));
        
        achievementsDictionary.Add("PlantTenTreesAchievement",
            ("Tree Hugger", false, "Plant 10 Banana Trees"));
        
        achievementsDictionary.Add("LaunchBananaRocketFirstTimeAchievement",
            ("Rocket Scientist", false, "Launch the Banana Rocket for the first time"));
        
        achievementsDictionary.Add("UseGoldenBananaAchievement",
            ("Golden Touch", false, "Use a Golden Banana to double production"));
        
        achievementsDictionary.Add("HundredThousandBananasAchievement",
            ("Banana Tycoon", false, "Reach 100,000 bananas in total"));
        
        achievementsDictionary.Add("ObtainFiftyMonkeyHelpersAchievement",
            ("Helper Army", false, "Have 50 Monkey Helpers working for you"));
        
        achievementsDictionary.Add("PlantHundredTreesAchievement",
            ("Forest Of Bananas", false, "Plant 100 Banana Trees"));

        achievementsDictionary.Add("LaunchBananaRocketFiftyTimesAchievement",
            ("Rocket Master", false, "Launch the Banana Rocket 50 times"));
    }

    public void setAchievementStatusUnlocked(string achievementKeyName) {
        /// Pull in the achievment data according to the param 'achievementKeyName'.
        (string, bool, string) achievementDictionaryValue = achievementsDictionary[achievementKeyName];
        achievementDictionaryValue.Item2 = true;
        achievementsDictionary[achievementKeyName] = achievementDictionaryValue;
        
        /// Set a Player Prefs variable to indicate that an achievement has been unlocked.
        /// This is what's checked in gameplay scene to know when to activate the popup display.
        PlayerPrefs.SetString("hasUnlockedAchievement", achievementDictionaryValue.Item1);
        PlayerPrefs.Save();

        /// This is so that the Achievements page is updated accordingly with the new achievement.
        PlayerPrefs.SetInt(achievementDictionaryValue.Item1, 1);
        PlayerPrefs.Save();
    }
}
