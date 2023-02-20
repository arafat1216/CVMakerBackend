using CVMakerApiGateway.Contracts.Services;
using CVMakerApiGateway.Models;

namespace CVMakerApiGateway.Services
{
    public class ProfileService : IProfileService
    {
        private readonly HttpClient client;

        public ProfileService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<ProfileDto> GetProfile(string userId)
        {
            try
            {
                var response = await client.GetAsync($"/api/Profile/{userId}");

                if (!response.IsSuccessStatusCode)
                {
                    var errorDescription = await response.Content.ReadAsAsync<ErrorDto>();

                    var exception = new BadHttpRequestException(errorDescription.Message, (int)response.StatusCode);

                    throw exception;
                }

                return await response.Content.ReadAsAsync<ProfileDto>();
            }
            catch (Exception exception)
            {
                throw new Exceptions.ProfileException(exception.Message);
            }

            
        }

        public async Task<ProfileDto> UpdateProfile(ProfileDto profile)
        {
            try
            {
                var response = await client.PostAsJsonAsync("/api/Profile", profile);

                if (!response.IsSuccessStatusCode)
                {
                    var errorDescription = await response.Content.ReadAsAsync<ErrorDto>();

                    var exception = new BadHttpRequestException(errorDescription.Message, (int)response.StatusCode);

                    throw exception;
                }

                return await response.Content.ReadAsAsync<ProfileDto>();
            }
            catch (Exception ex)
            {

                throw new Exceptions.ProfileException($"Profile Update Failed! {ex.Message}");
            }
        }
    }
}
