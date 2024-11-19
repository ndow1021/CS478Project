using System;

public class BananaClicker
{
	private int clickCombo; //Tracks the current combo
	private const int AchievementThreshold = 100; //The needed combo
	private bool achievementUnlocked
	
	public BananaClicker()
	{
		clickCombo = 0;
		achievementUnlocked = false;
	}
	
	//Mimics a successful click
	public void ClickBanana()
	{
		if(achievementUnlocked) return;
		
		clickCombo++;
		Console.WriteLine($"Combo: {clickCombo}");
		
		CheckAchievement();
	}
	
	//Mimics a missed click
	public void MissClick()
	{
		if(achievementUnlocked) return;
		
		Console.WriteLine("Click Missed. Combo has been reset.");
		clickCombo = 0;
	}
	
	//Verify whether the accomplishment has been unlocked.
	private void CheckAchievement()
	{
		if(clickCombo >= AchievementThreshold && !achievementUnlocked)
		{
			achievementUnlocked = true;
			Console.WriteLine("Achievement Unlocked: Reach a Combo of 100 Clicks Without Missing.");
		}
	}
	
}