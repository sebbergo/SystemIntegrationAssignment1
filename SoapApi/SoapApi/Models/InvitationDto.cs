using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoapApi.Models
{
    public class InvitationDto
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string InvitationMessage { get; set; }
    }
}