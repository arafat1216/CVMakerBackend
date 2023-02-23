using CVMakerApiGateway.Contracts.Services;
using CVMakerApiGateway.Models;

namespace CVMakerApiGateway.Services
{
    public class SummaryService : ISummaryService
    {
        private readonly HttpClient client;

        public SummaryService(HttpClient client)
        {
            this.client = client;
        }
        public async Task<SummaryDto> GetSummary(string userId)
        {
            try
            {
                var response = await client.GetAsync($"/api/Summary/{userId}");

                if (!response.IsSuccessStatusCode)
                {
                    var errorDescription = await response.Content.ReadAsAsync<ErrorDto>();

                    var exception = new BadHttpRequestException(errorDescription.Message, (int)response.StatusCode);

                    throw exception;
                }

                return await response.Content.ReadAsAsync<SummaryDto>();
            }
            catch (Exception exception)
            {
                throw new Exceptions.SummaryException(exception.Message);
            }
        }

        public async Task<SummaryDto> UpdateSummary(SummaryDto summary)
        {
            try
            {
                var response = await client.PostAsJsonAsync("/api/Summary", summary);

                if (!response.IsSuccessStatusCode)
                {
                    var errorDescription = await response.Content.ReadAsAsync<ErrorDto>();

                    var exception = new BadHttpRequestException(errorDescription.Message, (int)response.StatusCode);

                    throw exception;
                }

                return await response.Content.ReadAsAsync<SummaryDto>();
            }
            catch (Exception ex)
            {

                throw new Exceptions.SummaryException($"Summary Update Failed! {ex.Message}");
            }
        }
    }
}
