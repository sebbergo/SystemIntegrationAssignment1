using System.Runtime.Serialization;

namespace SoapApi.Models
{
    public class GenderEnum
    {
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
}