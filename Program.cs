using System;
using System.Collections.Generic;
namespace T20Cricket
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            int totalBalls = 20, totalWickets = 10;
            string teamName;
            List<string> teamMembers;
            Team team1, team2;
            Game game = new Game("outcomes.json");

            Console.WriteLine("Team-1 Name:");
            teamName = Console.ReadLine();
            teamMembers = GetTeamMembers();
            team1 = new Team(teamName);
            team1.SetTeamMembers(teamMembers);

            Console.WriteLine("Team-2 Name:");
            teamName = Console.ReadLine();
            teamMembers = GetTeamMembers();
            team2 = new Team(teamName);
            team2.SetTeamMembers(teamMembers);

            game.StartInnings(team1, totalBalls, totalWickets);
            game.StartInnings(team2, totalBalls, totalWickets);

            if (team1.GetScore() == team2.GetScore())
            {
                SetSuperOver(ref totalBalls, ref totalWickets, team1, team2);
                game.StartSuperOver(team1, team2, totalBalls, totalWickets);
                Console.WriteLine("(Target runs : " + (team1.GetScore() + 1));
                game.StartSuperOver(team2, team1, totalBalls, totalWickets);
            }
            if (team1.GetScore() > team2.GetScore())
            {
                Console.WriteLine(team1.GetTeamName() + " won by " + (team1.GetScore() - team2.GetScore()) + "Runs 🎉🎉🎉");
            }
            else
            {
                Console.WriteLine(team2.GetTeamName() + " won by " + (totalWickets - team2.GetWickets()) + " Wickets 🎉🎉🎉");
            }
        }
        private static List<string> GetTeamMembers()
        {
            List<string> teamMembers = new List<string>();
            Console.WriteLine("Team members name:");
            for (int i = 0; i < 11; i++)
            {
                teamMembers.Add(Console.ReadLine().Trim());
            }
            return teamMembers;
        }
        private static void SetSuperOver(ref int totalBalls, ref int totalWickets, Team team1, Team team2)
        {
            totalBalls = 6;
            totalWickets = 2;
            team1.SetWicket(0);
            team1.SetScore(0);
            team2.SetWicket(0);
            team2.SetScore(0);
        }
    }
}