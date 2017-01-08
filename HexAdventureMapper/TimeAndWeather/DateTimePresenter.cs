using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HexAdventureMapper.DataObjects;

namespace HexAdventureMapper.TimeAndWeather
{
    public class DateTimePresenter
    {
        //private static readonly double DaySwingValue = 1.32; //Wymar
        private static readonly double DaySwingValue = 0.66; //Halacia

        public static string GetTimeOfDay(int day, int totalMin)
        {
            //Check whether it is dawn
            var dawnTime = GetSunriseMinute(day);
            
            if (totalMin >= dawnTime - 30 && totalMin < dawnTime - 20)
            {
                return "First Light";
            }
            if (totalMin >= dawnTime - 20 && totalMin < dawnTime - 10)
            {
                return "Dawn";
            }
            if (totalMin >= dawnTime - 10 && totalMin < dawnTime)
            {
                return "Sunrise";
            }

            //Check whether it is dusk
            var duskTime = GetSunsetMinute(day);
            
            if (totalMin >= duskTime + 20 && totalMin < duskTime + 30)
            {
                return "Last Light";
            }
            if (totalMin >= duskTime + 10 && totalMin < duskTime + 20)
            {
                return "Dusk";
            }
            if (totalMin >= duskTime && totalMin < duskTime + 10)
            {
                return "Sunset";
            }

            //Check for midnight and noon

            string timeOfDay = "Beyond Time and Space";

            if (totalMin > 1425 || totalMin < 15)
            {
                timeOfDay = "Midnight";
            }
            else if (totalMin >= 705 && totalMin < 735)
            {
                timeOfDay = "Noon";
            }

            //Find normal time of day

            else if (totalMin >= 1380 || totalMin < 120)
            {
                timeOfDay = "Early Night";
            }
            else if (totalMin >= 120 && totalMin < 300)
            {
                timeOfDay = "Late Night";
            }
            else if (totalMin >= 300 && totalMin < 420)
            {
                timeOfDay = "Early Morning";
            }
            else if (totalMin >= 420 && totalMin < 540)
            {
                timeOfDay = "Morning";
            }
            else if (totalMin >= 540 && totalMin < 660)
            {
                timeOfDay = "Late Morning";
            }
            else if (totalMin >= 660 && totalMin < 780)
            {
                timeOfDay = "Midday";
            }
            else if (totalMin >= 780 && totalMin < 900)
            {
                timeOfDay = "Early Afternoon";
            }
            else if (totalMin >= 900 && totalMin < 1080)
            {
                timeOfDay = "Late Afternoon";
            }
            else if (totalMin >= 1080 && totalMin < 1140)
            {
                timeOfDay = "Early Evening";
            }
            else if (totalMin >= 1140 && totalMin < 1260)
            {
                timeOfDay = "Evening";
            }
            else if (totalMin >= 1260 && totalMin < 1380)
            {
                timeOfDay = "Late Evening";
            }

            //Add day half
            if (totalMin >= dawnTime && totalMin <= duskTime)
            {
                timeOfDay += " (Light)";
            }
            else
            {
                timeOfDay += " (Dark)";
            }

            return timeOfDay;
        }

        public static int GetSunriseMinute(int day)
        {
            var cyklusNum = day;
            if (cyklusNum > 365 / 2) //Adjust the cyckle so it reverses after Winter solstice
            {
                cyklusNum = 365 - cyklusNum;
            }

            //(6am - half the swing in a year (one quarter the year, since the two halves of the year mirror))
            //The other half of the swing will occur after 6am, as we enter the winter months
            var earliestDawn = (6 * 60 - DaySwingValue * 365 / 4);
            // + today's swing, the farther into the cyklus, the later the dawn
            var dawnTime = earliestDawn + (cyklusNum * DaySwingValue);

            return (int) dawnTime;
        }

        public static string GetSunrise(int day)
        {
            return MinuteToTimeString(GetSunriseMinute(day));
        }

        public static int GetSunsetMinute(int day)
        {
            var cyklusNum = day;
            if (cyklusNum > 365 / 2) //Adjust the cyckle so it reverses after Winter solstice
            {
                cyklusNum = 365 - cyklusNum;
            }

            //(6pm + half the swing in a year (one quarter the year, since the two halves of the year mirror))
            //The other half of the swing will occur before 6pm, as we enter the winter months
            var latestDusk = (18 * 60 + DaySwingValue * 365 / 4);
            // - today's swing, the farther into the cyklus, the earlier the dusk
            var duskTime = latestDusk - (cyklusNum * DaySwingValue);

            return (int) duskTime;
        }

        public static string GetSunset(int day)
        {
            return MinuteToTimeString(GetSunsetMinute(day));
        }

        public static bool IsDayTime(Session session)
        {
            var dawnTime = GetSunriseMinute(session.Day);
            var duskTime = GetSunsetMinute(session.Day);
            var totalMin = session.Time.TotalMinutes;

            return totalMin >= dawnTime && totalMin <= duskTime;
        }

        public static string GetOrdinal(int num)
        {
            switch (num % 100)
            {
                case 11:
                case 12:
                case 13:
                    return num + "th";
            }

            switch (num % 10)
            {
                case 1:
                    return num + "st";
                case 2:
                    return num + "nd";
                case 3:
                    return num + "rd";
                default:
                    return num + "th";
            }
        }

        public static string GetMonth(int days)
        {
            int month = days / 30 + 1;
            switch (month)
            {
                case 1:
                    return "Judgement";
                case 2:
                    return "Craft";
                case 3:
                    return "Harvest";
                case 4:
                    return "Books";
                case 5:
                    return "Remembrance";
                case 6:
                    return "Prayer";
                case 7:
                    return "Hearth";
                case 8:
                    return "Stocks";
                case 9:
                    return "Growth";
                case 10:
                    return "Planting";
                case 11:
                    return "Law";
                case 12:
                    return "Mercy";
                default:
                    return "the Festival";
            }
        }

        public static string MinuteToTimeString(int minutes)
        {
            return $"{minutes/60:00}:{minutes%60:00}";
        }
    }
}
