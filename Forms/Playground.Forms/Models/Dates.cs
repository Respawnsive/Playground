using System;
using Newtonsoft.Json;

namespace Playground.Forms.Models
{
    public class Dates
    {
        [JsonProperty("maximum")]
        public DateTimeOffset Maximum { get; set; }

        [JsonProperty("minimum")]
        public DateTimeOffset Minimum { get; set; }
    }
}