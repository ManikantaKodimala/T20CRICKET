using System;
using System.Collections.Generic;

namespace T20Cricket
{
    public struct MatchProperties
    {
        public Team battingTeam { get; set; }
        public Team bowlingTeam { get; set; }
        public int totalBalls { get; set; }
        public int totalWickets { get; set; }
        public List<Strategy> outcomes { get; set; }
    }
    public sealed class Game
    {
        private PredictScoreService predictScore;
        private LoggerService log;
        private CommentaryService commentary;

        public Game()
        {
            predictScore = PredictScoreService.GetInstance;
            log = LoggerService.GetInstance;
            commentary = CommentaryService.GetInstance;
        }

        public void StartInnings(MatchProperties matchProperties)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string[] input;
            int resultOfShot = 0;
            string comment;
            Console.WriteLine("START THE MATCH !");

            while (matchProperties.totalBalls > 0 && matchProperties.battingTeam.GetWickets() < matchProperties.totalWickets)
            {
                input = Console.ReadLine().Trim().Split();
                resultOfShot = predictScore.PredictOutcome(input[0], input[1], input[2]);
                comment = commentary.GetCommentaryForShot(resultOfShot);
                log.LogComment(comment);
                if(resultOfShot == -1)
                {
                    matchProperties.battingTeam.SetWicket();
                }
                matchProperties.battingTeam.SetScore(resultOfShot);
                matchProperties.totalBalls -= 1;
            }
            log.ScoreCard(matchProperties.battingTeam);
        }

        public void SuperOverMatch(Team team1, Team team2)
        {
            SuperOver superOver = new SuperOver();
            MatchProperties matchProperties = new MatchProperties();
            matchProperties.battingTeam = team1;
            matchProperties.bowlingTeam = team2;
            matchProperties.totalBalls = 6;
            matchProperties.totalWickets = 2;
            superOver.SetSuperOver(team1, team2);

            superOver.StartSuperOver(matchProperties);
            Console.WriteLine("(Target runs : " + (team1.GetScore() + 1));
            matchProperties.battingTeam = team2;
            matchProperties.bowlingTeam = team1;
            superOver.StartSuperOver(matchProperties);
        }
    }
}