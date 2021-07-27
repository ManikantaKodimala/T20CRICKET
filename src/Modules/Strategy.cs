using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace T20Cricket
{
    public class Strategy
    {
        [JsonProperty]
        public string ballType { get; private set; }
        [JsonProperty]
        public List<ShotType> bestShots { get; private set; }

        public List<ShotType> GetBestShots(string bowledType, List<Strategy> outcomes)
        {
            foreach (Strategy ball in outcomes)
            {
                if (ball.ballType == bowledType)
                {
                    bestShots = ball.bestShots;
                    return bestShots;
                }
            }
            return bestShots;
        }
    }
    public class ShotType
    {
        [JsonProperty]
        public string shotName { get; private set; }

        [JsonProperty]
        public List<ShotTime> timing { get; private set; }
        public ShotType GetPlayableShot(List<ShotType> bestshots, string shotSelected)
        {
            foreach (ShotType shot in bestshots)
            {
                if (shot.shotName == shotSelected)
                {
                    return shot;
                }
            }
            return bestshots[bestshots.Count - 1];
        }
        public int GetScore(ShotType bestShot, string shortTiming)
        {
            Random random = new Random(5);

            foreach (ShotTime time in bestShot.timing)
            {
                if (time.timeType == shortTiming)
                {
                    return time.outcome[random.Next(0, time.outcome.Count)];
                }
            }
            return bestShot.timing[0].outcome[random.Next(0, bestShot.timing[0].outcome.Count)];
        }

    }
    public class ShotTime
    {
        [JsonProperty]
        public string timeType { get; private set; }

        [JsonProperty]
        public List<int> outcome { get; private set; }

    }
}