using System.Collections.Generic;

namespace T20Cricket
{
    public sealed class PredictScoreService
    {
        private static readonly PredictScoreService instance;

        private PredictScoreService() { }
        static PredictScoreService()
        {
            instance = new PredictScoreService();
        }

        public static PredictScoreService GetInstance
        {
            get
            {
                return instance;
            }
        }
        public int PredictOutcome(string bowledType, string shotSelected, string shotTiming)
        {
            var strategy = new Strategy();

            List<ShotType> bestShots = strategy.GetBestShots(bowledType, Outcomes.GetOutcomes());
            ShotType bestShot = new ShotType();
            bestShot = bestShot.GetPlayableShot(bestShots, shotSelected);
            int score = bestShot.GetScore(bestShot, shotTiming);
            return score;
        }
    }
}