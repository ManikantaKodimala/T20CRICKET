using System;

namespace T20Cricket
{
    public class Game
    {
        private PredictScore predictScore;
        private Logger log;
        private Commentary commentary;
        private Outcomes outcome;

        public Game()
        {
            predictScore = new PredictScore();
            outcome = new Outcomes();
            log = new Logger();
            commentary = new Commentary();
        }

        public void GameResult(Team team1, Team team2)
        {
            int totalWickets = 10;

            if (team1.GetScore() == team2.GetScore())
            {
                Console.WriteLine("It's a tie \n Moving on to Super Over ");
                SuperOverMatch(team1, team2);
                totalWickets = 2;
            }
            if (team1.GetScore() > team2.GetScore())
            {
                Console.WriteLine(team1.GetTeamName() + " won by " + (team1.GetScore() - team2.GetScore()) + "Runs 🎉🎉🎉");
            }
            else
            {
                Console.WriteLine(team2.GetTeamName() + " won by " + (totalWickets - team2.GetWickets()) + " Wickets 🎉🎉🎉");
            }
        }

        public void StartInnings(Team team, int totalBalls, int totalWickets)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string[] input;
            int resultOfShot = 0;
            Console.WriteLine("START THE MATCH !");

            while (totalBalls > 0 && team.GetWickets() < totalWickets)
            {
                input = Console.ReadLine().Trim().Split();
                resultOfShot = predictScore.PredictOutcome(input[0], input[1], input[2], outcome.GetOutcomes());
                log.LogOfEachBall(team, resultOfShot, commentary);
                totalBalls -= 1;
            }
            log.ScoreCard(team);
        }
        
        public void SuperOverMatch(Team team1, Team team2)
        {
            SuperOver superOver = new SuperOver();
            superOver.SetSuperOver(team1, team2);
            superOver.StartSuperOver(team1, team2, 6, 2, outcome.GetOutcomes());
            Console.WriteLine("(Target runs : " + (team1.GetScore() + 1));
            superOver.StartSuperOver(team2, team1, 6, 2, outcome.GetOutcomes());
        }
    }
}