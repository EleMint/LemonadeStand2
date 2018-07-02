using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand2
{
    class Game
    {
        Player player;
        Day newDay;
        public int gameLength;
        public int currentDay;
        public Game()
        {
            player = new Player();
            currentDay = 0;
        }

        internal Program Program
        {
            get => default(Program);
            set
            {
            }
        }

        internal Player Player
        {
            get => default(Player);
            set
            {
            }
        }

        public void RunGame()
        {
            UserInterface.ShowIntroduction();
            AskForInstructions();
            gameLength = UserInterface.AskGameLength();
            do
            {
                currentDay++;
                RunDaily(currentDay);
            }
            while (currentDay < gameLength);
            UserInterface.ShowEndOfGameTotal(player);
            UserInterface.AskToPlayAgain();

        }
        public void RunDaily(int currentDay)
        {
            newDay = new Day(currentDay, player);
            UserInterface.GetRecipe(player);
            UserInterface.ShowEndOfDayTotal(newDay, player, UserInterface.GetRecipe(player));
        }
        public string AskToBuyProduct()
        {
            return UserInterface.AskToBuyProduct(player);
        }
        public void AskForInstructions()
        {
            Console.WriteLine("\r\nWould You Like To Read The Instructions?");
            string userAnswer = Console.ReadLine().ToLower().Trim();
            switch (userAnswer)
            {
                case "yes":
                    UserInterface.ShowInstructions();
                    break;
                default:
                    break;
            }

        }

        public void remove()
        {
            throw new System.NotImplementedException();
        }
    }
}
