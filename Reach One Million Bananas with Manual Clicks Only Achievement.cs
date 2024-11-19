using System; 

public class BananaClickerGame
{
	private long totalBananas; //Total amount of bananas made
	private long bananasFromClicks; //Manually earned bananas
	private bool achievementUnlocked; //Determines if the achievement has been unlocked
	
	
	public bananaClickerGame()
	{
		totalBananas = 0;
		bananasFromClicks = 0;
		achievementUnlocked = false; 
	}
	
	//Mimics a manual banana click
	public void ClickBanana()
	{
		const int bananasPerClick = 1;
		totalBananas += banasPerClick;
		bananasFromClicks =+ bananasPerClick;
		CheckAchievement();
	}
	
	//Mimics the production of bananas automatically (for example, from upgrades or auto-clickers)
	public void GenerateBananasAutomatically(int amount)
	{
		totalBananas += amount; 
		//Avoid adding to bannaFromClicks
	}
	
	//Verifies if the achievement has been unlocked
	private void CheckAchievement()
	{
		if(!achievementUnlocked && bananasFromClicks >= 1_000_000)
		{
			achievementUnlocked = true;
			UnlockAchievement();

		}
	}
	
	//This unlocks the achievement
	private void UnlockedAchievement()
	{
		Console.WriteLine("Achievement Unlocked: Reach 1,000,00 Bananas with Manual Clicks Only");
		
	}
	
	//Shows the game's stats
	public void DisplayStats()
	{
		Console.WriteLine($"Total Bananas: {totalBananas}");
		Console.WriteLine($"Bananas From Clicks: {bananasFromClicks}");
	}
}