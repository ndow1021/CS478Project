using System; 

namespace BananaClickerGame
{
	public class Player
	{
		public long TotalBananasCollected { get; private set; }
		public bool HasAchievementOneTrillion { get; private set; }
		
		public event Action OnAchievementUnlocked; 
		
		public Player()
		{
			TotalBananasCollected = 0; 
			HasAchievementOneTrillion = false; 
		}
		
		//Used to add bananas to the player's total count
		public void AddBananas(long bananas)
		{
			TotalBananasCollected += bananas; 
			CheckAchievements();
		}
		
		//Used to check if the player has reached one trillion bananas
		private void CheckAchievements()
		{
			if(!HasAchievementsOneTrillion && TotalBananasCollected >= 1_000_000_000_000)
			{
				HasAchievementOneTrillion = true; 
				OneAchievementUnlocked?.Invoke();
			}
		}
	}
	
	public class AchievementSystem
	{
		public void RegisterAchievement(Player player)
		{
			player.OnAchievementUnlocked += () =>
			{
				if (player.HasAchievementOneTrillion)
				{
					Console.WriteLine("Achievement Unlocked: Collect One Trillion Bananas");
				}
			};
		}
	}
	
	
	//Test
	public class Program
	{
		public static void Main()
		{
			Player player = new Player ();
			AchievementSystem achievementSystem = new AchievementSystem();
			achievementSystem.RegisterAchievement(player);
			
			//Example loop (adding bananas frequently)
			player.AddBananas(500_000_000_000); //Adds 500 billion bananas
			player.AddBananas(500_000_000_000); //Adds another 500 billion bananas
			player.AddBananas(1); //Adds one more banana to hit one trillion
			
			
			Console.ReadLine();
		}
	}
}