using Sytem; 
using System.Collections.Generic; 

namespace BananaGame
{

	//Achievement Class
	public class Achievement
	{
		public string Name { get; }
		public string Description { get; }
		public bool IsUnlocked { get; private set; }
		
		public Achievement(string name, string description)
		{
			Name = name;
			Description = description; 
			IsUnlocked = false; 
		}
		
		public void Unlock()
		{
			IsUnlocked = true; 
			Console.Writeline($"Achievement Unlocked: {Name} - {Description}");
		}
	}
	
	//Player Class
	public class Player
	{
		public int UpgradeCount { get; private set; }
		
		public Player()
		{
			UpgradeCount = 0; 
			Achievements = new List<Achievement>;
		}
		
		//Purchase an Upgrade
		public void PurchaseUpgrade()
		{
			UpgradeCount++; 
			Console.WriteLine($"Upgrade Successfully Purchased! Total Upgrades: {UpgradeCount}");
			CheckAchievements();
		}
		
		//Add an Achievement to the Player
		public void AddAchievement(Achievement achievement)
		{
			Achievements.Add(achievement);
		}
		
		//Check Achievements
		private void CheckAchievements()
		{
			foreach (var achievement in Achievements)
			{
				if (!achievement.IsUnlocked && UpgradeCount >= 10)
				{
					achievement.Unlocked();
				}
			}
		}
	}
}

class Program 
{
	static void Main(string[] args)
	{
		//Player Creation
		Player player = new Player(); 
		
		//Create an Achievement for buying ten upgrades
		Achievement tenUpgradesAchievement = new Achievement(
		
			"Banana Time",
			"Purchase 10 upgrades to enhance the banana empire!");
			
			
		//Add Achievement to Player	
		player.AddAchievement(tenUpgradesAchievement); 
		
		
		//Replicate purchasing upgrades
		for (int i = 0; i < 10; i++
		{
			player.PurchaseUpgrade();
		}
		
		
	}
}