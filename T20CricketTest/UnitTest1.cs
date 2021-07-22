using Microsoft.VisualStudio.TestTools.UnitTesting;
using T20Cricket;
using System;
namespace T20CricketTest
{
    [TestClass]
    public class UnitTest1
    {
        Random random = new Random(5);
        static Game game = new Game("/Users/kodimalamanikanta/Manikanta/Traning/C#/T20Cricket/outcomes.json");
        [TestMethod]
        public void TestResultOfShotForBouncer()
        {
            int[] runs = { 1, 2, 4 };
            string shotType = "Pull", shortTiming = "Good";
            int expected = runs[random.Next(0, 3)];

            int received = game.PredictOutcome("Bouncer", shotType, shortTiming);

            Assert.AreEqual(expected, received);
        }
        [TestMethod]
        public void TestResultOfShotForInswinger()
        {
            int[] runs = { -1, 0 };
            string shotType = "CoverDrive", shortTiming = "Late";
            int expected = runs[random.Next(0, 2)];

            int received = game.PredictOutcome("InSwinger", shotType, shortTiming);

            Assert.AreEqual(expected, received);
        }
        [TestMethod]
        public void TestResultOfShotForOffBreak()
        {
            int[] runs = { 4 };
            string shotType = "Sweep", shortTiming = "Perfect";
            int expected = 4;

            int received = game.PredictOutcome("OffBreak", shotType, shortTiming);

            Assert.AreEqual(expected, received);
        }
        [TestMethod]
        public void TestResultOfShotForYorker()
        {

            int[] runs = { 0, 1, 2 };
            string shotType = "Straight", shortTiming = "Good";
            int expected = runs[random.Next(0, 3)];

            int received = game.PredictOutcome("Yorker", shotType, shortTiming);

            Assert.AreEqual(expected, received);
        }
        [TestMethod]
        public void TestResultOfShotForOffCutter()
        {
            int[] runs = { 6 };
            string shotType = "CoverDrive", shortTiming = "Perfect";
            int expected = 6;

            int received = game.PredictOutcome("OffCutter", shotType, shortTiming);

            Assert.AreEqual(expected, received);
        }
        [TestMethod]
        public void TestResultOfShotForDoosra()
        {
            int[] runs = { 1, 2, 4 };
            string shotType = "Sweep", shortTiming = "Good";
            int expected = runs[random.Next(0, 3)];

            int received = game.PredictOutcome("Doosra", shotType, shortTiming);

            Assert.AreEqual(expected, received);
        }
    }
}
