using System:

public class Achievement
{
	public string Name { get; set; }
	public string Description { get; set; }
	public bool IsUnlocked { get; private set; }
	
	public Achievement(string name, string description)
	{
		Name = name;
		Description = description; 
		IsUnlocked = false; 
	}
	
	public void Unlock()
	{
		if(!IsUnlocked)
		{
			IsUnlocked = true; 
			ConsoleWriteLine($"Achievement Unlocked: {name} - {description}");
		}
	}
}

public class BananaClicker
{
	public int ClickCount {get; private set; }
	private Achievement_bananaAchievement;
	
	public BananaClicker()
	{
		ClickCount = 0;
		_bananaAchievement = new Achievement("Achievement Unlocked: One Thousand Banana Clicks!");
		
	}
	private void CheckAchievements()
	{
		if(ClickCount >= 1000 && !_bananaAchievement.IsUnlocked)
		{
			_bananaAchievement.Unlocked();
		}
	}
}

//Example
class Program 
{
	static void Main()
	{
		BananaClicker clicker = new BananaClicker();
		
		//Replicate clicking 1,000 bananas. 
		for (int i = 0; i < 100; i++)
		{
			Clicker.ClickBanana();
		}
	}
}