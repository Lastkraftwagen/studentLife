using System;
using System.Collections.Generic;
using System.Text;

namespace LabGames.Core
{
    public enum Season
    {
        Spring,
        Summer,
        Autumn,
        Winter
    }
    public enum WeatherType
    {
        Rain = 1,
        Storm = 2,
        Fog = 3,
        Sun = 4,
        Clouds = 5,
        Snow = 6
    }

    public struct Forecast
    {
        public Season Season;
        public int Temperature;
        public WeatherType Weather;
    }
    public static class WeatherManager
    {
        private static Forecast currentForecast;

        static WeatherManager()
        {
            currentForecast = new Forecast()
            {
                Season = Season.Spring,
                Weather = (WeatherType)(new Random().Next(1, 6)),
                Temperature = 13
            };
        }

        public static Forecast NewForecast()
        {
            switch (currentForecast.Season)
            {
                case Season.Spring:
                    break;
                case Season.Summer:
                    break;
                case Season.Autumn:
                    break;
                case Season.Winter:
                    break;
                default:
                    break;
            }
            return currentForecast;
        }

    }
}
