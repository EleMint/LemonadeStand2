using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand2
{
    class Customer
    {
        // Member Variables (HAS A)
        public int numberOfCustomersTotal;
        public double numberOfCustomerBuying;
        public double buyRate;
        readonly Recipe recipe;
        // Constructor
        public Customer(Weather weather, Player player)
        {
            Random random = new Random();
            numberOfCustomersTotal = random.Next(50, 125);
            buyRate = CalculateBuyRate(weather, recipe);
            this.numberOfCustomerBuying = numberOfCustomersTotal * buyRate;
            BuyLemonade(recipe, player);
        }
        // Member Methods (CAN DO)
        public double CalculateBuyRate(Weather weather, Recipe recipe)
        {
            buyRate = 2 + (weather.temperature / 100) - (weather.chanceOfRain + weather.chanceOfClouds);
            buyRate *= recipe.pricePerCup;

            return buyRate;
        }
        public void BuyLemonade(Recipe recipe, Player player)
        {
            if (recipe.cupsMade > numberOfCustomerBuying)
            {
                player.money += numberOfCustomerBuying * recipe.pricePerCup;
            }
            else if (numberOfCustomerBuying > recipe.cupsMade)
            {
                player.money += recipe.cupsMade * recipe.pricePerCup;
            }
        }
    }
}
