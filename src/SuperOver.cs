using System;
using System.Collections.Generic;

namespace T20Cricket
{
    public class SuperOver
    {
        private PredictScoreService predictScore;
        private CommentaryService commentary;
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

        public void StartSuperOver(MatchProperties matchProperties)
        {
            string[] input;
            int resultOfShot = 0;
            string comment, bowlType, bowlerName = matchProperties.bowlingTeam.GetATeamMember();
            string batsManName = matchProperties.battingTeam.GetATeamMember();
            LoggerService log = LoggerService.GetInstance;
            InputFormateService inputFormateService = InputFormateService.GetInstance;
            SetSuperOver(matchProperties.battingTeam, matchProperties.bowlingTeam);
            log.LogBowlingCards(bolwingCards);

            Console.WriteLine("START SUPER OVER !");
            while (matchProperties.totalBalls > 0 && matchProperties.battingTeam.GetWickets() < matchProperties.totalWickets)
            {
                input = inputFormateService.GetInput();
                bowlType = bolwingCards[6 - matchProperties.totalBalls];
                resultOfShot = predictScore.PredictOutcome(bowlType, input[0], input[1]);
                log.LogSuperOverCommentary(bowlerName, bowlType, input[0], input[1], batsManName);
                comment = commentary.GetCommentaryForShot(resultOfShot);
                log.LogComment(comment);
                if (resultOfShot < 0)
                {
                    batsManName = matchProperties.battingTeam.GetATeamMember();
                    matchProperties.battingTeam.SetWicket();
                }
                matchProperties.totalBalls -= 1;
                matchProperties.battingTeam.SetScore(resultOfShot);
            }
            log.ScoreCard(matchProperties.battingTeam);
        }

        public void SetSuperOver(Team team1, Team team2)
        {
            team1.SetWicket(0);
            team1.SetScore(0);
            team2.SetWicket(0);
            team2.SetScore(0);
            predictScore = PredictScoreService.GetInstance;
            commentary = CommentaryService.GetInstance;
            bolwingCards = GetBowlingCards();
        }
    }
}