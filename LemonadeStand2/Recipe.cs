using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand2
{
    class Recipe
    {
        // Member Variables (HAS A)
        public int lemons;
        public int sugar;
        public int ice;
        public double pricePerCup;
        public int cupsMade;
        // Constructor
        public Recipe(Player player, int lemons, int sugar, int ice, double pricePerCup)
        {
            this.lemons = lemons;
            this.sugar = sugar;
            this.ice = ice;
            this.pricePerCup = pricePerCup;
            this.cupsMade = (lemons * 3) + ice;
            if (ice * cupsMade < player.ice)
            {
                cupsMade = player.ice * cupsMade;
                player.ice = 0;
            }
            if (cupsMade > player.cups)
            {
                cupsMade = player.cups;
            }
            
            CalculateDailyItemUsage(player, lemons, sugar, ice, cupsMade);
        }
        // Member Methods (CAN DO)
        public void CalculateDailyItemUsage(Player player, int lemons, int sugar, int ice, int cups)
        {
            player.lemons -= lemons;
            player.sugar -= sugar;
            player.ice -= ice;
            player.cups -= cups;
        }
    }
}
