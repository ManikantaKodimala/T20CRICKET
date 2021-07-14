using System;

namespace T20Cricket
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            int totalBalls = 10, totalWickets = 10;
            StartGame team1 = new StartGame("India");
            StartGame team2 = new StartGame("Australia");
            team1.StartInnings(totalBalls, totalWickets);
            team1.ScoreCard();
            team2.StartInnings(totalBalls, totalWickets);
            team2.ScoreCard();
            if (team1.score == team2.score)
            {
                team1.StartSuperOver(6, 2);
                team1.ScoreCard();
                team2.StartSuperOver(6, 2);
                team2.ScoreCard();
            }
            else if (team1.score > team2.score)
            {
                Console.WriteLine("Team India has won the game");
            }
            else
            {
                Console.WriteLine("Team Australia has won the game");
            }

        }
    }
}
