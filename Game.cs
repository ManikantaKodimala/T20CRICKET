using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace T20Cricket
{
    class Game
    {
        private Hashtable outComes = new Hashtable();
        private string[] typesOfBolwing = { "Bouncer", "Inswinger", "Outswinger", "OffCutter", "Yorker", "OffBreak", "LegCutter", "SlowerBall", "Pace", "Doosra" };
        public Game(string filePath = "outcomes.json")
        {
            string jsonString = File.ReadAllText(filePath);
            List<ResultOfShot> jsonValues = JsonConvert.DeserializeObject<List<ResultOfShot>>(jsonString);
            getOutComes(jsonValues);
        }
        private void getOutComes(List<ResultOfShot> jsonValues)
        {
            foreach (ResultOfShot ball in jsonValues)
            {
                var bestShots = new Hashtable();
                foreach (ShotType shot in ball.bestShots)
                {
                    var timings = new Hashtable();
                    foreach (ShotTime time in shot.timing)
                    {
                        timings.Add(time.timeType, time.outcome);
                    }
                    bestShots.Add(shot.shotName, timings);
                }
                outComes.Add(ball.ballType, bestShots);
            }
        }
        public int PredictOutcome(string bowledType, string selectedShot, string selectedShotTime)
        {
            var random = new Random(5);
            Hashtable timing;
            List<int> result;
            if (outComes.ContainsKey(bowledType))
            {
                Hashtable bestShots = (Hashtable)outComes[bowledType];
                if (bestShots.ContainsKey(selectedShot))
                {
                    timing = (Hashtable)bestShots[selectedShot];
                    if (timing.ContainsKey(selectedShotTime))
                    {
                        result = (List<int>)timing[selectedShotTime];
                        return result[random.Next(0, result.Count)];
                    }
                    else
                    {
                        return -2;
                    }
                }
                else
                {
                    timing = (Hashtable)bestShots["Default"];
                    result = (List<int>)timing["Any"];
                    return result[random.Next(0, result.Count)];
                }
            }
            else
            {
                return -3;
            }
        }
        private void ScoreCard(Team team)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(team.getTeamName().ToUpper() + " scored : " + team.getScore());
            Console.ForegroundColor = ConsoleColor.Green;
        }
        public void DisplayBoard(Team team, int resultOfShot, Commentary commentary)
        {
            if (resultOfShot == -3)
            {
                Console.WriteLine("Please provide Correct correct ball type");
            }
            else if (resultOfShot == -2)
            {
                Console.WriteLine("Please provide Correct timing of short");
            }
            else if (resultOfShot == -1)
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
        public List<ShotTime> timing { get; private set; }

    }
    class ShotTime
    {
        [JsonProperty]
        public string timeType { get; private set; }

        [JsonProperty]
        public List<int> outcome { get; private set; }

    }

}