using System; 

public class BananaClicker
{
	public static event Action OnAchievementUnlocked; 
	
	private long totalBananasCollected = 0; 
	private const long AchievementThreshold = 1_000_000_000;
	private bool achievementUnlocked = false; 
	
	private BananaClicker()
	{
		//A method to handle when the achievement is unlocked
		OnAchievementUnlocked += HandleAchievementUnlocked; 
	}
	
	public void CollectBananas(long bananasCollected)
	{
		totalBananasCollected += bananasCollected;
		
		checkForAchievement();
		Console.WriteLine($"Bananas Collected: {bananasCollected}, Total Bananas: {totalBananasCollected}");
		
	}
	
	private void CheckForAchievement()
	{
		if (!achievementUnlocked && totalBananasCollected >= AchievementThreshold)
		{
			achievementUnlocked = true; 
			OnAchievementUnlocked?.Invoke();
		}
	}
	
	private void HandleAchievementUnlocked()
	{
		Console.WriteLine("Achievement Unlocked: Collect 1,000,000,000 Bananas");
		
	}
}

