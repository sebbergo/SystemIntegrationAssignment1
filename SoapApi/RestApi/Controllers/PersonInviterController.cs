using Common.Model;
using Microsoft.AspNetCore.Mvc;
using RestApi.Service;

namespace RestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonInviterController : ControllerBase
    {
        private readonly IInvitationService _invitationService;

        public PersonInviterController(IInvitationService invitationService)
        {
            _invitationService = invitationService;
        }

        /// <summary>
        /// Generates invitations for a list of users...
        /// </summary>
        /// <param name="persons"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<InvitationDto>> GenerateInvitations(List<Person> persons)
        {
            var invitations = await _invitationService.GenerateInvitations(persons);
            return invitations;
        }
    }
}