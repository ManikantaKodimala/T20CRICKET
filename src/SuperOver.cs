using System;
using System.Collections.Generic;

namespace T20Cricket
{
    public class SuperOver
    {
        private PredictScore predictScore;
        private Commentary commentary;
        private List<string> bolwingCards;
        public enum typesOfBolwing { Bouncer=1, Inswinger, Outswinger, OffCutter, Yorker, OffBreak, LegCutter, SlowerBall, Pace, Doosra };

        private List<string> GetBowlingCards()
        {
            Random random = new Random();
            string[] balls= Enum.GetNames(typeof(typesOfBolwing));
            string ball;
            List<string> ballTypes = new List<string>();
            for (int i = 0; i < 6; i++)
            {
                ball=balls[random.Next(0, 9)];
                ballTypes.Add(ball);
            }
            return ballTypes;
        }

        public void StartSuperOver(Team battingTeam, Team bowlingTeam, int totalBalls, int totalWickets, List<Strategy> outcomes)
        {
            string[] input;
            int resultOfShot = 0;
            string comment,bowlType, bowlerName = bowlingTeam.GetATeamMember();
            string batsManName = battingTeam.GetATeamMember();
            Logger log = new Logger();
            SetSuperOver(battingTeam,bowlingTeam);
            log.LogBowlingCards(bolwingCards);

            Console.WriteLine("START SUPER OVER !");
            while (totalBalls > 0 && battingTeam.GetWickets() < totalWickets)
            {
                input = Console.ReadLine().Trim().Split();
                bowlType = bolwingCards[6 - totalBalls];
                resultOfShot = predictScore.PredictOutcome(bowlType, input[0], input[1], outcomes);
                log.LogSuperOverCommentary(bowlerName, bowlType, input[0], input[1], batsManName);
                comment = commentary.GetCommentaryForShot(resultOfShot);
                log.LogComment(comment);
                if (resultOfShot < 0)
                {
                    batsManName = battingTeam.GetATeamMember();
                    battingTeam.SetWicket();
                }
                totalBalls -= 1;
                battingTeam.SetScore(resultOfShot);
            }
            log.ScoreCard(battingTeam);
        }

        public void SetSuperOver(Team team1, Team team2)
        {
            team1.SetWicket(0);
            team1.SetScore(0);
            team2.SetWicket(0);
            team2.SetScore(0);
            predictScore = new PredictScore();
            commentary = new Commentary();
            bolwingCards = GetBowlingCards();
        }
    }
}