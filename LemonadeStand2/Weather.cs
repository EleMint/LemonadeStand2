using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand2
{
    public class Weather
    {
        public double temperature;
        public string skyCondition;
        public double cloudChance;
        public double rainChance;
        public bool clouds;
        public bool rain;

        public Weather()
        {
            Random random = new Random();
            CreateWeather(random);
        }

        public void CreateWeather(Random random)
        {
            cloudChance = (random.Next(1, 100) / 100);
            rainChance = (random.Next(1, 100) / 100);
            temperature = random.Next(65, 100);
            SetClouds(cloudChance);
            SetRain(rainChance, clouds);
            SetSkyCondition(clouds, rain);  
        }

        public void SetClouds(double number)
        {
            if (number > 0.5)
            {
                clouds = true;  
            }
            else
            {
                clouds = false;
            }
        }

        public void SetRain(double number, bool hasClouds)
        {
            if (number > 0.5 && hasClouds)
            {
                rain = true; 
            }
            else
            {
                rain = false; 
            }
        }
        
        public void SetSkyCondition(bool clouds, bool rain)
        {
            if(rain && clouds)
            {
                skyCondition = "Clouds and Rain";
            }
            else if(!rain && clouds)
            {
                skyCondition = "Clouds, No Rain";
            }
            else
            {
                skyCondition = "Clear Skies and Sunny";
            }

        }
    }
}
