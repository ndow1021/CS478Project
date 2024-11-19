using System; 

namespace BananaClicker
{
    
    public class PlayerStats
    {
       public long AutomatedBananas{ get; private set; }

       public void AutomatedBananas(long amount)
       {
            AutomatedBananas += amount;
            AchievementManangers.CheckAchievment(this); 
       } 
    }

    public class AchievementManangers
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool IsUnlocked { get; private set; }

        public AchievementManangers(string name, string description)
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
                Console.WriteLine($"Achievement Unlocked: {Name}");
            }
        }
    }

    public static class AchievementManangers
    {
        private static readonly Achievement ReachOneMillionAutomatedBananas= new Achievement("Reach 1,000,000 Automated Banana.");

        public static void CheckAchievment(PlayerStats stats)
        {
            if(!ReachOneMillionAutomatedBananas.IsUnlocked && stats.AutomatedBananas >= 1_000_000)
            {
                ReachOneMillionAutomatedBananas.Unlock();
            }
        }
    }
}