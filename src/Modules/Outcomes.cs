using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
namespace T20Cricket
{
    public class Outcomes
    {
        private string outcomesJsonString;
        private List<Strategy> outcomes;

        public List<Strategy> GetOutcomes()
        {
            outcomesJsonString = File.ReadAllText("src/resources/Outcomes.json");
            outcomes = JsonConvert.DeserializeObject<List<Strategy>>(outcomesJsonString);
            return outcomes;
        }

    }
}