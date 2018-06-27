﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand2
{
    class Player
    {
        // Member Variables (HAS A)
        Recipe recipe;
        public double money;
        public double moneyDayBegin;
        public double moneyDayEnd;
        public int cups;
        public int lemons;
        public int sugar;
        public int ice;

        // Constructor
        public Player()
        {
            money = 20.00;
            cups = 0;
            lemons = 0;
            sugar = 0;
            ice = 0;
        }
        // Member Methods (CAN DO)

        public void ShowInventory()
        {
            Console.WriteLine("\r\nYour Inventory:\r\nMoney: {0}\r\nCups: {1}\r\nLemons: {2}\r\nSugar: {3}\r\nIce: {4}", money, cups, lemons, sugar, ice);
        }

        public void InputRecipe(Player player, int inputLemons, int inputSugar, int inputIce, double inputPPC)
        {
            recipe = new Recipe(player, inputLemons, inputSugar, inputIce, inputPPC);
        }
        
    }
}