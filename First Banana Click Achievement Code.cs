using UnityEngine;

public class BananaClickAchievement : MonoBehavior
{
	private bool achievementunlocked = false; 
	
	void OnMouseDown()
	{
		if(!achievementunlocked)
		{
			unlockAchievement();
		}
	}
	
	void UnlockAchievement()
	{
		achievementUnlocked = true;
		Debug.Log("Achievement Unlocked: Click the Banana One Time! ");
	}
	
	
}