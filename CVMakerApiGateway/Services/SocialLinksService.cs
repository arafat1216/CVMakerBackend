using CVMakerApiGateway.Contracts.Services;
using CVMakerApiGateway.Models;

namespace CVMakerApiGateway.Services
{
    public class SocialLinksService : ISocialLinksService
    {
        private readonly HttpClient client;

        public SocialLinksService(HttpClient client)
        {
            this.client = client;
        }
        public async Task<SocialLinkDto> GetSocialLinks(string userId)
        {
            try
            {
                var response = await client.GetAsync($"/api/SocialLinks/{userId}");

                if (!response.IsSuccessStatusCode)
                {
                    var errorDescription = await response.Content.ReadAsAsync<ErrorDto>();

                    var exception = new BadHttpRequestException(errorDescription.Message, (int)response.StatusCode);

                    throw exception;
                }

                return await response.Content.ReadAsAsync<SocialLinkDto>();
            }
            catch (Exception exception)
            {
                throw new Exceptions.ProfileException(exception.Message);
            }
        }

        public async Task<SocialLinkDto> UpdateSocialLinks(SocialLinkDto socialLink)
        {
            try
            {
                var response = await client.PostAsJsonAsync("/api/SocialLinks", socialLink);

                if (!response.IsSuccessStatusCode)
                {
                    var errorDescription = await response.Content.ReadAsAsync<ErrorDto>();

                    var exception = new BadHttpRequestException(errorDescription.Message, (int)response.StatusCode);

                    throw exception;
                }

                return await response.Content.ReadAsAsync<SocialLinkDto>();
            }
            catch (Exception ex)
            {

                throw new Exceptions.ProfileException($"Social Links Update Failed! {ex.Message}");
            }
        }
    }
}
