using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using System;


public class AchievementsScript : MonoBehaviour
{
    // To manage the actual text components in the Unity scene.

    /// <summary>
    // Text fields on the Unity scene. set the scene texts according to unlock/lock status.
    /// </summary>
    // Do the following need to have [SerializeField] ?
    private GameObject FirstClickAchvObj;
    private GameObject BananaBonanzaAchvObj;
    private GameObject MonkeyBusinessAchvObj;
    private GameObject TreeHuggerAchvObj;
    private GameObject RocketScientistAchvObj;
    private GameObject GoldenTouchAchvObj;
    private GameObject BananaTycoonAchvObj;
    private GameObject HelperArmyAchvObj;
    private GameObject ForestBananasAchvObj;
    private GameObject RocketMasterAchvObj;

    private string textBase = "Status: ";  // Literally only here to make things easier when setting unlocks

    private TextMeshProUGUI FirstClickAchvText;
    private TextMeshProUGUI BananaBonanzaAchvText;
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
    private bool bananaBonanzaAchieve   = false;
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
        //TextMeshProUGUI something = FirstClickAchvText.GetComponent<TextMeshProUGUI>();
        //something.SetText("Hello");

        FirstClickAchvObj      = GameObject.Find("Canvas/FirstClickAchvText");
        BananaBonanzaAchvObj   = GameObject.Find("Canvas/BananaBonanzaAchvText");
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
        BananaBonanzaAchvText   = BananaBonanzaAchvObj.GetComponent<TextMeshProUGUI>();
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
        FirstClickAchvText.SetText(textBase + LockUnLockBooleanConversion(firstClickAchieve));
        BananaBonanzaAchvText.SetText(textBase + LockUnLockBooleanConversion(bananaBonanzaAchieve));

        MonkeyBusinessAchvText.SetText(textBase + LockUnLockBooleanConversion(monkeyBusinessAchieve));
        TreeHuggerAchvText.SetText(textBase + LockUnLockBooleanConversion(treeHuggerAchieve));

        RocketScientistAchvText.SetText(textBase + LockUnLockBooleanConversion(rocketScientistAchieve));
        GoldenTouchAchvText.SetText(textBase + LockUnLockBooleanConversion(goldenTouchAchieve));

        BananaTycoonAchvText.SetText(textBase + LockUnLockBooleanConversion(bananaTycoonAchieve));
        HelperArmyAchvText.SetText(textBase + LockUnLockBooleanConversion(helperArmyAchieve));

        ForestBananasAchvText.SetText(textBase + LockUnLockBooleanConversion(forestBananasAchieve));
        RocketMasterAchvText.SetText(textBase + LockUnLockBooleanConversion(rocketMasterAchieve));
    }

    public void LoadAchievements() {
        // Check for  Achievements loaded from previous game sessions.
        
        firstClickAchieve      = Convert.ToBoolean( PlayerPrefs.GetInt("FirstBananaClick", 0) );
        bananaBonanzaAchieve   = Convert.ToBoolean( PlayerPrefs.GetInt("BananaBonanza", 0) );
        monkeyBusinessAchieve  = Convert.ToBoolean( PlayerPrefs.GetInt("MonkeyBusiness", 0) );
        treeHuggerAchieve      = Convert.ToBoolean( PlayerPrefs.GetInt("TreeHugger", 0) );
        rocketScientistAchieve = Convert.ToBoolean( PlayerPrefs.GetInt("RocketScientist", 0) );
        goldenTouchAchieve     = Convert.ToBoolean( PlayerPrefs.GetInt("GoldenTouch", 0) );
        bananaTycoonAchieve    = Convert.ToBoolean( PlayerPrefs.GetInt("BananaTycoon", 0) );
        helperArmyAchieve      = Convert.ToBoolean( PlayerPrefs.GetInt("HelperArmy", 0) );
        forestBananasAchieve   = Convert.ToBoolean( PlayerPrefs.GetInt("ForestBananas", 0) );
        rocketMasterAchieve    = Convert.ToBoolean( PlayerPrefs.GetInt("RocketMaster", 0) );
        //*/

    }

    public void SaveAchievements() {
        firstClickAchieve      = Convert.ToBoolean(PlayerPrefs.GetInt("FirstBananaClick", 0));
        bananaBonanzaAchieve   = Convert.ToBoolean(PlayerPrefs.GetInt("BananaBonanza", 0));
        monkeyBusinessAchieve  = Convert.ToBoolean(PlayerPrefs.GetInt("MonkeyBusiness", 0));
        treeHuggerAchieve      = Convert.ToBoolean(PlayerPrefs.GetInt("TreeHugger", 0));
        rocketScientistAchieve = Convert.ToBoolean(PlayerPrefs.GetInt("RocketScientist", 0));
        goldenTouchAchieve     = Convert.ToBoolean(PlayerPrefs.GetInt("GoldenTouch", 0));
        bananaTycoonAchieve    = Convert.ToBoolean(PlayerPrefs.GetInt("BananaTycoon", 0));
        helperArmyAchieve      = Convert.ToBoolean(PlayerPrefs.GetInt("HelperArmy", 0));
        forestBananasAchieve   = Convert.ToBoolean(PlayerPrefs.GetInt("ForestBananas", 0));
        rocketMasterAchieve    = Convert.ToBoolean(PlayerPrefs.GetInt("RocketMaster", 0));
    }

    public string LockUnLockBooleanConversion(bool booleanExprToConvertToLockUnlock)
    {
        if (booleanExprToConvertToLockUnlock == false) return "Locked";
        else return "Unlocked";
    }
}
