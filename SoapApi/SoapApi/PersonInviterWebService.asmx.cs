using Newtonsoft.Json;
using SoapApi.Models;
using SoapApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Web;
using System.Web.Services;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace SoapApi
{
    /// <summary>
    /// Summary description for PersonInviterWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class PersonInviterWebService : System.Web.Services.WebService
    {
        public InvitationService InvitationService = new InvitationService();

        [WebMethod]
        public async Task<List<InvitationDto>> GenerateInvitationsFromRestApi(List<Person> persons)
        {
            var invitations = await InvitationService.GenerateInvitations(persons);

            //var json = JsonConvert.SerializeObject(invitations);

            //XNode XmlInvitations = JsonConvert.DeserializeXNode(json, "Root");

            return invitations;
        }
        
    }
}
