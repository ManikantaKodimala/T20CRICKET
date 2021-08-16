using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

namespace T20Cricket.Model
{
    public static class Outcomes
    {
        private static string outcomesJsonString;
        private static List<Strategy> outcomes;

        public static List<Strategy> GetOutcomes(string filePath = "./src/resources/Outcomes.json")
        {
            outcomesJsonString = File.ReadAllText(filePath);
            outcomes = JsonConvert.DeserializeObject<List<Strategy>>(outcomesJsonString);
            return outcomes;
        }

    }
}