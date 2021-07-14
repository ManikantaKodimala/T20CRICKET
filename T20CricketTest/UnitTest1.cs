using Microsoft.VisualStudio.TestTools.UnitTesting;
using T20Cricket;
using System;
namespace T20CricketTest
{
    [TestClass]
    public class UnitTest1
    {
        Random random = new Random(5);
        Result result = new Result();
        [TestMethod]
        public void TestResultOfShotForBouncerGood()
        {

            int[] runs = { 4, 6 };
            string shotType = "Pull", shortTiming = "Good";
            int expected = runs[random.Next(0, 2)];

            int received = result.ResultOfShotForBouncer(shotType, shortTiming);

            Assert.AreEqual(expected, received);
        }
        [TestMethod]
        public void TestResultOfShotForBouncerEarly()
        {
            string shotType = "Pull", shortTiming = "Early";
            int expected = -1;

            int received = result.ResultOfShotForBouncer(shotType, shortTiming);

            Assert.AreEqual(expected, received);
        }
        [TestMethod]
        public void TestResultOfShotForBouncerLate()
        {
            string shotType = "Pull", shortTiming = "Late";
            int expected = -1;

            int received = result.ResultOfShotForBouncer(shotType, shortTiming);

            Assert.AreEqual(expected, received);
        }
        [TestMethod]
        public void TestResultOfShotForBouncerPerfect()
        {
            int[] runs = { 4, 6 };
            string shotType = "Pull", shortTiming = "Perfect";
            int expected = runs[random.Next(0, 2)];

            int received = result.ResultOfShotForBouncer(shotType, shortTiming);

            Assert.AreEqual(expected, received);
        }
    }
}
