using System;
namespace T20Cricket
{
    class StartGame : Result
    {
        private string teamName;
        private int totalWicketsOfInnings = 0;
        public int score { get; set; }
        public StartGame(string teamName)
        {
            this.teamName = teamName;
        }
        public void ScoreCard()
        {
            Console.WriteLine(this.teamName + "has scored " + this.score, " By Lossing " + this.totalWicketsOfInnings);
        }
        public void StartInnings(int totalBalls, int totalWickets)
        {
            Console.WriteLine("START THE MATCH !");
            string[] input;
            int res = 0;
            while (totalBalls > 0 && totalWicketsOfInnings < totalWickets)
            {
                input = Console.ReadLine().Split();
                switch (input[0])
                {
                    case "Bouncer":
                        res = ResultOfShotForBouncer(input[1], input[2]);
                        break;
                    case "Outswinger":
                        res = ResultOfShotForOutSwinger(input[1], input[2]);
                        break;
                    case "InSwinger":
                        res = ResultOfShotForInSwinger(input[1], input[2]);
                        break;
                    case "LegCutter":
                        res = ResultOfShotForLegCutter(input[1], input[2]);
                        break;
                    case "OffBreak":
                        res = ResultOfShotForOffBreak(input[1], input[2]);
                        break;
                    case "OffCutter":
                        res = ResultOfShotForOffCutter(input[1], input[2]);
                        break;
                    case "Pace":
                        res = ResultOfShotForPace(input[1], input[2]);
                        break;
                    case "Yorker":
                        res = ResultOfShotForYorker(input[1], input[2]);
                        break;
                    case "Doosra":
                        Console.WriteLine("DOOSRA TYPE");
                        break;
                    case "SlowerBall":
                        Console.WriteLine("SLOWER type");
                        break;
                }
                if (res == -1)
                {
                    totalWickets += 1;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("1 Wicket");
                }
                else
                {
                    Console.WriteLine(res + " Runs");
                    score += res;
                }
                Console.ForegroundColor = ConsoleColor.Green;
                totalBalls -= 1;
            }

        }

    }

}