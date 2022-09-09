using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static SoapApi.Models.GenderEnum;

namespace SoapApi.Helpers
{
    public static class Helpers
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
}