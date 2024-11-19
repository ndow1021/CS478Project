using System; 

namespace BananaClicker
{
    public class Player
    {
        public int TotalBananas { get; private set; }
        public int Milestone {get; private set; }
        public bool IsReset { get; private set; }
        public event Action<string> OnAchievementUnlocked; 

        public Player()
        {
            TotalBananas = 0; 
            Milestone = 100; //Initial Milestone
            IsReset = false; 
        }

        public void ClickBanana()
        {
            TotalBananas++;
            CheckMilestone();
        }

        public void ResetProgress()
        {
            TotalBananas = 0l 
            IsReset = true; 
        }

        private void CheckMilestone()
        {
            if(TotalBananas >= Milestone)
            {
                OneMilestoneReached();
                Milestone += 100; //Increment Milestone
            }
        }

        private void OneMilestoneReached()
        {
            Console.WriteLine($"Milestone Reached: {Milestone} bananas!");
            if(IsReset)
            {
                UnlockAchievement("Reach a New Milestone After Reset");
                IsReset = false; //Restarts
            }
        }

        private void UnlockAchievement(string achievementName)
        {
            Console.WriteLine($"Achievement Unlocked: {achievementUnlocked}");
            OnAchievementUnlocked?.Invoke(achievementName);
        }

        
    }
}