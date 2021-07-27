using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
namespace T20Cricket
{
    public class Game
    {
        private string outcomeJsonFilePath;
        private List<Strategy> outcomes;
        public Game(string filePath)
        {
            outcomeJsonFilePath = filePath;
            SetOutcomes();
        }
        private void SetOutcomes()
        {
            string outcomeJson = File.ReadAllText(outcomeJsonFilePath);
            outcomes = JsonConvert.DeserializeObject<List<Strategy>>(outcomeJson);
        }
        public List<Strategy> GetOutcomes()
        {
            return outcomes;
        }
        private string[] typesOfBolwing = { "Bouncer", "Inswinger", "Outswinger", "OffCutter", "Yorker", "OffBreak", "LegCutter", "SlowerBall", "Pace", "Doosra" };
        public void GameResult(Team team1, Team team2)
        {
            int totalWickets = 10;
            if (team1.getScore() == team2.getScore())
            {
                Console.WriteLine("It's a tie \n Moving on to Super Over ");
                StartSuperOver(team1, team2, ref totalWickets);
            }
            if (team1.getScore() > team2.getScore())
            {
                Console.WriteLine(team1.GetTeamName() + " won by " + (team1.getScore() - team2.getScore()) + "Runs 🎉🎉🎉");
            }
            else
            {
                Console.WriteLine(team2.GetTeamName() + " won by " + (totalWickets - team2.getWickets()) + " Wickets 🎉🎉🎉");
            }
        }
        public void StartInnings(Team team, int totalBalls, int totalWickets)
        {
            PredictScore predictScore = new PredictScore();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("START THE MATCH !");
            string[] input;
            int resultOfShot = 0;
            Logger log = new Logger();
            Commentary commentary = new Commentary();
            while (totalBalls > 0 && team.getWickets() < totalWickets)
            {
                input = Console.ReadLine().Trim().Split();
                resultOfShot = predictScore.PredictOutcome(input[0], input[1], input[2], outcomes);
                log.LogOfEachBall(team, resultOfShot, commentary);
                totalBalls -= 1;
            }
            log.ScoreCard(team);
        }
        public void StartSuperOver(Team team1, Team team2, ref int totalWickets)
        {
            SuperOver superOver = new SuperOver();
            superOver.SetSuperOver(team1, team2);
            totalWickets = 2;
            superOver.StartSuperOver(team1, team2, 6, 2, outcomes);
            Console.WriteLine("(Target runs : " + (team1.getScore() + 1));
            superOver.StartSuperOver(team2, team1, 6, 2, outcomes);
        }
    }
}
