using System; 

public class Game
{
	public int TotalBananas { get; private set; } = 0; 
	public event Action<string> OnAchievementUnlocked; 
	
	public void AddBananas(int amount)
	{
		TotalBananas += amount;
		CheckAchievements();
	}
	
	private void CheckAcievements()
	{
		if(TotalBananas >= 1000000)
		{
			UnlockAchievement("The Collector of Bananas")
		}
	}
	
	private void UnlockAchievement(string achievementName)
	{
		Console.WriteLine($"Achievement Unlocked: {achievementName}")
		OnAchievementUnlocked?.Invoke(achievmentName);
	}
}

//Test??
public class Program
{
	public static void Main()
	{
		Game game = new Game();
		game.OnAchievementUnlocked += achievement => Console.Writeline($"You have unlocked: {achievement}");
		
		
		//Simulates adding bananas
		for (int i = 0; i < 100; i++)
		{
			game.AddBananas(10000); //This adds 10,000 per iteration
			Console.WriteLine($"Total Bananas: {game.TotalBananas}");
		}
	}
}