using System;
using System.Collections.Generic;

namespace T20Cricket
{
    public class SuperOver
    {
        private PredictScore predictScore;
        private Commentary commentary;
        private List<string> bolwingCards;
        private string[] typesOfBolwing = { "Bouncer", "Inswinger", "Outswinger", "OffCutter", "Yorker", "OffBreak", "LegCutter", "SlowerBall", "Pace", "Doosra" };

        private void ScoreCard(Team team)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(team.GetTeamName().ToUpper() + " scored : " + team.GetScore());
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
            string[] input;
            int resultOfShot = 0;
            string bowlType, bowlerName = bowlingTeam.GetATeamMember();
            string batsManName = battingTeam.GetATeamMember();
            Logger log = new Logger();
            log.LogBowlingCards(bolwingCards);

            Console.WriteLine("START SUPER OVER !");
            while (totalBalls > 0 && battingTeam.GetWickets() < totalWickets)
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
            if (team1.GetScore() == team2.GetScore())
            {
                Console.WriteLine("It's a tie");
            }
            else if (team1.GetScore() > team2.GetScore())
            {
                Console.WriteLine(team1.GetTeamName() + " won by " + (team1.GetScore() - team2.GetScore()) + "Runs 🎉🎉🎉");
            }
            else
            {
                Console.WriteLine(team2.GetTeamName() + " won by " + (totalWickets - team2.GetWickets()) + " Wickets 🎉🎉🎉");
            }
        }

        public void SetSuperOver(Team team1, Team team2)
        {
            team1.SetWicket(0);
            team1.SetScore(0);
            team2.SetWicket(0);
            team2.SetScore(0);
            predictScore = new PredictScore();
            commentary = new Commentary();
            bolwingCards = GetBowlingCards(typesOfBolwing);
        }
    }
}