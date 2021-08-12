using System;
namespace T20Cricket
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            while (true)
            {
            Console.WriteLine("Please Select the one of the form to run application");
                Console.WriteLine(" a.Test Each Module \n b.Test Game\n c.exit");
                string option = Console.ReadLine();
            switch (option)
            {
                case "a":
                    TestModules();
                    break;
                case "b":
                    CompleteMatch();
                    break;
                    case "c":
                        return;
                }
            }
        }

        private static void CompleteMatch()
        {
            int totalBalls = 10, totalWickets = 10;
            string[] teamMembers = new string[11];
            Result resultOfMatch= new Result();
            Team team1 = new Team(1);
            Team team2 = new Team(2);
            Game game = new Game();
            game.StartInnings(team1, totalBalls, totalWickets);
            game.StartInnings(team2, totalBalls, totalWickets);
            bool isSuperover = resultOfMatch.GetGameResult(team1,team2);
            if(isSuperover){
                game.SuperOverMatch(team2, team1);
            }
        }

        private static void TestModules()
        {
            string option;
            EachModule eachModules = new EachModule();
            while (true)
            {
                Console.WriteLine("Select the module");
                Console.WriteLine(" a.Predict Score \n b.Commentry \n c.Superover\n d.exit");
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
                    case "d":
                        return;
                }
            }
        }
    }
}