using UnityEngine;
using System.Collections;
using TMPro;
using System;

public class AchievementsPopup : MonoBehaviour {
    public GameObject achievementsPopupUI;  // Achievements canvas panel.
    public TextMeshProUGUI popupTextComponent;  // The text component on the panel's button.

    string achievementUnlockStatus;

    void Start() {
        achievementsPopupUI.SetActive(false);
    }

    void Update() {
        // Check if something has changed in terms of achievement status
        try {
            achievementUnlockStatus = PlayerPrefs.GetString("hasUnlockedAchievement");
        }
        catch (NullReferenceException) { achievementUnlockStatus = ""; }
        
        if (achievementUnlockStatus != "") {
            StartCoroutine(ToggleAchievementPopup());
        }
    }

    public IEnumerator ToggleAchievementPopup() {
        achievementsPopupUI.SetActive(true);  // Popup display for the achievement is now visible to the player.

        popupTextComponent.SetText("Achievement Unlocked!: " + achievementUnlockStatus);

        yield return new WaitForSecondsRealtime(5);
        achievementsPopupUI.SetActive(false);

        PlayerPrefs.SetString("hasUnlockedAchievement", "");
    }
}
