using Microsoft.VisualStudio.TestTools.UnitTesting;
using T20Cricket;
using System;

namespace T20CricketTest
{
    [TestClass]
    public class CommentaryUnitTest
    {
        private Random random = new Random(5);

        [TestMethod]
        public void CommentryForOneRun()
        {
            string[] commentary = new string[3]{
                                        "Good running between the wickets",
                                        "It's a single",
                                        "Excellent line and length"
                                    };
            CommentaryService comment = CommentaryService.GetInstance;
            int score =1;
            string expected = commentary[random.Next(0,commentary.Length)]+" - 1 Run";

            string received =comment.GetCommentaryForShot(score);

            Assert.AreEqual(expected, received);
        }

        [TestMethod]
        public void CommentryForTwoRuns()
        {
            string[] commentary = new string[2]{ "Good running between the wickets",
                                        "Converts ones into two"
                                    };
            CommentaryService comment = CommentaryService.GetInstance;
            int score =2;
            string expected = commentary[random.Next(0,commentary.Length)]+" - 2 Runs";

            string received =comment.GetCommentaryForShot(score);

            Assert.AreEqual(expected, received);
        }

        [TestMethod]
        public void CommentryForThreeRuns()
        {
            string[] commentary = new string[3]{ "Good running between the wickets",
                                        "Excellent stop at the boundary",
                                        "Excellent line and length"
                                    };
            CommentaryService comment = CommentaryService.GetInstance;
            int score =3;
            string expected = commentary[random.Next(0,commentary.Length)]+" - 3 Runs";

            string received =comment.GetCommentaryForShot(score);

            Assert.AreEqual(expected, received);
        }

        [TestMethod]
        public void CommentryForAFour()
        {
            string[] commentary = new string[3]{ "Just over the fielder",
                                        "Excellent Short",
                                        "Wow that is what we call a short"
                                    };
            CommentaryService comment = CommentaryService.GetInstance;
            int score =4;
            string expected = commentary[random.Next(0,commentary.Length)]+" - 4 Runs";

            string received =comment.GetCommentaryForShot(score);

            Assert.AreEqual(expected, received);
        }

        [TestMethod]
        public void CommentryForASix()
        {
            string[] commentary = new string[2]{ "That’s massive and out of the ground",
                                        "It’s a huge hit"
                                    };
            CommentaryService comment = CommentaryService.GetInstance;
            int score =6;
            string expected = commentary[random.Next(0,commentary.Length)]+" - 6 Runs";

            string received =comment.GetCommentaryForShot(score);

            Assert.AreEqual(expected, received);
        }

        [TestMethod]
        public void CommentryForAWicket()
        {
            string[] commentary = new string[2] { "It's a wicket", "This is what we call a ball" };
            CommentaryService comment = CommentaryService.GetInstance;
            int score =-1;
            string expected = commentary[random.Next(0,commentary.Length)]+" - 0 Runs";

            string received =comment.GetCommentaryForShot(score);

            Assert.AreEqual(expected, received);
        }

        [TestMethod]
        public void CommentryForZeroRuns()
        {
            string[] commentary = new string[3]{ "Excellent bowling", "Good Length",
                                        "Excellent line and length"
                                    };
            CommentaryService comment = CommentaryService.GetInstance;
            int score =0;
            string expected = commentary[random.Next(0,commentary.Length)]+" - 0 Runs";

            string received =comment.GetCommentaryForShot(score);

            Assert.AreEqual(expected, received);
        }

    }
}