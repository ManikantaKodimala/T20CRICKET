using System;
namespace T20Cricket
{
    class EachModule
    {
        public Team SetTeamDetails(int teamNumber)
        {
            Console.WriteLine("Team-{0} Name:", teamNumber);
            string teamName = Console.ReadLine();
            Team team = new Team(teamName);
            team.SetTeamMembers();
            return team;
        }
        public void SuperOverModule()
        {
            Outcomes outcomeObj = new Outcomes();
            var outcome = outcomeObj.GetOutcomes();
            SuperOver superOver = new SuperOver();
            string[] teamMembers = new string[11];
            int totalBalls = 6, totalWickets = 2;
            Team team1, team2;
            team1 = SetTeamDetails(1);
            team2 = SetTeamDetails(2);
            superOver.StartSuperOver(team1, team2, totalBalls, totalWickets, outcome);
            Console.WriteLine("Target runs : " + (team1.getScore() + 1));
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
            int score = predictScore.PredictOutcome(input[0], input[1], input[2], outcome);
            Console.WriteLine("{0} - Runs", score);
        }
        public void CommentaryModule()
        {
            PredictScore predictScore = new PredictScore();
            string[] input = Console.ReadLine().Trim().Split();
            Outcomes outcomeObj = new Outcomes();
            var outcome = outcomeObj.GetOutcomes();
            int score = predictScore.PredictOutcome(input[0], input[1], input[2], outcome);
            Commentary commentary = new Commentary();
            commentary.CommentaryForShot(score);
        }
    }
}