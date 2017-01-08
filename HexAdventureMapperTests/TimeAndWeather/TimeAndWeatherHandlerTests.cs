using Microsoft.VisualStudio.TestTools.UnitTesting;
using HexAdventureMapper.TimeAndWeather;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HexAdventureMapper.DataObjects;

namespace HexAdventureMapper.TimeAndWeather.Tests
{
    [TestClass()]
    public class TimeAndWeatherHandlerTests
    {
        [TestMethod()]
        public void ChangeTimesTest1()
        {
            //Arrange
            TimeAndWeatherHandler handler = new TimeAndWeatherHandler(null);
            handler.Session = new Session() {Year = 100, Day = 100, Time = new TimeSpan(0,0,0)};

            //Act
            handler.SubtractTimes(365, 0, 0);

            var year = handler.Session.Year;
            var day = handler.Session.Day;
            var minutes = handler.Session.Time;

            //Assert
            Assert.AreEqual(99, year);
            Assert.AreEqual(100, day);
            Assert.AreEqual(0, minutes.TotalMinutes);
        }

        [TestMethod()]
        public void ChangeTimesTest2()
        {
            //Arrange
            TimeAndWeatherHandler handler = new TimeAndWeatherHandler(null);
            handler.Session = new Session() { Year = 100, Day = 219, Time = new TimeSpan(13, 0, 0) };

            //Act
            handler.SubtractTimes(0, 20, 0);

            var year = handler.Session.Year;
            var day = handler.Session.Day;
            var minutes = handler.Session.Time;

            //Assert
            Assert.AreEqual(100, year);
            Assert.AreEqual(218, day);
            Assert.AreEqual(1020, minutes.TotalMinutes);
        }
    }
}