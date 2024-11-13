using System;
using System.Collection.Generic;
using System.Linq;

public class Upgrade
{
	public string Name {get; set; }
	public bool IsUnlocked { get; set; }
	
	public Upgrade(string name)
	{
		Name = name;
		IsUnlocked = false;
	}
	
	public void Unlock
	{
		
		
			IsUnlocked = true;
			Console.WriteLine($"{Name} upgrade unlocked");
		
	}
}

public class Achievement
{
	public string Name { get; private set; }
	public bool IsUnlocked { get; private set; }
	
	public Achievement(string name)
	{
		Name = name;
		IsUnlocked = false; 
	}
	
	public void Unlock()
	{
		if(!IsUnlocked)
		{
			IsUnlocked = true; 
			Console.WriteLine($"Achievement Unlocked: {Name}"); 
		}
	}
}

public class Game
{
	public List<Upgrade> Upgrades { get; private set; }
	public Achievement UnlockAllUpgradesAchievement { get; private set; }
	
	public Game()
	{
		
		//Initial Upgrades
		Upgrades = new List<Upgrade>
		{
			new Upgrade("Banana Multiplier");
			new Upgrade("Banana Auto-Clicker");
			new Upgrade("Banana Booster");
			new Upgrade("Banana Factory");
			
		};
		
		//Initialize Achievement
		UnlockAllUpgradesAchievement = new Achievement("Unlocked Every Upgrade");
		
	}
	
	public void CheckAchievements()
	{
		//Checks if all upgrades are unlocked
		if(Upgrades.All(upgrade => upgrade.IsUnlocked))
		{
			unlockAllUpgradesAchievement.Unlock();
		}
	}
	
	public void UnlockUpgrade(string upgradeName)
	{
		var uprade = Upgrades.FirstOrDefault(u => u.Name == upgradeName);
		
		if(upgrade != null && !upgrade.IsUnlocked)
		{
			upgrade.Unlock();
			CheckAchievements();
		}
		else
		{
			Console.WriteLine("Upgrade undetected or has already been unlocked ");
		}
	}
}