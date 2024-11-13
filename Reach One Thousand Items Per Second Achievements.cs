using System;

namespace BananaGame
{
	public class Game
	{
		public int bananas = 0; //Total bananas collect
		public int bananasPerSecond = 0; //Bananas collected per second
		public bool achievementUnlocked = false; // Check to see if the achievement is unlocked
		
		public event Action OnAchievementUnlocked; 
		
		public void CollectBananas(int amount)
		{
			bananas += amount;
			Console.WriteLine($"Collected {amount} bananas. Total: {bananas}");
			
		}
		
		public void UpdateBananasPerSecond(int newRate)
		{
			bananasPerSecond = newRate; 
			Console.WriteLine($"Bananas per second: {bananasPerSecond}");
			
			CheckAchievement();
		}
		
		private void CheckAchievement()
		{
			if(bananasPerSecond >= 1000 && !achievementUnlocked)
			{
				achievementUnlocked = true; 
				OnAchievemntUnlocked?.Invoke(); 
				Console.WriteLine("Achievement Unlocked: Reach 1,000 Bananas Per Second."); 
				
			}
		}
	}
}


class Program
{
	static void Main(string[] args)
	{
		Game bananaGame = new Game();
		bananaGame.OnAchievementUnlocked += () =>
		{
			Console.WriteLine("Congrats! You've unlocked an achievement!");
		};
		
		//Recreate collecting bananas and updating rate
		bananaGame.CollectBananas(500);
		bananaGame.UpdateBananasPerSecond(900);
		
		//Reacing 1,000 bananas per second
		bananaGame.UpdateBananasPerSecond(1000); //This should unlock the achievement. 
	}
}