using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand2
{
    class Game
    {
        // Member Variables (HAS A)
        Player player;
        Day newDay;
        public int gameLength;
        public int currentDay;
        // Constructor
        public Game()
        {
            player = new Player();
            currentDay = 0;
        }

        // Member Methods (CAN DO)
        public void RunGame()
        {
            AskForInstructions();
            gameLength = UserInterface.AskGameLength();
            do
            {
                currentDay++;
                RunDaily();
            }
            while (currentDay < gameLength);
            UserInterface.ShowEndOfGameTotal(player);
            UserInterface.AskToPlayAgain();

        }
        public void RunDaily()
        {
            newDay = new Day(player);
            //TODO: Run Customer Buying Lemonade
            //TODO: Reduce Player Stock of Items
            UserInterface.ShowEndOfDayTotal(newDay, player);
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
    }
}
