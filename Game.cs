using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
namespace T20Cricket
{
    class Game
    {
        static string outComesFileName = "Outcomes.json";
        static string jsonString = File.ReadAllText(outComesFileName);
        static List<ResultOfShot> dict = JsonConvert.DeserializeObject<List<ResultOfShot>>(jsonString);
        private string[] typesOfBolwing = { "Bouncer", "Inswinger", "Outswinger", "OffCutter", "Yorker", "OffBreak", "LegCutter", "SlowerBall", "Pace", "Doosra" };
        public void ScoreCard(Team team)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(team.getTeamName().ToUpper() + " scored : " + team.score);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
        }
        public int PredictOutcome(string bowlType, string shotSelected, string shortTiming)
        {
            Random random = new Random(5);
            foreach (ResultOfShot item in dict)
            {
                if (item.ballType == bowlType)
                {
                    foreach (ShotType shot in item.bestshots)
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
                team.wicketsLost += 1;
                Console.ForegroundColor = ConsoleColor.Red;
                commentary.CommentaryForShot(resultOfShot);
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                commentary.CommentaryForShot(resultOfShot);
                team.score += resultOfShot;
            }
        }
        public void StartInnings(Team team, int totalBalls, int totalWickets)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("START THE MATCH !");
            string[] input;
            int resultOfShot = 0;
            Commentary commentary = new Commentary();
            while (totalBalls > 0 && team.wicketsLost < totalWickets)
            {
                input = Console.ReadLine().Trim().Split();
                resultOfShot = PredictOutcome(input[0], input[1], input[2]);
                DisplayBoard(team, resultOfShot, commentary);
                totalBalls -= 1;
            }
            ScoreCard(team);
        }
        public List<string> GetBowlingCards(string[] bowlingTypes)
        {
            Random random = new Random();
            List<string> ballTypes = new List<string>();
            for (int i = 0; i < 6; i++)
            {
                ballTypes.Add(bowlingTypes[random.Next(0, 9)]);
            }
            return ballTypes;
        }
        public void StartSuperOver(Team battingTeam, Team bowlingTeam, int totalBalls, int totalWickets)
        {
            string[] input;
            int resultOfShot = 0;
            Commentary commentary = new Commentary();
            Random random = new Random(5);
            string bowlType, bowlerName = bowlingTeam.teamMembers[random.Next(0, 11)];
            string batsMan = battingTeam.teamMembers[random.Next(0, 11)];
            List<string> bolwingCards = GetBowlingCards(typesOfBolwing);

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Bowling Cards:");
            Console.ForegroundColor = ConsoleColor.Red;
            foreach (string ballType in bolwingCards)
            {
                Console.WriteLine(ballType);
            }
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(" ");
            Console.WriteLine("START SUPER OVER !");
            while (totalBalls > 0 && battingTeam.wicketsLost < totalWickets)
            {
                input = Console.ReadLine().Trim().Split();
                bowlType = bolwingCards[6 - totalBalls];
                resultOfShot = PredictOutcome(bowlType, input[0], input[1]);
                Console.WriteLine(bowlerName + " bowled " + bowlType + " ball");
                Console.WriteLine(batsMan + " played " + input[1] + " " + input[0] + " shot");
                DisplayBoard(battingTeam, resultOfShot, commentary);
                if (resultOfShot < 0)
                {
                    batsMan = battingTeam.teamMembers[random.Next(0, 11)];
                }
                totalBalls -= 1;
            }
            ScoreCard(battingTeam);
        }
    }
    class ResultOfShot
    {
        public string ballType;
        public List<ShotType> bestshots;
    }
    class ShotType
    {
        public string shotName;
        public List<Time> timing;
    }
    class Time
    {
        [JsonProperty]
        public string timeType;
        public List<int> outcome;
    }
}