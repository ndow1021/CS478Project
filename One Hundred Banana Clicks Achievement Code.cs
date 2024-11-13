using System; 

public class AchievementSystem
{
	private int bananaClicks;
	private bool achievementUnlocked; 
	
	public AchievementSytem()
	{
		bananaClicks = 0; 
		achievementUnlocked = false; 
	}
	
	public void ClickBanana() //This is an approach to reproduce a banana click.
	{
		banannaClicks++;
		Console.WriteLine($"Total Bananas Clicked: {bananaClicks");
		
		if (bananaClicks >= 100 && !achievementUnlocked) //This checls tp see if the achievement should be unlocked.
		{
			UnlockAchievement();
		}
	}
	
	private void UnlockAchievement() //This is an approach to unlock the achievement
	{
		achievementUnlocked = true;
		Console.WriteLine("Achievement Unlocked! One Hundred Banana Clicks!");
	}
}

class Program //Possible Example
{
	static void Main(string[] args)
	{
		for(int i = 0; i < 100; i++)
		{
			achievementSystem.ClickBanana();
		}
	}
}