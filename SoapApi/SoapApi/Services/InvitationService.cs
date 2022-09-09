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
       Task<List<InvitationDto>> GenerateInvitations(List<Person> persons);
    }
    public class InvitationService : IInvitationService
    {
        private const string PERSON_INVITER_URL = "https://localhost:44344";
        private const string PERSON_INVITER_MEDIA_TYPE = "application/json";

        public async Task<List<InvitationDto>> GenerateInvitations(List<Person> persons)
        {
            var invitations = new List<InvitationDto>();

            var httpClient = HttpClientInitializer.GetHttpClient(PERSON_INVITER_URL, PERSON_INVITER_MEDIA_TYPE);
            var url = $"{httpClient.BaseAddress}PersonInviter";

            var json = JsonConvert.SerializeObject(persons);
            var data = new StringContent(json, Encoding.UTF8, PERSON_INVITER_MEDIA_TYPE);

            using (var response = await httpClient.PostAsync(url, data))
            {
                if (response.IsSuccessStatusCode)
                {
                    var invitationStringFormat = await response.Content.ReadAsStringAsync();
                    invitations = JsonConvert.DeserializeObject<List<InvitationDto>>(invitationStringFormat);

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