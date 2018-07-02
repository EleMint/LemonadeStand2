using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LemonadeStand2;

namespace LemonadeStandUnitTests
{
    [TestClass]
    public class WeatherTest
    {
        [TestMethod]
        public void CloudsBelow50_SetClouds_NoClouds()
        {
            // Arrange
            Weather weather = new Weather();
            bool expected = false;
            bool actual;
            // Act
            weather.SetClouds(0.25);
            actual = weather.clouds;
            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CloudsAbove50_SetClouds_Clouds()
        {
            // Arrange
            Weather weather = new Weather();
            bool expected = true;
            bool actual;
            // Act
            weather.SetClouds(0.75);
            actual = weather.clouds;
            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void RainBelow50HasClouds_SetRain_NoRainClouds()
        {
            // Arrange
            Weather weather = new Weather();
            bool expected = false;
            bool actual;
            // Act
            weather.SetRain(0.25, true);
            actual = weather.rain;
            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void RainBelow50NoClouds_SetRain_NoRainNoClouds()
        {
            // Arrange
            Weather weather = new Weather();
            bool expected = false;
            bool actual;
            // Act
            weather.SetRain(0.25, false);
            actual = weather.rain;
            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void RainAbove50HasClouds_SetRain_RainClouds()
        {
            // Arrange
            Weather weather = new Weather();
            bool expected = true;
            bool actual;
            // Act
            weather.SetRain(0.75, true);
            actual = weather.rain;
            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void RainAbove50NoClouds_SetRain_NoRainNoClouds()
        {
            // Arrange
            Weather weather = new Weather();
            bool expected = false;
            bool actual;
            // Act
            weather.SetRain(0.75, false);
            actual = weather.rain;
            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void RainAndClouds_SetSkyCondition_RainClouds()
        {
            Weather weather = new Weather();
            string expected = "Clouds and Rain";
            string actual;
            weather.SetSkyCondition(true, true);
            actual = weather.skyCondition;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void RainAndNoClouds_SetSkyCondition_Sunny()
        {
            Weather weather = new Weather();
            string expected = "Clear Skies and Sunny";
            string actual;
            weather.SetSkyCondition(false, true);
            actual = weather.skyCondition;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void NoRainAndClouds_SetSkyCondition_Clouds()
        {
            Weather weather = new Weather();
            string expected = "Clouds, No Rain";
            string actual;
            weather.SetSkyCondition(true, false);
            actual = weather.skyCondition;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void NoRainAndNoClouds_SetSkyCondition_Sunny()
        {
            Weather weather = new Weather();
            string expected = "Clear Skies and Sunny";
            string actual;
            weather.SetSkyCondition(false, false);
            actual = weather.skyCondition;
            Assert.AreEqual(expected, actual);
        }
    }
}


