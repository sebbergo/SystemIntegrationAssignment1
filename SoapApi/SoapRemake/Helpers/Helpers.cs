using System.Runtime.Serialization;

namespace SoapRemake.Helpers

{
    public class Helpers
    {
        public static class HelperService
        {
            public static string GetGenderTitle(Gender gender)
            {
                string result = "";

                switch (gender)
                {
                    case Gender.Male:
                        result = "Mr.";
                        break;

                    case Gender.Female:
                        result = "Ms.";
                        break;

                    case Gender.NonSpecified:
                        result = "blank";
                        break;
                }

                return result;
            }
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
}