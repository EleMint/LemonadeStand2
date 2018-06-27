using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand2
{
    class Weather
    {
        // Member Variables (HAS A)
        public double chanceOfRain;
        public double chanceOfClouds;
        public double temperature;
        public string skyCondition;
        public bool clouds;
        public bool rain;
        // Constructor
        public Weather()
        {
            
            Random random = new Random();
            double randomNum = random.Next(1, 100);
            double randomNum2 = random.Next(1, 100);
            temperature = random.Next(65, 100);
            chanceOfClouds = randomNum / 100;
            if (chanceOfClouds > 0.5)
            {
                clouds = true;
                skyCondition += "Clouds ";
            }
            else
            {
                clouds = false;
                skyCondition += "Clear Skies Sunny ";
            }
            chanceOfRain = randomNum2 / 100;
            if (chanceOfRain > 0.5 && clouds)
            {
                rain = true;
                skyCondition += "Rain ";
            }
            else
            {
                rain = false;
                skyCondition += "No Rain ";
            }
        }
    }
}
