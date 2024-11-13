using System;

public class Game
{
	//Triggers when achievement is unlocked
	public event Action<string> OnAchievementUnlocked; 
	
	
	//Bananas per second rate
	private float bananasPerSecond;
	private bool achievementUnlocked = false;
	
	public Game()
	{
		//To display the achievement, suppose OnAchievementUnlocked subscribes to a method elsewhere.
		
	}
	
	public void UpdateBananasPerSecond(float newRate)
	{
		bananasPerSecond = newRate; 
		
		//Check if the achievement should be unlocked
		CheckAchievement();
		
		
	}
	
	private void CheckAchievement()
	{
		if(bananasPerSecond >= 10 && !achievementUnlocked)
		{
			UnlockAchievement("Reach 10 Bananas Per Second.");
			achievementUnlocked = true; 
		}
	}
	
	private void UnlockAchievement(string achievementName)
	{
		OnAchievementUnlocked?.Invoke(achievementName);
		Console.WriteLine($"Achievement Unlocked: {achievementName}"); 
	
	}
	
}


//Example
public class Program
{
	public static void Main()
	{
		Game game = new Game();
		
		//subscribe to the OnAchievementUnlocked event to display it in console
		game.OnAchievementUnlocked += achievementName => Console.Writeline($"Player Recieved: {achievementName}");
		
		
		//Mimic updating the bananas per second rate
		game.UpdateBananasPerSecond(5); //No achievement yet
		game.UpdateBananasPerSecond(10); //Achievement Unlocked
	}
}