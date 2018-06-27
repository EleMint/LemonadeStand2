using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand2
{
    class Day
    {
        // Member Variables (HAS A)
        readonly Weather weather;
        readonly Customer customer;
        readonly Random random;
        readonly Recipe recipe;

        // Constructor
        public Day(Player player)
        {
            weather = new Weather();
            DailyWeatherReport();
            string userInput;
            do
            {
                userInput = UserInterface.AskToBuyProduct(player);
            }
            while (userInput == "yes");
            UserInterface.AskForRecipe(player);
            customer = new Customer(weather, player);
            player.moneyDayBegin = player.money;
            player.moneyDayEnd = 0;
            player.ice = 0;

            
        }

        public void DailyWeatherReport()
        {
            Console.WriteLine("\r\nCurrent Weather Forecast:\r\nForecasted Temperature - {0}\r\nForecasted Sky Condition - {1}", weather.temperature, weather.skyCondition);

        }
        public void EndOfDayTotal(Day day, Player player)
        {
            player.moneyDayEnd = player.money;
            if (player.moneyDayBegin > player.moneyDayEnd)
            {
                Console.WriteLine("\r\nToday You Lost: ${0}", Math.Round(player.moneyDayBegin - player.moneyDayEnd));
            }
            else
            {
                Console.WriteLine("\r\nToday You Made: ${0}", (player.moneyDayEnd - player.moneyDayBegin));
            }
            UserInterface.ShowCustomerPurchase(customer, player, recipe);
        }
    }
}
