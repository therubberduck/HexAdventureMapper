using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HexAdventureMapper.DataObjects;

namespace HexAdventureMapper.TimeAndWeather
{
    public class WeatherGenerator
    {
        //https://www.desmos.com/calculator

        public static string GetWeather(Session session)
        {
            string weatherString;

            int temperature = GetTemperature(session.Year, session.Day, session.Time.Hours);
            int rainAmount = GetRainAmount(session.Year, session.Day, session.Time.Hours);

            if (temperature <= 0)
            {
                weatherString = "Freezing weather";
            }
            else if (temperature <= 5)
            {
                weatherString = "Cold weather";
            }
            else if (temperature <= 15)
            {
                weatherString = "Cool weather";
            }
            else if (temperature <= 25)
            {
                weatherString = "Temperate weather";
            }
            else
            {
                weatherString = "Warm weather";
            }

            if (rainAmount == -1)
            {
                weatherString += " with cloudy skies";
            }
            else if (rainAmount == 0)
            {
                weatherString += " with cloud-free skies";
            }
            else if (rainAmount == 1)
            {
                if (temperature <= 0)
                {
                    weatherString += " with sleet";
                }
                else
                {
                    weatherString += " with light rain";
                }
            }
            else if (rainAmount == 2)
            {
                if (temperature <= 0)
                {
                    weatherString += " with snow";
                }
                else
                {
                    weatherString += " with rain";
                }
            }
            else if (rainAmount == 3)
            {
                if (temperature <= 0)
                {
                    weatherString += " with heavy snow";
                }
                else
                {
                    weatherString += " with heavy rain";
                }
            }

            return weatherString;
        }


        private static int GetTemperature(int year, int day, int hour)
        {
            double seed = ((year*365) + day + hour/24) * Math.PI;

            //int dayOffsetFromSummer = 30; //Wyrmicia
            //int majorTemperatureSpan = 30;
            //double medTemperatureSpan = 2.5;
            //double minorTemperatureSpan = 2.5;
            //int averageTemperature = 10;
            int dayOffsetFromSummer = 60; //Halacia
            double majorTemperatureSpan = 17.5;
            double medTemperatureSpan = 2.5;
            double minorTemperatureSpan = 2.5;
            double averageTemperature = 17.5;

            double climateVariationTemperature = Math.Cos((seed - dayOffsetFromSummer)/182.5)*majorTemperatureSpan/
                                              2 + averageTemperature;
            double temperature = climateVariationTemperature +
                                 Math.Cos(seed/7)*minorTemperatureSpan + Math.Cos(seed/13)*medTemperatureSpan;
            return (int) temperature;
        }

        private static int GetRainAmount(int year, int day, int hour)
        {
            double seed = ((year * 365) + day + hour / 24) * Math.PI;

            //double rainByDay = Math.Cos(seed/91.25)*5 + 5 + (Math.Cos(seed/3.66)*Math.Cos(seed/9.33)*Math.Cos(seed/21))*10; //Wyrmicia
            double rainByDay = Math.Cos(seed/91.25)*2.5 - 5 + (Math.Cos(seed/7)*Math.Cos(seed/49)*Math.Cos(seed/37))*25; //Halacia

            int rainAmount;

            if (rainByDay < 0) //There is no rain on this day
            {
                return 0;
            }
            else if (rainByDay < 10) //Light/dust Rain
            {
                rainAmount = 1;
            }
            else if (rainByDay < 20) //Medium Rain
            {
                rainAmount = 2;
            }
            else //Heavy Rain
            {
                rainAmount = 3;
            }

            double hourSeed = (day * 24 + hour) * Math.PI;

            double rainByHour = (Math.Cos(hourSeed / 3) * 6 + Math.Cos(hourSeed / 9) * 5) * Math.Cos(hourSeed / 21);

            if (rainByHour < 0) //There is no rain in this hour
            {
                return -1;
            }

            //Adjust downwards according to rainbyhour. Throughout the day, the rain will ocassionally lessen
            if (rainByHour > 5)
            {
                rainAmount -= 2;
            }
            else if (rainByHour > 2)
            {
                rainAmount -= 1;
            }

            if (rainAmount < 0)
            {
                return -1;
            }
            return rainAmount;
        }
    }
}
