using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand2
{
    static class Store
    {
        // Member Methods (CAN DO)
        public static void BuyProduct(Player player)
        {
            Console.WriteLine("\r\nPrices: Amount < 25 --> $0.07 / Item, 25 <= Amount < 75 --> $0.04 / Item, 75 <= Amount --> $0.03 / Item.\r\nWhat Would You Like To Purchace? (Cups, Lemons, Sugar, Ice)");
            string item = Console.ReadLine().ToLower().Trim();
            switch (item)
            {
                case "cups":
                    bool isValid;
                    do
                    {
                        Console.WriteLine("\r\nHow Many Cups Would You Like To Buy? You have {0} Cups And ${1}.", player.cups, player.money);
                        int amount = int.Parse(Console.ReadLine());
                        isValid = PricePerItem(amount, player);
                        if (isValid)
                        {
                            player.cups += amount;
                        }
                        else
                        {
                            Console.WriteLine("\r\nYou Do Not Have Enough Money");
                        }

                    }
                    while (!isValid);
                    break;
                case "lemons":
                    Console.WriteLine("\r\nHow Many Lemons Would You Like To Buy? You have {0} Lemons And ${1}.", player.lemons, player.money);
                    int amount2 = int.Parse(Console.ReadLine());
                    bool isValid2 = PricePerItem(amount2, player);
                    if (isValid2)
                    {
                        player.lemons += amount2;
                    }
                    else
                    {
                        Console.WriteLine("\r\nYou Do Not Have Enough Money");
                        BuyProduct(player);
                    }
                    break;
                case "sugar":
                    Console.WriteLine("\r\nHow Much Sugar Would You Like To Buy? You have {0} Sugar And ${1}.", player.sugar, player.money);
                    int amount3 = int.Parse(Console.ReadLine());
                    bool isValid3 = PricePerItem(amount3, player);
                    if (isValid3)
                    {
                        player.sugar += amount3;
                    }
                    else
                    {
                        Console.WriteLine("\r\nYou Do Not Have Enough Money");
                        BuyProduct(player);
                    }
                    break;
                case "ice":
                    Console.WriteLine("\r\nHow Much Ice Would You Like To Buy? You have {0} Ice And ${1}.", player.ice, player.money);
                    int amount4 = int.Parse(Console.ReadLine());
                    bool isValid4 = PricePerItem(amount4, player);
                    if (isValid4)
                    {
                        player.ice += amount4;
                    }
                    else
                    {
                        Console.WriteLine("\r\nYou Do Not Have Enough Money");
                        BuyProduct(player);
                    }
                    break;
                default:
                    BuyProduct(player);
                    break;
            }
        }
        public static bool PricePerItem(int itemCount, Player player)
        {
            bool isValid = true;
            if (itemCount > 0 && itemCount < 25)
            {
                isValid = DecreasePlayerMoney(itemCount * 0.07, player);
            }
            else if (itemCount >= 25 && itemCount < 75)
            {
                isValid = DecreasePlayerMoney(itemCount * 0.04, player);
            }
            else if (itemCount >= 75)
            {
                isValid = DecreasePlayerMoney(itemCount * 0.03, player);
            }
            return isValid;
        }
        public static bool DecreasePlayerMoney(double amount, Player player)
        {
            if (player.money - amount < 0)
            {
                return false;
            }
            else
            {
                player.money -= amount;
                return true;
            }
        }
    }
}
