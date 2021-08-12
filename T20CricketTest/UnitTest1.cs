using Microsoft.VisualStudio.TestTools.UnitTesting;
using T20Cricket;
using System;

namespace T20CricketTest
{
    [TestClass]
    public class UnitTest1
    {
        Random random = new Random(5);
        static Game game = new Game();
        static Outcomes outcomes = new Outcomes();
        static PredictScore predictScore = new PredictScore();

        [TestMethod]
        public void TestResultOfShotForBouncer()
        {

            int[] runs = { 1, 2, 4 };
            string shotType = "Pull", shortTiming = "Good";
            int expected = runs[random.Next(0, 3)];

            int received = predictScore.PredictOutcome("Bouncer", shotType, shortTiming, outcomes.GetOutcomes("../../src/resources/Outcomes.json"));

            Console.WriteLine(expected);
            Console.WriteLine(received);
            Assert.AreEqual(expected, received);
        }

        [TestMethod]
        public void TestResultOfShotForOutSwinger()
        {

            int[] runs = { 1, 2};
            string shotType = "CoverDrive", shortTiming = "Good";
            int expected = runs[random.Next(0, 2)];

            int received = predictScore.PredictOutcome("OutSwinger", shotType, shortTiming, outcomes.GetOutcomes("../../src/resources/Outcomes.json"));

            Console.WriteLine(expected);
            Console.WriteLine(received);
            Assert.AreEqual(expected, received);
        }

        [TestMethod]
        public void TestResultOfShotForInswinger()
        {

            int[] runs = { -1, 0 };
            string shotType = "CoverDrive", shortTiming = "Late";
            int expected = runs[random.Next(0, 2)];

            int received = predictScore.PredictOutcome("InSwinger", shotType, shortTiming, outcomes.GetOutcomes("../../src/resources/Outcomes.json"));
            Console.WriteLine(expected);
            Console.WriteLine(received);
            Assert.AreEqual(expected, received);
        }

        [TestMethod]
        public void TestResultOfShotForLegCutter()
        {

            int[] runs = { -1, 0 };
            string shotType = "Sweep", shortTiming = "Late";
            int expected = runs[random.Next(0, 2)];

            int received = predictScore.PredictOutcome("LegCutter", shotType, shortTiming, outcomes.GetOutcomes("../../src/resources/Outcomes.json"));
            Console.WriteLine(expected);
            Console.WriteLine(received);
            Assert.AreEqual(expected, received);
        }

        [TestMethod]
        public void TestResultOfShotForOffBreak()
        {

            int[] runs = { 4 };
            string shotType = "Sweep", shortTiming = "Perfect";
            int expected = 4;

            int received = predictScore.PredictOutcome("OffBreak", shotType, shortTiming, outcomes.GetOutcomes("../../src/resources/Outcomes.json"));
            Console.WriteLine(expected);
            Console.WriteLine(received);
            Assert.AreEqual(expected, received);
        }
        
        [TestMethod]
        public void TestResultOfShotForYorker()
        {

            int[] runs = { 0, 1, 2 };
            string shotType = "Straight", shortTiming = "Good";
            int expected = runs[random.Next(0, 3)];

            int received = predictScore.PredictOutcome("Yorker", shotType, shortTiming, outcomes.GetOutcomes("../../src/resources/Outcomes.json"));
            Console.WriteLine(expected);
            Console.WriteLine(received);
            Assert.AreEqual(expected, received);
        }

        [TestMethod]
        public void TestResultOfShotForOffCutter()
        {

            int[] runs = { 6 };
            string shotType = "CoverDrive", shortTiming = "Perfect";
            int expected = 6;

            int received = predictScore.PredictOutcome("OffCutter", shotType, shortTiming, outcomes.GetOutcomes("../../src/resources/Outcomes.json"));
            Console.WriteLine(expected);
            Console.WriteLine(received);
            Assert.AreEqual(expected, received);
        }

        [TestMethod]
        public void TestResultOfShotForSlowerBall()
        {

            int[] runs = { 6 };
            string shotType = "Pull", shortTiming = "Perfect";
            int expected = 6;

            int received = predictScore.PredictOutcome("SlowerBall", shotType, shortTiming, outcomes.GetOutcomes("../../src/resources/Outcomes.json"));
            Console.WriteLine(expected);
            Console.WriteLine(received);
            Assert.AreEqual(expected, received);
        }

        [TestMethod]
        public void TestResultOfShotForPace()
        {

            int[] runs = { 4 };
            string shotType = "Straight", shortTiming = "Perfect";
            int expected = 4;

            int received = predictScore.PredictOutcome("Pace", shotType, shortTiming, outcomes.GetOutcomes("../../src/resources/Outcomes.json"));
            Console.WriteLine(expected);
            Console.WriteLine(received);
            Assert.AreEqual(expected, received);
        }

        [TestMethod]
        public void TestResultOfShotForDoosra()
        {

            int[] runs = { 1, 2, 4 };
            string shotType = "Sweep", shortTiming = "Good";
            int expected = runs[random.Next(0, 3)];

            int received = predictScore.PredictOutcome("Doosra", shotType, shortTiming, outcomes.GetOutcomes("../../src/resources/Outcomes.json"));
            Console.WriteLine(expected);
            Console.WriteLine(received);
            Assert.AreEqual(expected, received);
        }

    }
}