using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoapApi.Models
{
    public class InputInvitationDto
    {
        public List<Person> Persons = new List<Person>();
        public string InvitationMessage = string.Empty;
    }
}