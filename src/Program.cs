using System;
namespace T20Cricket
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Please Select the one of the form to run application");
            Console.WriteLine(" a.Test Each Module \n b.Test Game");
            String option = Console.ReadLine();
            switch (option)
            {
                case "a":
                    TestModules();
                    break;
                case "b":
                    CompleteMatch();
                    break;
            }
        }
        private static void CompleteMatch()
        {
            int totalBalls = 10, totalWickets = 10;
            string[] teamMembers = new string[11];
            Team team1, team2;
            Game game = new Game("src/resources/Outcomes.json");
            EachModule eachModules = new EachModule();
            team1 = eachModules.SetTeamDetails(1);
            team2 = eachModules.SetTeamDetails(2);
            game.StartInnings(team1, totalBalls, totalWickets);
            game.StartInnings(team2, totalBalls, totalWickets);
            game.GameResult(team1, team2);

        }
        private static void TestModules()
        {
            string option;
            EachModule eachModules = new EachModule();
            while (true)
            {
                Console.WriteLine("Select the module");
                Console.WriteLine(" a.Predict Score \n b.Commentry \n c.Superover");
                option = Console.ReadLine();
                switch (option)
                {
                    case "a":
                        eachModules.PredictionScoreModule();
                        break;
                    case "b":
                        eachModules.CommentaryModule();
                        break;
                    case "c":
                        eachModules.SuperOverModule();
                        break;
                }
            }
        }
    }
}