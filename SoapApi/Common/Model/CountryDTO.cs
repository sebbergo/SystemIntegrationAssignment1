using Newtonsoft.Json;

namespace Common.Model
{
    public class CountryDTO
    {
        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }
    }
}
