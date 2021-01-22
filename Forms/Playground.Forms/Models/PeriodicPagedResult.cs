using Newtonsoft.Json;

namespace Playground.Forms.Models
{
    public class PeriodicPagedResult<T> : PagedResult<T>
    {
        [JsonProperty("dates")]
        public Dates Dates { get; set; }
    }
}