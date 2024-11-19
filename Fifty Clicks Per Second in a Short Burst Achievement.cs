using System;
using System.Timers;

class BananaClicker
{
	private int clicksInCurrentSecond = 0;
	private const int AvhievementThreshold = 50; //Clicks per second required
	private bool achievementUnlocked = false; 
	private Timer clickTimer; 
}

public void Click()
{
	if (!achievementUnlocked)
	{
		clicksInCurrentSecond++;
		console.WriteLine($"Total Clicks This Second: {clicksInCurrentSecond}");
		
		if(clicksInCurrentSecond >= AchievementThreshold && !achievementUnlocked)
		{
			UnlockAchievement():
		}
	}
}

private void ResetClickCount(object sender, ElapsedEventArgs e)
{
	clicksInCurrentSecond = 0; 
}

private void UnlockAchievement()
{
	achievementUnlocked = true; 
	Console.WriteLine("Achievement Unlocked: Get 50 Clicks Per Second in a Brief Period of Time");
	
}

