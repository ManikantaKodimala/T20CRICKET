using System.Collections.Generic;

namespace T20Cricket
{
    public class PredictScore
    {
        public int PredictOutcome(string bowledType, string shotSelected, string shotTiming, List<Strategy> outcomes)
        {
            var strategy = new Strategy();
            List<ShotType> bestShots = strategy.GetBestShots(bowledType, outcomes);
            ShotType bestShot = new ShotType();
            bestShot = bestShot.GetPlayableShot(bestShots, shotSelected);
            int score = bestShot.GetScore(bestShot, shotTiming);
            return score;
        }
    }
}