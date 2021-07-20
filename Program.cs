using System;
namespace T20Cricket
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            int totalBalls = 10, totalWickets = 10;
            string teamName;
            string[] teamMembers = new string[11];
            Team team1, team2;
            Game game = new Game("outcomes.json");

            Console.WriteLine("Team-1 Name:");
            teamName = Console.ReadLine();
            team1 = new Team(teamName);
            GetTeamMembers(ref teamMembers);
            team1.setTeamMembers(teamMembers);

            Console.WriteLine("Team-2 Name:");
            teamName = Console.ReadLine();
            team2 = new Team(teamName);
            GetTeamMembers(ref teamMembers);
            team1.setTeamMembers(teamMembers);

            game.StartInnings(team1, totalBalls, totalWickets);
            game.StartInnings(team2, totalBalls, totalWickets);
            if (team1.getScore() == team2.getScore())
            {
                SetSuperOver(ref totalBalls, ref totalWickets, team1, team2);
                game.StartSuperOver(team1, team2, totalBalls, totalWickets);
                Console.WriteLine("(Target runs : " + (team1.getScore() + 1));
                game.StartSuperOver(team2, team1, totalBalls, totalWickets);
            }
            if (team1.getScore() > team2.getScore())
            {
                Console.WriteLine(team1.getTeamName() + " won by " + (team1.getScore() - team2.getScore()) + "Runs 🎉🎉🎉");
            }
            else
            {
                Console.WriteLine(team2.getTeamName() + " won by " + (totalWickets - team2.getWickets()) + " Wickets 🎉🎉🎉");
            }
        }

        private static void GetTeamMembers(ref string[] teamMembers)
        {
            Console.WriteLine("Team members name");
            for (int i = 0; i < 11; i++)
            {
                teamMembers[i] = Console.ReadLine().Trim();
            }

        }
        private static void SetSuperOver(ref int totalBalls, ref int totalWickets, Team team1, Team team2)
        {
            totalBalls = 6;
            totalWickets = 2;
            team1.setWicket(0);
            team1.setScore(0);
            team2.setWicket(0);
            team2.setScore(0);
        }
    }
}