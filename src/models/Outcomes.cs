using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

namespace T20Cricket
{
    public class Outcomes
    {
        private string outcomesJsonString;
        private List<Strategy> outcomes;

        public List<Strategy> GetOutcomes(string filePath="./src/resources/Outcomes.json")
        {
            outcomesJsonString = File.ReadAllText(filePath);
            outcomes = JsonConvert.DeserializeObject<List<Strategy>>(outcomesJsonString);
            return outcomes;
        }

    }
}