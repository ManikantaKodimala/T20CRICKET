using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace T20Cricket.Model
{
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
}