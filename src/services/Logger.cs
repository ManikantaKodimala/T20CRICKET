using System;
using System.Collections.Generic;

namespace T20Cricket
{
    public class Logger
    {
        public void LogScore(int score)
        {
            Console.WriteLine("{0} - Runs", score);
        }

        public void ScoreCard(Team team)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(team.GetTeamName().ToUpper() + " scored : " + team.GetScore());
            Console.ForegroundColor = ConsoleColor.Green;
        }

        public void LogOfEachBall(Team team, int resultOfShot, Commentary commentary)
        {
            if (resultOfShot == -1)
            {
                team.SetWicket();
                Console.ForegroundColor = ConsoleColor.Red;
                commentary.CommentaryForShot(resultOfShot);
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                commentary.CommentaryForShot(resultOfShot);
                team.SetScore(resultOfShot);
            }
        }

        public void LogBowlingCards(List<string> bolwingCards)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Bowling Cards:");
            Console.ForegroundColor = ConsoleColor.Red;
            foreach (string ballType in bolwingCards)
            {
                Console.WriteLine(ballType);
            }
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(" ");
        }

        public void LogSuperOverCommentary(string bowlerName, string ballType, string shotName, string shotTime, string batsMan)
        {
            Console.WriteLine(bowlerName + " bowled " + ballType + " ball");
            Console.WriteLine(batsMan + " played " + shotTime + " " + shotName + " shot");
        }
    }
}