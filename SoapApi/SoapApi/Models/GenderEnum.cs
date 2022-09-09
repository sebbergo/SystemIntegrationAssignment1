using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

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