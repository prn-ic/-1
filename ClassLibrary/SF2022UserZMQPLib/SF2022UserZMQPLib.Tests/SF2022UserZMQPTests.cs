using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SF2022UserZMQPLib.Tests
{
    [TestClass]
    public class SF2022UserZMQPTests
    {
        [TestMethod]
        public void SimpleAvailablePeriods()
        {
            // arrange
            TimeSpan[] startTimes = new TimeSpan[5];
            startTimes[0] = (new TimeSpan(10, 0, 0));
            startTimes[1] = (new TimeSpan(11, 0, 0));
            startTimes[2] = (new TimeSpan(15, 0, 0));
            startTimes[3] = (new TimeSpan(15, 30, 0));
            startTimes[4] = (new TimeSpan(16, 50, 0));

            int[] duration = new int[5];
            duration[0] = 60;
            duration[1] = 30;
            duration[2] = 10;
            duration[3] = 10;
            duration[4] = 40;

            TimeSpan beginWorkingTime = new TimeSpan(8, 0, 0);
            TimeSpan endWorkingTime = new TimeSpan(18, 0, 0);

            int consultationTime = 30;

            string[] expected =
            {
                "08:00-08:30",
                "08:30-09:00",
                "09:00-09:30",
                "09:30-10:00",
                "11:30-12:00",
                "12:00-12:30",
                "12:30-13:00",
                "13:00-13:30",
                "13:30-14:00",
                "14:00-14:30",
                "14:30-15:00",
                "15:40-16:10",
                "16:10-16:40",
                "17:30-18:00"
            };
            // act
            Calculations calculations = new Calculations();
            string[] actual = calculations.AvailablePeriods(startTimes, duration, beginWorkingTime, endWorkingTime, consultationTime);
            // assert
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ChangeAvailablePeriods()
        {
            // arrange
            TimeSpan[] startTimes = new TimeSpan[3];
            startTimes[0] = (new TimeSpan(9, 30, 0));
            startTimes[1] = (new TimeSpan(12, 0, 0));
            startTimes[2] = (new TimeSpan(15, 0, 0));

            int[] duration = new int[3];
            duration[0] = 30;
            duration[1] = 30;
            duration[2] = 30;

            TimeSpan beginWorkingTime = new TimeSpan(8, 0, 0);
            TimeSpan endWorkingTime = new TimeSpan(18, 0, 0);

            int consultationTime = 30;

            string[] expected =
            {
                "08:00-08:30",
                "08:30-09:00",
                "09:00-09:30",
                "10:00-10:30",
                "10:30-11:00",
                "11:00-11:30",
                "11:30-12:00",
                "12:30-13:00",
                "13:00-13:30",
                "13:30-14:00",
                "14:00-14:30",
                "14:30-15:00",
                "15:30-16:00",
                "16:00-16:30",
                "16:30-17:00",
                "17:00-17:30",
                "17:30-18:00"
            };
            // act
            Calculations calculations = new Calculations();
            string[] actual = calculations.AvailablePeriods(startTimes, duration, beginWorkingTime, endWorkingTime, consultationTime);
            // assert
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void OneHourLaterPeriods()
        {
            // arrange
            TimeSpan[] startTimes = new TimeSpan[5];
            startTimes[0] = (new TimeSpan(9, 0, 0));
            startTimes[1] = (new TimeSpan(11, 0, 0));
            startTimes[2] = (new TimeSpan(13, 0, 0));
            startTimes[3] = (new TimeSpan(15, 0, 0));
            startTimes[4] = (new TimeSpan(17, 0, 0));

            int[] duration = new int[5];
            duration[0] = 60;
            duration[1] = 60;
            duration[2] = 60;
            duration[3] = 60;
            duration[4] = 60;

            TimeSpan beginWorkingTime = new TimeSpan(8, 0, 0);
            TimeSpan endWorkingTime = new TimeSpan(18, 0, 0);

            int consultationTime = 30;

            string[] expected =
            {
                "08:00-08:30",
                "08:30-09:00",
                "10:00-10:30",
                "10:30-11:00",
                "12:00-12:30",
                "12:30-13:00",
                "14:00-14:30",
                "14:30-15:00",
                "16:00-16:30",
                "16:30-17:00"
            };
            // act
            Calculations calculations = new Calculations();
            string[] actual = calculations.AvailablePeriods(startTimes, duration, beginWorkingTime, endWorkingTime, consultationTime);
            // assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
