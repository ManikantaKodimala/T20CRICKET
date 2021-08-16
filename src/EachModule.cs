using System;
namespace T20Cricket
{
    class EachModule
    {
        public void SuperOverModule()
        {
            var outcome = Outcomes.GetOutcomes();
            SuperOver superOver = new SuperOver();
            string[] teamMembers = new string[11];
            int totalBalls = 6, totalWickets = 2;
            ResultService resultOfMatch = ResultService.GetInstance;
            Team team1 = new Team(1);
            Team team2 = new Team(2);
            MatchProperties matchProperties = new MatchProperties();
            matchProperties.battingTeam = team1;
            matchProperties.bowlingTeam = team2;
            matchProperties.totalBalls = totalBalls;
            matchProperties.totalWickets = totalWickets;

            superOver.StartSuperOver(matchProperties);
            Console.WriteLine("Target runs : " + (team1.GetScore() + 1));
            team2.isSecondInnings = true;
            matchProperties.battingTeam = team2;
            matchProperties.bowlingTeam = team1;
            superOver.StartSuperOver(matchProperties);
            bool isSuperover = resultOfMatch.GetGameResult(team1,team2);
            if(isSuperover){
                superOver.StartSuperOver(matchProperties);
            }
        }

        public void PredictionScoreModule()
        {
            PredictScoreService predictScore = PredictScoreService.GetInstance;
            InputFormateService inputFormateService = InputFormateService.GetInstance;

            string[] input = inputFormateService.GetInput();
            var outcome = Outcomes.GetOutcomes();
            int score;
            LoggerService log = LoggerService.GetInstance;

            score = predictScore.PredictOutcome(input[0], input[1], input[2]);
            log.LogScore(score);
        }

        public void CommentaryModule()
        {
            PredictScoreService predictScore = PredictScoreService.GetInstance;
            var outcome = Outcomes.GetOutcomes();
            CommentaryService commentary = CommentaryService.GetInstance;
            int score;
            string[] input;
            LoggerService log = LoggerService.GetInstance;
            InputFormateService inputFormateService = InputFormateService.GetInstance;

            input = inputFormateService.GetInput();
            score = predictScore.PredictOutcome(input[0], input[1], input[2]);
            log.LogComment(commentary.GetCommentaryForShot(score));
        }
    }
}