using System; 

namespace BananaGame
{
	public class Game
	{
		public event Action<string> OnAchievementUnlocked;
		
		public double Bananas { get; private set; } = 0; 
		public double BananasPerSecond {get; private set; } = 0;
		
		private bool bananaAchievementUnlocked = false;
		
		public Game()
		{
			OnAchievementUnlocked += DisplayAchievement; //Subsribe to achievement Event
		}
		
		public void ProduceBananas(double amount)
		{
			Bananas += amount; 
			Console.WriteLine($"Created {amount} bananas. Total Bananas: {bananas}");
			checkAchievements();
		}
		
		public void IncreaseBananasPerSecond(double amount)
		{
			BananasPerSecond += amount; 
			Console.WriteLine($"Bananas per second increased to: {BananasPerSecond}");
			checkAchievements();
		}
		
		private void CheckAchievements()
		{
			if(!bananaAchievementUnlocked && BananasPerSecond >= 1)
			{
				bananaAchievementUnlocked = true; 
				unlockAchievement("Produce your first item automatically");
			}
		}
		
		private void UnlockAchievement(string achievement)
		{
			OnAchievementUnlocked?.Invoke(achievement);
		}
		
		private void DisplayAchievement(string achievement)
		{
			Console.WriteLine($"Achievement Unlocked: {achievement}");
		}
	}
	
	class Program
	{
		static void Main(string[] args)
		{
			Game game = new Game(); 
			
			//recreate game actions
			game.IncreaseBananasPerSecond(0.5); //No achievement yet
			game.ProduceBananas(10); //Producing bananas manually 
			
			
		}
	}
}