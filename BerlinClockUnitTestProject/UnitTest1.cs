using System;
using BerlinClock.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BerlinClockUnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestRedLightOn()
        {
            var light = new Light()
            {
                IsTurnedOn = true,
                LightColor = Color.Red
            };
            Assert.AreEqual(light.GetStringColor(), "R");
        }
        [TestMethod]
        public void TestLightOff()
        {
            var light = new Light()
            {
                IsTurnedOn = false,
                LightColor = Color.Red
            };
            Assert.AreEqual(light.GetStringColor(), "O");
        }

        [TestMethod]
        public void TestLightRow()
        {
            var row = new LightRow();
            row.CreateRow(Color.Yellow, 24, 5);
            int remainder;
            row.SetLights(17, out remainder);
            var str = row.GetRowOfLightsString();
            Assert.AreEqual(str, "YYYO");
        }

        [TestMethod]
        public void TestLightRowRemainder()
        {
            var row = new LightRow();
            row.CreateRow(Color.Yellow, 24, 5);
            int remainder;
            row.SetLights(17, out remainder);
            var str = row.GetRowOfLightsString();
            Assert.AreEqual(remainder, 2);
        }
    }
}
