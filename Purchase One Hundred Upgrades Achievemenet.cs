using System;

public class Game
{
	//Characterize a field to track the number of upgrades purchased
	private int upgradesPurchased = 0; 
	
	//Characterize an achievement flad
	private bool achievementUnlocked = false; 
	
	//Characterize the achievement goal
	private const int AchievementGoal = 100;
	
	//Event handler for purchasing an upgrade
	public void PurchaseUpgrade()
	{
		upgradesPurchased++;
		Console.WriteLine($"Upgrade purchased. Total Upgrades: {upgradesPurchased}");
		
		//Achievement Check
		CheckAcievement();
	}
	
	//Check if the achievement should be unlocked
	private void CheckAchievement()
	{
		if(!achievementUnlocked && upgradesPurchased >= AchievemenetGoal)
		{
			achievementUnlocked = true;
			UnlockAchievement();
		}
	}
	
	//Unlock the Achievement
	private void UnlockAchievement()
	{
		Console.WriteLine("Achievement Unlocked: Purchase 100 Upgrades"); 
	}
}

//Example
public class Program
{
	public static void Main()
	{
		Game game = new Game();
		
		//Simulates purchasing upgrades
		for(int i = 0; i < 100; i++)
		{
			game.PurchaseUpgrade();
		}
	}
}