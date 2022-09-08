using Common.Helpers;
using Common.Model;

namespace RestApi.Service
{
    public interface IInvitationService
    {
        public Task<List<InvitationDto>> GenerateInvitations(List<Person> persons);
    }

    public class InvitationService : IInvitationService
    {
        private readonly IApiService _apiService;

        public InvitationService(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<List<InvitationDto>> GenerateInvitations(List<Person> persons)
        {
            var invitations = new List<InvitationDto>();
            foreach (var person in persons)
            {
                var personCountry = await _apiService.GetCountryByIpAddress(person.IpAddress);
                var personGender = await _apiService.GetGenderByName(person.Name, personCountry.Country);

                var gender = personGender.Gender;

                invitations.Add(new InvitationDto
                {
                    Name = person.Name,
                    Title = Helpers.GetGenderTitle(gender)
                });
            }
            return invitations;
        }
    }
}
