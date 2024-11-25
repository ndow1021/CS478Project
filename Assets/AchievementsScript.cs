using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using System;
using static Unity.Collections.AllocatorManager;

public class AchievementsScript : MonoBehaviour
{
    // To manage the actual text components in the Unity scene.

    /// <summary>
    // Text fields on the Unity scene. set the scene texts according to unlock/lock status.
    /// </summary>
    private GameObject FirstClickAchvObj;
    private GameObject HundredClicksAchvObj;
    private GameObject BananaBonanzaAchvObj;
    private GameObject FirstUpgradeAchvObj;
    private GameObject MonkeyBusinessAchvObj;
    private GameObject TreeHuggerAchvObj;
    private GameObject RocketScientistAchvObj;
    private GameObject GoldenTouchAchvObj;
    private GameObject BananaTycoonAchvObj;
    private GameObject HelperArmyAchvObj;
    private GameObject ForestBananasAchvObj;
    private GameObject RocketMasterAchvObj;

    private string textBase = " Achievement\nStatus: ";  // Literally only here to make things easier when setting unlocks

    private TextMeshProUGUI FirstClickAchvText;
    private TextMeshProUGUI HundredClicksAchvText;
    private TextMeshProUGUI BananaBonanzaAchvText;
    private TextMeshProUGUI FirstUpgradeAchvText;
    private TextMeshProUGUI MonkeyBusinessAchvText;
    private TextMeshProUGUI TreeHuggerAchvText;
    private TextMeshProUGUI RocketScientistAchvText;
    private TextMeshProUGUI GoldenTouchAchvText;
    private TextMeshProUGUI BananaTycoonAchvText;
    private TextMeshProUGUI HelperArmyAchvText;
    private TextMeshProUGUI ForestBananasAchvText;
    private TextMeshProUGUI RocketMasterAchvText;

    // These are to manage all the indiv. achievements.
    private bool firstClickAchieve      = false;
    private bool hundredClicksAchieve   = false;
    private bool bananaBonanzaAchieve   = false;
    private bool firstUpgradeAchieve    = false;
    private bool monkeyBusinessAchieve  = false;
    private bool treeHuggerAchieve      = false;
    private bool rocketScientistAchieve = false;
    private bool goldenTouchAchieve     = false;
    private bool bananaTycoonAchieve    = false;
    private bool helperArmyAchieve      = false;
    private bool forestBananasAchieve   = false;
    private bool rocketMasterAchieve    = false;
    

    // Start is called before the first frame update
    void Start()
    {
        FirstClickAchvObj      = GameObject.Find("Canvas/FirstClickAchvText");
        HundredClicksAchvObj   = GameObject.Find("Canvas/HundredClicksAchvText");
        BananaBonanzaAchvObj   = GameObject.Find("Canvas/BananaBonanzaAchvText");
        FirstUpgradeAchvObj    = GameObject.Find("Canvas/FirstUpgradeAchvText");
        MonkeyBusinessAchvObj  = GameObject.Find("Canvas/MonkeyBusinessAchvText");
        TreeHuggerAchvObj      = GameObject.Find("Canvas/TreeHuggerAchvText");
        RocketScientistAchvObj = GameObject.Find("Canvas/RocketScientistAchvText");
        GoldenTouchAchvObj     = GameObject.Find("Canvas/GoldenTouchAchvText");
        BananaTycoonAchvObj    = GameObject.Find("Canvas/BananaTycoonAchvText");
        HelperArmyAchvObj      = GameObject.Find("Canvas/HelperArmyAchvText");
        ForestBananasAchvObj   = GameObject.Find("Canvas/ForestBananasAchvText");
        RocketMasterAchvObj    = GameObject.Find("Canvas/RocketMasterAchvText");

        /// Define the text components based on the game objects.
        FirstClickAchvText      = FirstClickAchvObj.GetComponent<TextMeshProUGUI>();
        HundredClicksAchvText   = HundredClicksAchvObj.GetComponent <TextMeshProUGUI>();
        BananaBonanzaAchvText   = BananaBonanzaAchvObj.GetComponent<TextMeshProUGUI>();
        FirstUpgradeAchvText    = FirstUpgradeAchvObj.GetComponent<TextMeshProUGUI>();
        MonkeyBusinessAchvText  = MonkeyBusinessAchvObj.GetComponent<TextMeshProUGUI>();
        TreeHuggerAchvText      = TreeHuggerAchvObj.GetComponent<TextMeshProUGUI>();
        RocketScientistAchvText = RocketScientistAchvObj.GetComponent<TextMeshProUGUI>();
        GoldenTouchAchvText     = GoldenTouchAchvObj.GetComponent<TextMeshProUGUI>();
        BananaTycoonAchvText    = BananaTycoonAchvObj.GetComponent<TextMeshProUGUI>();
        HelperArmyAchvText      = HelperArmyAchvObj.GetComponent<TextMeshProUGUI>();
        ForestBananasAchvText   = ForestBananasAchvObj.GetComponent<TextMeshProUGUI>();
        RocketMasterAchvText    = RocketMasterAchvObj.GetComponent<TextMeshProUGUI>();

        LoadAchievements();
        UpdateAchievementStatusExcerpts();
    }

    // Update is called once per frame
    void UpdateAchievementStatusExcerpts()
    {
        FirstClickAchvText.SetText("First Click" + textBase + LockUnLockBooleanConversion(firstClickAchieve));
        HundredClicksAchvText.SetText("Hundred Clicks" + textBase + LockUnLockBooleanConversion(hundredClicksAchieve));
        BananaBonanzaAchvText.SetText("Banana Bonanza" + textBase + LockUnLockBooleanConversion(bananaBonanzaAchieve));
        FirstUpgradeAchvText.SetText("First Upgrade" + textBase + LockUnLockBooleanConversion(firstUpgradeAchieve));
        MonkeyBusinessAchvText.SetText("Monkey Business" + textBase + LockUnLockBooleanConversion(monkeyBusinessAchieve));
        TreeHuggerAchvText.SetText("Tree Hugger" + textBase + LockUnLockBooleanConversion(treeHuggerAchieve));
        RocketScientistAchvText.SetText("Rocket Scientist" + textBase + LockUnLockBooleanConversion(rocketScientistAchieve));
        GoldenTouchAchvText.SetText("Golden Touch" + textBase + LockUnLockBooleanConversion(goldenTouchAchieve));
        BananaTycoonAchvText.SetText("Banana Tycoon" + textBase + LockUnLockBooleanConversion(bananaTycoonAchieve));
        HelperArmyAchvText.SetText("Helper Army" + textBase + LockUnLockBooleanConversion(helperArmyAchieve));
        ForestBananasAchvText.SetText("Forest of Bananas" + textBase + LockUnLockBooleanConversion(forestBananasAchieve));
        RocketMasterAchvText.SetText("Rocket Master" + textBase + LockUnLockBooleanConversion(rocketMasterAchieve));
    }

    public void LoadAchievements() {
        // Check for  Achievements loaded from previous game sessions.
        firstClickAchieve      = Convert.ToBoolean( PlayerPrefs.GetInt("First Click", 0) );
        hundredClicksAchieve   = Convert.ToBoolean( PlayerPrefs.GetInt("Hundred Clicks", 0) );
        bananaBonanzaAchieve   = Convert.ToBoolean( PlayerPrefs.GetInt("Banana Bonanza", 0) );
        firstUpgradeAchieve    = Convert.ToBoolean( PlayerPrefs.GetInt("First Upgrade", 0) );
        monkeyBusinessAchieve  = Convert.ToBoolean( PlayerPrefs.GetInt("Monkey Business", 0) );
        treeHuggerAchieve      = Convert.ToBoolean( PlayerPrefs.GetInt("Tree Hugger", 0) );
        rocketScientistAchieve = Convert.ToBoolean( PlayerPrefs.GetInt("Rocket Scientist", 0) );
        goldenTouchAchieve     = Convert.ToBoolean( PlayerPrefs.GetInt("Golden Touch", 0) );
        bananaTycoonAchieve    = Convert.ToBoolean( PlayerPrefs.GetInt("Banana Tycoon", 0) );
        helperArmyAchieve      = Convert.ToBoolean( PlayerPrefs.GetInt("Helper Army", 0) );
        forestBananasAchieve   = Convert.ToBoolean( PlayerPrefs.GetInt("Forest Of Bananas", 0) );
        rocketMasterAchieve    = Convert.ToBoolean( PlayerPrefs.GetInt("Rocket Master", 0) );
    }

    public void SaveAchievements() {
        firstClickAchieve      = Convert.ToBoolean(PlayerPrefs.GetInt("First Click", 0));
        hundredClicksAchieve   = Convert.ToBoolean(PlayerPrefs.GetInt("Hundred Clicks", 0));
        bananaBonanzaAchieve   = Convert.ToBoolean(PlayerPrefs.GetInt("Banana Bonanza", 0));
        firstUpgradeAchieve    = Convert.ToBoolean(PlayerPrefs.GetInt("First Upgrade", 0));
        monkeyBusinessAchieve  = Convert.ToBoolean(PlayerPrefs.GetInt("Monkey Business", 0));
        treeHuggerAchieve      = Convert.ToBoolean(PlayerPrefs.GetInt("Tree Hugger", 0));
        rocketScientistAchieve = Convert.ToBoolean(PlayerPrefs.GetInt("Rocket Scientist", 0));
        goldenTouchAchieve     = Convert.ToBoolean(PlayerPrefs.GetInt("Golden Touch", 0));
        bananaTycoonAchieve    = Convert.ToBoolean(PlayerPrefs.GetInt("Banana Tycoon", 0));
        helperArmyAchieve      = Convert.ToBoolean(PlayerPrefs.GetInt("Helper Army", 0));
        forestBananasAchieve   = Convert.ToBoolean(PlayerPrefs.GetInt("Forest Of Bananas", 0));
        rocketMasterAchieve    = Convert.ToBoolean(PlayerPrefs.GetInt("Rocket Master", 0));
    }

    public string LockUnLockBooleanConversion(bool booleanExprToConvertToLockUnlock)
    {
        if (booleanExprToConvertToLockUnlock == false) return "Locked";
        else return "Unlocked";
    }
}
