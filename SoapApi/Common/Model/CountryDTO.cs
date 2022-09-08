using Newtonsoft.Json;

namespace Common.Model
{
    public class CountryDTO
    {
        [JsonProperty("country")]
        public string Country { get; set; }
    }
}
