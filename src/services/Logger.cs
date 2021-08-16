using System;
using System.Collections.Generic;
using T20Cricket.Model;

namespace T20Cricket.Service
{
    public sealed class LoggerService
    {
        private static readonly LoggerService instance;

        private LoggerService() { }
        static LoggerService()
        {
            instance = new LoggerService();
        }

        public static LoggerService GetInstance
        {
            get
            {
                return instance;
            }
        }
        public void LogComment(string comment){
            Console.WriteLine(comment);
        }
        
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