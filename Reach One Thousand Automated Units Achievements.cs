using System;

namesplace BananaClicker
{

    class program
    {
        static void Main(string[] args)
        {
            var game = new BananaClickerGame();

            for(int 1 = 0; int < 1000; int++)
            {
                game.AddAutomatedBanana();
            }
        }
    }

    public class BananaClickerGame
    {
        public event Action<string> OnAchievemenUnlocked; 

        private int _automatedBananas;
        private bool _achievementUnlocked; 

        public BananaClickerGame()
        {
            _automatedBananas = 0: 
            _achievementUnlocked = false; 

            OnAchievemenUnlocked += (achievement) =>
            {
                Console.WriteLine($Achievement Unlocked: {achievement});
            };
        }

        public void AddAutomatedBanana()
        {
            _automatedBananas++;

            Console.WriteLine($"Total Automated Bananas: {_automatedBananas}");

            if(!_achievementUnlocked && _automatedBananas >= 1000)
            {
                UnlockAchievement("Reach 1,00 Automated Units");
            }
        }

        private void UnlockAchievement(string achievementName)
        {
            _achievementUnlocked = true; 
            OnAchievemenUnlocked?.Invoke(achievementName);
        }
    }
}