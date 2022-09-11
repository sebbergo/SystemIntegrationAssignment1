using Newtonsoft.Json;
using SoapApi.HttpUtils;
using SoapApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;

namespace SoapApi.Services
{
    public interface IInvitationService
    {
        Task<List<InvitationDto>> GenerateInvitations(InputInvitationDto inputInvitationDto);
    }
    public class InvitationService : IInvitationService
    {
        private const string PERSON_INVITER_URL = "https://localhost:44344";
        private const string PERSON_INVITER_MEDIA_TYPE = "application/json";
        private IEmailService _emailService = new EmailService();

        public async Task<List<InvitationDto>> GenerateInvitations(InputInvitationDto inputInvitationDto)
        {
            var invitations = new List<InvitationDto>();

            var httpClient = HttpClientInitializer.GetHttpClient(PERSON_INVITER_URL, PERSON_INVITER_MEDIA_TYPE);
            var url = $"{httpClient.BaseAddress}PersonInviter";

            var json = JsonConvert.SerializeObject(inputInvitationDto.Persons);
            var data = new StringContent(json, Encoding.UTF8, PERSON_INVITER_MEDIA_TYPE);

            using (var response = await httpClient.PostAsync(url, data).ConfigureAwait(false))
            {
                if (response.IsSuccessStatusCode)
                {
                    var invitationStringFormat = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    invitations = JsonConvert.DeserializeObject<List<InvitationDto>>(invitationStringFormat);

                    foreach (var invitation in invitations)
                    {
                        invitation.InvitationMessage = $"Dear {invitation.Title}{invitation.Name},\n " +
                                                        $"{inputInvitationDto.InvitationMessage}";

                        // Send the email
                       await _emailService.SendEmailInvitation(invitation).ConfigureAwait(false);

                    }
                    return invitations;
                }
                else
                {
                    throw new Exception("Something went wrong");
                }
            }
        }
    }
}