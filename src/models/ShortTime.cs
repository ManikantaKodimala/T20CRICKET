using System.Collections.Generic;
using Newtonsoft.Json;

namespace T20Cricket.Model
{
    public class ShotTime
    {
        [JsonProperty]
        public string timeType { get; private set; }

        [JsonProperty]
        public List<int> outcome { get; private set; }

    }
}