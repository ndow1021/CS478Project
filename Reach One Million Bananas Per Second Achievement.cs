using UnityEngine; 

public class AchievementManager : MonoBehavior
{
	public float bananasPerSecond = 0f; //Update this value on game logic
	private bool hasAchievedMillionBananasPerSecond = false; 
	
	void Update()
	{
		CheckBananaAchievements()
	}
	
	private void CheckBananaAchievements()
	{
		//This is supposed to check of bananas per second is one million or more and if the achievement has been unlocked
		if (!hasAchievedMillionBananasPerSecond && bananasPerSecond >= 1000000f)
		{
			UnlockMillionBananasPerSecondAchievement();
		}
	}
	
	private void UnlockMillionBananasPerSecondAchievement()
	{
		hasAchievedMillionBananasPerSecond = true; 
		Debug.Log("Achievement Unlocked: Reached 1,000,000 Bananas Per Second");
	}
}