using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
namespace T20Cricket
{
    public class Game
    {
        string jsonString;
        List<ResultOfShot> outcomes;
        public Game(string filePath)
        {
            jsonString = File.ReadAllText(filePath);
            outcomes = JsonConvert.DeserializeObject<List<ResultOfShot>>(jsonString);
        }
        private string[] typesOfBolwing = { "Bouncer", "Inswinger", "Outswinger", "OffCutter", "Yorker", "OffBreak", "LegCutter", "SlowerBall", "Pace", "Doosra" };
        private void ScoreCard(Team team)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(team.getTeamName().ToUpper() + " scored : " + team.getScore());
            Console.ForegroundColor = ConsoleColor.Green;
        }
        public int PredictOutcome(string bowledType, string shotSelected, string shortTiming)
        {
            var random = new Random(5);
            foreach (ResultOfShot ball in outcomes)
            {
                if (ball.ballType == bowledType)
                {
                    foreach (ShotType shot in ball.bestShots)
                    {
                        if (shot.shotName == shotSelected)
                        {
                            foreach (Time time in shot.timing)
                            {
                                if (time.timeType == shortTiming)
                                {
                                    return time.outcome[random.Next(0, time.outcome.Count)];
                                }
                            }
                        }
                        else if (shot.shotName == "Default")
                        {
                            return shot.timing[0].outcome[random.Next(0, shot.timing[0].outcome.Count)];
                        }
                    }
                }
            }
            return 0;
        }
        public void DisplayBoard(Team team, int resultOfShot, Commentary commentary)
        {
            if (resultOfShot == -1)
            {
                team.setWicket();
                Console.ForegroundColor = ConsoleColor.Red;
                commentary.CommentaryForShot(resultOfShot);
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                commentary.CommentaryForShot(resultOfShot);
                team.setScore(resultOfShot);
            }
        }
        public void StartInnings(Team team, int totalBalls, int totalWickets)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("START THE MATCH !");
            string[] input;
            int resultOfShot = 0;
            Commentary commentary = new Commentary();
            while (totalBalls > 0 && team.getWickets() < totalWickets)
            {
                input = Console.ReadLine().Trim().Split();
                resultOfShot = PredictOutcome(input[0], input[1], input[2]);
                DisplayBoard(team, resultOfShot, commentary);
                totalBalls -= 1;
            }
            ScoreCard(team);
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
        private void LogBowlingCards(List<string> bolwingCards)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Bowling Cards:");
            Console.ForegroundColor = ConsoleColor.Red;
            foreach (string ballType in bolwingCards)
            {
                Console.WriteLine(ballType);
            }
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(" ");
        }
        private void LogSuperOverCommentary(string bowlerName, string ballType, string shotName, string shotTime, string batsMan)
        {
            Console.WriteLine(bowlerName + " bowled " + ballType + " ball");
            Console.WriteLine(batsMan + " played " + shotTime + " " + shotName + " shot");
        }
        public void StartSuperOver(Team battingTeam, Team bowlingTeam, int totalBalls, int totalWickets)
        {
            string[] input;
            int resultOfShot = 0;
            Commentary commentary = new Commentary();
            Random random = new Random(5);
            string bowlType, bowlerName = bowlingTeam.getTeamMembers()[random.Next(0, 11)];
            string batsMan = battingTeam.getTeamMembers()[random.Next(0, 11)];
            List<string> bolwingCards = GetBowlingCards(typesOfBolwing);

            LogBowlingCards(bolwingCards);
            Console.WriteLine("START SUPER OVER !");
            while (totalBalls > 0 && battingTeam.getWickets() < totalWickets)
            {
                input = Console.ReadLine().Trim().Split();
                bowlType = bolwingCards[6 - totalBalls];
                resultOfShot = PredictOutcome(bowlType, input[0], input[1]);
                LogSuperOverCommentary(bowlerName, bowlType, input[0], input[1], batsMan);
                DisplayBoard(battingTeam, resultOfShot, commentary);
                if (resultOfShot < 0)
                {
                    batsMan = battingTeam.getTeamMembers()[random.Next(0, 11)];
                }
                totalBalls -= 1;
            }
            ScoreCard(battingTeam);
        }
    }
    class ResultOfShot
    {
        [JsonProperty]
        public string ballType { get; private set; }
        [JsonProperty]
        public List<ShotType> bestShots { get; private set; }
    }
    class ShotType
    {
        [JsonProperty]
        public string shotName { get; private set; }

        [JsonProperty]
        public List<Time> timing { get; private set; }

    }
    class Time
    {
        [JsonProperty]
        public string timeType { get; private set; }

        [JsonProperty]
        public List<int> outcome { get; private set; }

    }
}