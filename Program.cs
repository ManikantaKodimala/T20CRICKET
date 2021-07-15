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
            Game game = new Game();
            Console.WriteLine("Team-1 Name:");
            teamName = Console.ReadLine();
            team1 = new Team(teamName);
            Console.WriteLine("Team-1 members name");
            for (int i = 0; i < 11; i++)
            {
                teamMembers[i] = Console.ReadLine().Trim();
            }
            team1.teamMembers = teamMembers;
            Console.WriteLine("Team-2 Name:");
            teamName = Console.ReadLine();
            Console.WriteLine("Team-2 members name");
            for (int i = 0; i < 11; i++)
            {
                teamMembers[i] = Console.ReadLine().Trim();
            }
            team2 = new Team(teamName);
            team2.teamMembers = teamMembers;
            game.StartInnings(team1, totalBalls, totalWickets);
            game.StartInnings(team2, totalBalls, totalWickets);
            if (team1.score == team2.score)
            {
                totalBalls = 6;
                totalWickets = 2;
                team1.wicketsLost = 0;
                team1.score = 0;
                game.StartSuperOver(team1, team2, totalBalls, totalWickets);
                Console.WriteLine("(Target runs : " + (team1.score + 1));
                team2.wicketsLost = 0;
                team2.score = 0;
                game.StartSuperOver(team2, team1, totalBalls, totalWickets);
            }
            if (team1.score > team2.score)
            {
                Console.WriteLine(team1.getTeamName() + " won by " + (team1.score - team2.score) + "Runs 🎉🎉🎉");
            }
            else
            {
                Console.WriteLine(team2.getTeamName() + " won by " + (totalWickets - team2.wicketsLost) + " Wickets 🎉🎉🎉");
            }
        }
    }
}