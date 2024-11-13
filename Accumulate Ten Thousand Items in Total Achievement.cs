using System; 

namespace BananaGame
{
	class Player
	{
		public int TotalBananas {get; private set; }
		public bool AchievementUnlocked {get; private set; }
		
		public Player()
		{
			TotalBananas = 0; 
			AchievementUnlocked = false; 
		}
		
		//Collect Bananas 
		public void CollectBananas(int amouhnt)
		{
			TotalBananas += amount;
			CheckAchievement();
		}
		
		//Checks to see if achievement is reached
		private void CheckAchievement()
		{
			if (TotalBananas >= 10000 && !AchievementUnlocked)
			{
				AchievementUnlocked = true; 
				Console.WriteLine("Achievement Unlocked: Collect 10,000 Bananas.")
			}
		}
	}
}

class Program
{
	static void Main(string[] args)
	{
		
		player.CollectBananas(5000);
		player.CollectBananas(3000);
		player.CollectBananas(2000);
		
		Console.WriteLine($"Bananas Collected: {player.TotalBananas}");
		
	}
}