using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace T20Cricket.Model
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
}