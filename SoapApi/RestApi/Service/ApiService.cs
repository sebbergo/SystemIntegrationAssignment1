using Common.HttpUtils;
using Common.Model;
using Newtonsoft.Json;

namespace RestApi.Service
{
    public interface IApiService
    {
        public Task<CountryDTO> GetCountryByIpAddress(string ipAddress);
        public Task<GenderDTO> GetGenderByName(string name, string countryCode);
    }

    public class ApiService : IApiService
    {
        // Country public service
        private const string COUNTRY_SERVICE_URL = "http://ip-api.com/json/";
        private const string COUNTRY_SERIVICE_MEDIA_TYPE = "application/json";

        // Gender public service
        private const string GENDER_SERVICE_URl = "https://api.genderize.io";
        private const string GENDER_SERVICE_MEDIA_TYPE = "application/json";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<CountryDTO> GetCountryByIpAddress(string ipAddress)
        {
            var httpClient = HttpClientInitializer.GetClient(COUNTRY_SERVICE_URL, COUNTRY_SERIVICE_MEDIA_TYPE);
            var url = $"{httpClient.BaseAddress}{ipAddress}";
            using (var response = await httpClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    var countryStringFormat = await response.Content.ReadAsStringAsync();
                    var countryObj = JsonConvert.DeserializeObject<CountryDTO>(countryStringFormat);

                    return countryObj;
                }
                else
                {
                    throw new Exception("Something went wrong.");
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="countryCode"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<GenderDTO> GetGenderByName(string name, string countryCode)
        {
            var httpClient = HttpClientInitializer.GetClient(GENDER_SERVICE_URl, GENDER_SERVICE_MEDIA_TYPE);
            var url = $"?name={name}&country_id={countryCode}";

            using (var response = await httpClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    var genderStringFormat = await response.Content.ReadAsStringAsync();
                    var genderObj = JsonConvert.DeserializeObject<GenderDTO>(genderStringFormat);
                    return genderObj;
                }
                else
                {
                    throw new Exception("Something went wrong.");
                }
            }
        }




    }
}
