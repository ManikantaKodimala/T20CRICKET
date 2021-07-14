using System;
namespace T20Cricket
{
    class StartGame : Result
    {
        private string teamName;
        private int totalWicketsOfInnings = 0;
        public int score { get; set; }
        private string[] typesOfBolwing = { "Bouncer", "Inswinger", "Outswinger", "OffCutter", "Yorker", "OffBreak", "LegCutter", "SlowerBall", "Pace", "Doosra" };
        public StartGame(string teamName)
        {
            this.teamName = teamName;
        }
        public void ScoreCard()
        {
            Console.WriteLine(this.teamName + "has scored " + this.score, " By Lossing " + this.totalWicketsOfInnings);
        }
        public int ResultofShot(string bowlType, string shotSelected, string shortTiming)
        {
            int resultOfShot = 0;
            switch (bowlType)
            {
                case "Bouncer":
                    resultOfShot = ResultOfShotForBouncer(shotSelected, shortTiming);
                    break;
                case "Outswinger":
                    resultOfShot = ResultOfShotForOutSwinger(shotSelected, shortTiming);
                    break;
                case "InSwinger":
                    resultOfShot = ResultOfShotForInSwinger(shotSelected, shortTiming);
                    break;
                case "LegCutter":
                    resultOfShot = ResultOfShotForLegCutter(shotSelected, shortTiming);
                    break;
                case "OffBreak":
                    resultOfShot = ResultOfShotForOffBreak(shotSelected, shortTiming);
                    break;
                case "OffCutter":
                    resultOfShot = ResultOfShotForOffCutter(shotSelected, shortTiming);
                    break;
                case "Pace":
                    resultOfShot = ResultOfShotForPace(shotSelected, shortTiming);
                    break;
                case "Yorker":
                    resultOfShot = ResultOfShotForYorker(shotSelected, shortTiming);
                    break;
                case "Doosra":
                    resultOfShot = ResultOfShotForDoosra(shotSelected, shortTiming);
                    break;
                case "SlowerBall":
                    resultOfShot = ResultOfShotForSlower(shotSelected, shortTiming);
                    break;
            }
            return resultOfShot;

        }
        public void StartInnings(int totalBalls, int totalWickets)
        {
            Console.WriteLine("START THE MATCH !");
            string[] input;
            int resultOfShot = 0;
            Commentary commentary = new Commentary();
            while (totalBalls > 0 && totalWicketsOfInnings < totalWickets)
            {
                input = Console.ReadLine().Split();
                resultOfShot = ResultofShot(input[0], input[1], input[2]);
                if (resultOfShot == -1)
                {
                    totalWickets += 1;
                    Console.ForegroundColor = ConsoleColor.Red;
                    commentary.CommentaryForShot(input[0], resultOfShot);
                    Console.ForegroundColor = ConsoleColor.Green;

                }
                else
                {
                    commentary.CommentaryForShot(input[0], resultOfShot);
                    score += resultOfShot;
                }

                totalBalls -= 1;
            }

        }
        public string[] GetBowlingCards(string[] bowlingTypes)
        {
            Random random = new Random();
            string[] ballTypes = { };
            for (int i = 0; i < 6; i++)
            {
                ballTypes[i] = bowlingTypes[random.Next(10)];
            }
            return ballTypes;
        }
        public void StartSuperOver(int totalBalls, int totalWickets)
        {
            totalWicketsOfInnings = 0;
            score = 0;
            Console.WriteLine("START THE MATCH !");
            string[] input;
            int resultOfShot = 0;
            Commentary commentary = new Commentary();
            string[] bolwingCards = GetBowlingCards(typesOfBolwing);
            while (totalBalls > 0 && totalWicketsOfInnings < totalWickets)
            {
                input = Console.ReadLine().Split();
                resultOfShot = ResultofShot(bolwingCards[6 - totalBalls], input[0], input[1]);
                if (resultOfShot == -1)
                {
                    totalWickets += 1;
                    Console.ForegroundColor = ConsoleColor.Red;
                    commentary.CommentaryForShot(input[0], resultOfShot);
                    Console.ForegroundColor = ConsoleColor.Green;

                }
                else
                {
                    commentary.CommentaryForShot(input[0], resultOfShot);
                    score += resultOfShot;
                }

                totalBalls -= 1;
            }

        }

    }
}