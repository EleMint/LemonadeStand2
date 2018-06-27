using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand2
{
    static class UserInterface
    {
        public static void ShowIntroduction()
        {
            Console.WriteLine("\t Welcome To Your Lemonade Stand\r\nBuy Materials, Make Lemonade, And (Hopefully) Make Money.\r\nHow Much Money Can You Make At The End Of The Game?");
        }
        public static void ShowInstructions()
        {
            //TODO: Write Instructions
            Console.WriteLine("\r\nInstructions Here");
            Console.ReadLine();
        }

        public static int AskGameLength()
        {
            Console.WriteLine("\r\nHow Many Days Would You Like To Play For? ('7' (Default), '14', or '21')");
            string gameLength = Console.ReadLine().Trim().ToLower();
            if (gameLength == "7" || gameLength == "14" || gameLength == "21")
            {
                return int.Parse(gameLength);
            }

            return 7;

        }

        public static string AskToBuyProduct(Player player)
        {
            player.ShowInventory();
            Console.WriteLine("\r\nIs There Anything You'd Like To Buy?");
            string userAnswer = Console.ReadLine().ToLower().Trim();
            switch (userAnswer)
            {
                case "yes":
                    Store.BuyProduct(player);
                    return "yes";
                case "no":
                    return "no";
                default:
                    AskToBuyProduct(player);
                    return "yes";
            }
        }
        public static void AskForRecipe(Player player)
        {
            int inputLemons = AskForRecipeLemons(player);
            int inputSugar = AskForRecipeSugar(player);
            int inputIce = AskForRecipeIce(player);
            double inputPPC = AskForRecipePPC(player);
            player.InputRecipe(player, inputLemons, inputSugar, inputIce, inputPPC);

        }
        public static int AskForRecipeLemons(Player player)
        {
            Console.WriteLine("\r\nTime To Input Your Lemonade Recipe:\r\nHow Many Lemons Would You Like To Use? You Currently Have: {0}", player.lemons);
            int inputLemons = int.Parse(Console.ReadLine().Trim());
            while (inputLemons > player.lemons)
            {
                Console.WriteLine("\r\nYou Do Not Have {0} Lemons, Please Enter An Amount Less Than Or Equal To How Many Lemons You Currently Have.", inputLemons);
                Console.WriteLine("\r\nHow Many Lemons Would You Like To Use?");
                inputLemons = int.Parse(Console.ReadLine().Trim());
            }
            return inputLemons;
        }
        public static int AskForRecipeSugar(Player player)
        {
            Console.WriteLine("\r\nHow Much Sugar Would You Like To Use? You Currently Have: {0}", player.sugar);
            int inputSugar = int.Parse(Console.ReadLine().Trim());
            while (inputSugar > player.sugar)
            {
                Console.WriteLine("You Do Not Have {0} Sugar, Please Enter An Amount Less Than Or Equal To How Many Sugar You Currently Have.", inputSugar);
                Console.WriteLine("How Much Sugar Would You Like To Use?");
                inputSugar = int.Parse(Console.ReadLine().Trim());
            }
            return inputSugar;
        }
        public static int AskForRecipeIce(Player player)
        {
            Console.WriteLine("\r\nHow Many Ice Cubes Would You Like To Use Per Cup? You Currently Have: {0}", player.ice);
            int inputIce = int.Parse(Console.ReadLine().Trim());
            while (inputIce > player.ice)
            {
                Console.WriteLine("\r\nYou Do Not Have {0} Ice, Please Enter An Amount Less Than Or Equal To How Much Ice You Currently Have.", inputIce);
                Console.WriteLine("\r\nHow Much Ice Would You Like To Use?");
                inputIce = int.Parse(Console.ReadLine().Trim());
            }
            return inputIce;
        }
        public static double AskForRecipePPC(Player player)
        {
            Console.WriteLine("\r\nHow Much Do You Want To Sell Each Cup Of Lemonade For?");
            double inputPPC = double.Parse(Console.ReadLine().Trim());
            while (inputPPC <= 0)
            {
                Console.WriteLine("\r\nYour Price Per Cup Needs To Be Greater Than '0'");
                Console.WriteLine("\r\nHow Much Do You Want To Sell Each Cup Of Lemonade For?");
                inputPPC = double.Parse(Console.ReadLine().Trim());
            }
            return inputPPC;
        }

        public static void ShowCurrentDay(int currentDay, Player player, Weather weather)
        {
            Console.WriteLine("\r\nBeginning of Day {0}", currentDay);
            ShowWeatherForecast(weather);
        }
        public static void ShowWeatherForecast(Weather weather)
        {
            Console.WriteLine("\r\nCurrent Weather Forcast:\r\nForcasted Temperature - {0}\r\nForcasted Sky Condition - {1}", weather.temperature, weather.skyCondition);
        }

        public static void ShowEndOfDayTotal(Day day, Player player)
        {
            day.EndOfDayTotal(day, player);
        }
        public static void ShowEndOfGameTotal(Player player)
        {
            if (player.money > 20)
            {
                Console.WriteLine("\r\nIn Total, You Made: ${0}", (player.money - 20));
            }
            else if (player.money == 20)
            {
                Console.WriteLine("\r\nIn Total, You Broke Even");
            }
            else if (player.money < 20)
            {
                Console.WriteLine("\r\nIn Total, You Lost: ${0}", (20 - player.money));
            }
        }

        public static void AskToPlayAgain()
        {
            Console.WriteLine("\r\nWould You Like To Play Again?");
            string userInput = Console.ReadLine().ToLower().Trim();
            switch (userInput)
            {
                case "yes":
                    Console.Clear();
                    Game newGame = new Game();
                    newGame.RunGame();
                    break;
                case "no":
                    Console.WriteLine("\r\nThanks For Playing!");
                    Console.ReadLine();
                    Environment.Exit(0);
                    break;
                default:
                    AskToPlayAgain();
                    break;
            }
        }
        public static void ShowCustomerPurchase(Customer customer, Player player, Recipe recipe)
        {
            
            if (customer.numberOfCustomerBuying >= recipe.cupsMade)
            {
                Console.WriteLine("{0} Customers Bought Your Lemonade For A Total Of ${1}", recipe.cupsMade, recipe.pricePerCup);
            }
            else
            {
                Console.WriteLine("{0} Customers Bought Your Lemonade For A Total Of ${1}", Math.Floor(customer.numberOfCustomerBuying), recipe.pricePerCup);
            }

        }
    }
}
