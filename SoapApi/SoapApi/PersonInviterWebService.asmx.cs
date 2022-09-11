using SoapApi.Models;
using SoapApi.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Services;

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
        public async Task<List<InvitationDto>> GenerateInvitationsFromRestApi(InputInvitationDto inputInvitationDto)
        {
            var invitations = await InvitationService.GenerateInvitations(inputInvitationDto).ConfigureAwait(false); // Configure await false, since this old version can't handle async/await
            return invitations;
        }
    }
}
