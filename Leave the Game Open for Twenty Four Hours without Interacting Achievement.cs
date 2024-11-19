using System;
using System.Timers;

public class BananaClickerGame
{
	private DateTime lastInteractionTime;
	private bool achievementUnlocked = false; 
	private Time idleTimer;
	private const int IdleTimeLimitHours = 24; 
	
	public BananaClickerGame()
	{
		lastInteractionTime = DateTime.Now;
		idleTimer = new Timer(1000); //Checks Every Second
		idleTimer.Elapsed += CheckForAchievement;
		idleTimer.Start();
	}
	
	public void OnUserInteraction()
	{
		if(achievementUnlocked)
			return;
		
		lastInteractionTime = DateTime.Now;
		Console.WriteLine("Player Interaction Detected. Timer has been rest.");
	}
	
	private void CheckForAchievement(object sender, ElapsedEventArgs e)
	{
		if(achievementUnlocked)
			return;
		
		var timeSinceLastInteraction = DateTime.Now - lastInteractionTime;
		if(timeSinceLastInteraction.TotalHours >= IdleTimeLimitHours)
		{
			UnlockAchievement();
		}
	}
	
	
}