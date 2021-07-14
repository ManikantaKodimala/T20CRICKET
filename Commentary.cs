using System;

namespace T20Cricket
{
    public class Commentary
    {
        Random random = new Random(5);
        public void CommentaryForShot(string shotSelected, int resultOfShot)
        {
            if (resultOfShot == 1)
            {
                string[] commentary = { "Good running between the wickets", "It's a single", "Excellent line and length" };
                Console.WriteLine(commentary[random.Next(0, 3)] + " - " + resultOfShot + " Runs");
            }
            else if (resultOfShot == 2)
            {
                string[] commentary = { "Good running between the wickets", "Converts ones into two" };
                Console.WriteLine(commentary[random.Next(0, 2)] + " - " + resultOfShot + " Runs");
            }
            else if (resultOfShot == 3)
            {
                string[] commentary = { "Good running between the wickets", "Excellent stop at the boundary", "Excellent line and length" };
                Console.WriteLine(commentary[random.Next(0, 3)] + " - " + resultOfShot + " Runs");
            }
            else if (resultOfShot == 4)
            {
                string[] commentary = { "Just over the fielder", "Excellent Short", "Wow that is what we call a short" };
                Console.WriteLine(commentary[random.Next(0, 3)] + " - " + resultOfShot + " Runs");
            }
            else if (resultOfShot == 6)
            {
                string[] commentary = { "That’s massive and out of the ground", "It’s a huge hit" };
                Console.WriteLine(commentary[random.Next(0, 2)] + " - " + resultOfShot + " Runs");
            }
            else if (resultOfShot == -1)
            {
                string[] commentary = { "It's a wicket", "edge and taken" };
                Console.WriteLine(commentary[random.Next(0, 2)] + " - 0 Runs");
            }
            else
            {
                //Console.ForegroundColor = ConsoleColor.Red;
                string[] commentary = { "Excellent bowling", "Good Length", "Excellent line and length" };
                Console.WriteLine(commentary[random.Next(0, 3)] + " - 0 Runs");
                //Console.ForegroundColor = ConsoleColor.Green;
            }
        }
    }
}