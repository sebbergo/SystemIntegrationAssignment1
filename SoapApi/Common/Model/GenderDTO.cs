using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Common.Model
{
    public class GenderDTO
    {
        [JsonProperty("gender")]
        public Gender Gender { get; set; }
        [JsonProperty("probability")]
        public decimal Probability { get; set; }
    }

    public enum Gender
    {
        [EnumMember(Value = "male")]
        Male = 0,
        [EnumMember(Value = "female")]
        Female = 1,
        [EnumMember(Value = null)]
        NonSpecified = 2
    }
}
