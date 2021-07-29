using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace T20Cricket
{
    public class SuperOver
    {
        private string[] typesOfBolwing = { "Bouncer", "Inswinger", "Outswinger", "OffCutter", "Yorker", "OffBreak", "LegCutter", "SlowerBall", "Pace", "Doosra" };
        private void ScoreCard(Team team)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(team.GetTeamName().ToUpper() + " scored : " + team.getScore());
            Console.ForegroundColor = ConsoleColor.Green;
        }
        private List<string> GetBowlingCards(string[] bowlingTypes)
        {
            Random random = new Random();
            List<string> ballTypes = new List<string>();
            for (int i = 0; i < 6; i++)
            {
                ballTypes.Add(bowlingTypes[random.Next(0, 9)]);
            }
            return ballTypes;
        }


        public void StartSuperOver(Team battingTeam, Team bowlingTeam, int totalBalls, int totalWickets, List<Strategy> outcomes)
        {
            PredictScore predictScore = new PredictScore();
            string[] input;
            int resultOfShot = 0;
            Commentary commentary = new Commentary();
            string bowlType, bowlerName = bowlingTeam.GetATeamMember();
            string batsManName = battingTeam.GetATeamMember();
            List<string> bolwingCards = GetBowlingCards(typesOfBolwing);
            Logger log = new Logger();
            log.LogBowlingCards(bolwingCards);

            Console.WriteLine("START SUPER OVER !");
            while (totalBalls > 0 && battingTeam.getWickets() < totalWickets)
            {
                input = Console.ReadLine().Trim().Split();
                bowlType = bolwingCards[6 - totalBalls];
                resultOfShot = predictScore.PredictOutcome(bowlType, input[0], input[1], outcomes);
                log.LogSuperOverCommentary(bowlerName, bowlType, input[0], input[1], batsManName);
                log.LogOfEachBall(battingTeam, resultOfShot, commentary);
                if (resultOfShot < 0)
                {
                    batsManName = battingTeam.GetATeamMember();
                }
                totalBalls -= 1;
            }
            ScoreCard(battingTeam);
        }
        public void SuperOverResult(Team team1, Team team2)
        {
            int totalWickets = 10;
            if (team1.getScore() == team2.getScore())
            {
                Console.WriteLine("It's a tie");
            }
            else if (team1.getScore() > team2.getScore())
            {
                Console.WriteLine(team1.GetTeamName() + " won by " + (team1.getScore() - team2.getScore()) + "Runs 🎉🎉🎉");
            }
            else
            {
                Console.WriteLine(team2.GetTeamName() + " won by " + (totalWickets - team2.getWickets()) + " Wickets 🎉🎉🎉");
            }
        }
        public void SetSuperOver(Team team1, Team team2)
        {
            team1.setWicket(0);
            team1.setScore(0);
            team2.setWicket(0);
            team2.setScore(0);
        }
    }
}