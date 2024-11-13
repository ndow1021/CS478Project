using System; 

namespace BananaGame
{
	public class BananaClicker
	{
		//Variable to store the count of banana clicks
		public int BananaClicks { get; private set; } = 0;
		
		//Event for unlocking achievements
		public event Action<string> AchievementUnlocked; 
		
		//Constructor
		public BananaClicker()
		{
			//Subscribe to the AchievementUnlocked Event
			AchievementUnlocked += OnAchievementUnlocked;
		} 
		
		//Click and Increment Banana Count
		public void ClickBanana()
		{
			BananaClicks++; 
			CheckForAchievements();
		}
		
		//Check to see if any achievemnts are unlocked
		private void CheckForAchievements()
		{
			if (BananaClicks == 1000000)
			{
				UnlockAchievement("1,000,000 Banana Clicks!"); 
			}
		}
		
		//Unlock and Notify of Any Achievements
		private void UnlockAchievement(string achievement)
		{
			AchievementUnlocked?.Invoke(achievement);
		}
		
		//Event Handler for when an achievement is unlocked
		private void OnAchievementUnlocked(string achievement)
		{
			Console.WriteLine($"Achievement Unlocked! {achievement}");
		}
	}
}

//Test
class Program 
{
	static void Main(string[] args)
	{
		BananaClicker clicker = new BananaClicker();
		
		//replicate clicks (can replace with real clicking in game
		for (int i = 0; i < 1000000; i++)
		{
			clicker.ClickBanana();
		}
		
	}
}