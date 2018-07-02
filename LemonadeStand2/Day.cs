using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand2
{
    class Day
    {
        readonly Weather weather;
        readonly Customer customer;
        public Day(int currentDay, Player player)
        {
            player.moneyDayBegin = player.money;
            player.moneyDayEnd = 0;
            player.ice = 0;
            weather = new Weather();
            ShowCurrentDay(currentDay);
            DailyWeatherReport();
            string userInput;
            do
            {
                userInput = UserInterface.AskToBuyProduct(player);
            }
            while (userInput == "yes");
            UserInterface.AskForRecipe(player);
            customer = new Customer(weather, player, UserInterface.GetRecipe(player));    
        }

        internal Game Game
        {
            get => default(Game);
            set
            {
            }
        }

        public void ShowCurrentDay(int currentDay)
        {
            Console.WriteLine("Beginning of Day {0}", currentDay);
        }

        public void DailyWeatherReport()
        {
            Console.WriteLine("\r\nCurrent Weather Forecast:\r\nTemperature - {0}\r\nSky Condition - {1}", weather.temperature, weather.skyCondition);
        }
        public void EndOfDayTotal(Day day, Player player, Recipe recipe)
        {
            player.moneyDayEnd = player.money;
            double moneyDay = player.moneyDayBegin - player.moneyDayEnd;
            double moneyDay1 = player.moneyDayEnd - player.moneyDayBegin;
            UserInterface.ShowCustomerPurchase(customer, player, recipe);
            Console.WriteLine("\r\nToday You Sold: ${0} Of Lemonade", recipe.cupsMade * recipe.pricePerCup);
            if (player.moneyDayBegin > player.moneyDayEnd)
            {
                Console.WriteLine("\r\nToday You Lost: ${0}", moneyDay);
            }
            else
            {
                Console.WriteLine("\r\nToday You Made: ${0}", moneyDay1);
            }
            
        }
    }
}
