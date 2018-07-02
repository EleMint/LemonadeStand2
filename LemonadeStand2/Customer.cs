using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand2
{
    class Customer
    {
        public int numberOfCustomersTotal;
        public double numberOfCustomerBuying;
        public double buyRate;
        public int numberOfSales;
        public Customer(Weather weather, Player player, Recipe recipe)
        {
            Random random = new Random();
            numberOfCustomersTotal = random.Next(50, 125);
            buyRate = CalculateBuyRate(weather, recipe);
            this.numberOfCustomerBuying = numberOfCustomersTotal * buyRate;
            BuyLemonade(recipe, player);
        }

        internal Day Day
        {
            get => default(Day);
            set
            {
            }
        }

        public double CalculateBuyRate(Weather weather, Recipe recipe)
        {
            buyRate = 1 + (weather.temperature / 50) - (weather.rainChance + weather.cloudChance);
            if(recipe.pricePerCup <= 0.25)
            {
                buyRate *= 1.5;
            }
            else if(recipe.pricePerCup > 0.25 && recipe.pricePerCup <= 0.50)
            {
                buyRate *= 1.25;
            }
            else if(recipe.pricePerCup > 0.50 && recipe.pricePerCup <= 0.65)
            {
                buyRate *= 1.15;
            }
            else if (recipe.pricePerCup >= 0.80)
            {
                buyRate *= 0.75;
            }

            return buyRate;
        }
        public void BuyLemonade(Recipe recipe, Player player)
        {
            if (recipe.cupsMade > numberOfCustomerBuying)
            {
                numberOfSales = int.Parse((numberOfCustomerBuying).ToString());
                player.money += numberOfCustomerBuying * recipe.pricePerCup;
            }
            else if (numberOfCustomerBuying > recipe.cupsMade)
            {
                numberOfSales = int.Parse((recipe.cupsMade).ToString());
                player.money += recipe.cupsMade * recipe.pricePerCup;
            }
        }
    }
}
