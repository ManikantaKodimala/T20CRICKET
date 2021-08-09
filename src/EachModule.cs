using System;
namespace T20Cricket
{
    class EachModule
    {
        public void SuperOverModule()
        {
            Outcomes outcomeObj = new Outcomes();
            var outcome = outcomeObj.GetOutcomes();
            SuperOver superOver = new SuperOver();
            string[] teamMembers = new string[11];
            int totalBalls = 6, totalWickets = 2;
            Team team1 = new Team(1);
            Team team2 = new Team(2);

            superOver.StartSuperOver(team1, team2, totalBalls, totalWickets, outcome);
            Console.WriteLine("Target runs : " + (team1.GetScore() + 1));
            team2.isSecondInnings = true;
            superOver.StartSuperOver(team2, team1, totalBalls, totalWickets, outcome);
            superOver.SuperOverResult(team1, team2);
        }

        public void PredictionScoreModule()
        {
            PredictScore predictScore = new PredictScore();
            string[] input = Console.ReadLine().Trim().Split();
            Outcomes outcomeObj = new Outcomes();
            var outcome = outcomeObj.GetOutcomes();
            int score;
            Logger log = new Logger();

            score = predictScore.PredictOutcome(input[0], input[1], input[2], outcome);
            log.LogScore(score);
        }

        public void CommentaryModule()
        {
            PredictScore predictScore = new PredictScore();
            Outcomes outcomeObj = new Outcomes();
            var outcome = outcomeObj.GetOutcomes();
            Commentary commentary = new Commentary();
            int score;
            string[] input;

            input = Console.ReadLine().Trim().Split();
            score = predictScore.PredictOutcome(input[0], input[1], input[2], outcome);
            commentary.CommentaryForShot(score);
        }
    }
}