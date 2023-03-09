using CVMakerApiGateway.Contracts.Services;
using CVMakerApiGateway.Models;

namespace CVMakerApiGateway.Services
{
    public class DegreeService : IDegreeService
    {
        private readonly HttpClient client;

        public DegreeService(HttpClient client)
        {
            this.client = client;
        }
        public async Task<DegreeDto> AddDegree(AddDegreeDto addDegreeRequest)
        {
            var response = await client.PostAsJsonAsync("/api/Degrees", addDegreeRequest);

            return await response.Content.ReadAsAsync<DegreeDto>();
        }

        public async Task DeleteDegree(int degreeId)
        {
            try
            {
                var response = await client.DeleteAsync($"/api/Degrees/{degreeId}");

                if (!response.IsSuccessStatusCode)
                {
                    var errorDescription = await response.Content.ReadAsAsync<ErrorDto>();

                    var exception = new BadHttpRequestException(errorDescription.Message, (int)response.StatusCode);

                    throw exception;
                }
            }
            catch (Exception ex)
            {

                throw new Exceptions.DegreeException($"Degree Delete Failed! {ex.Message}");
            }
        }

        public async Task<List<DegreeDto>> GetAllDegrees(string userId)
        {
            var response = await client.GetAsync($"/api/Degrees?userid={userId}");

            return await response.Content.ReadAsAsync<List<DegreeDto>>();
        }

        public async Task<DegreeDto> GetDegreeById(int degreeId)
        {
            try
            {
                var response = await client.GetAsync($"/api/Degrees/{degreeId}");

                if (!response.IsSuccessStatusCode)
                {
                    var errorDescription = await response.Content.ReadAsAsync<ErrorDto>();

                    var exception = new BadHttpRequestException(errorDescription.Message, (int)response.StatusCode);

                    throw exception;
                }

                return await response.Content.ReadAsAsync<DegreeDto>();
            }
            catch (Exception ex)
            {

                throw new Exceptions.DegreeException($"{ex.Message}");
            }
        }

        public async Task<DegreeDto> UpdateDegree(DegreeDto updateDegreeRequest)
        {
            try
            {
                var response = await client.PutAsJsonAsync($"/api/Degrees/{updateDegreeRequest.Id}", updateDegreeRequest);

                if (!response.IsSuccessStatusCode)
                {
                    var errorDescription = await response.Content.ReadAsAsync<ErrorDto>();

                    var exception = new BadHttpRequestException(errorDescription.Message, (int)response.StatusCode);

                    throw exception;
                }

                return await response.Content.ReadAsAsync<DegreeDto>();
            }
            catch (Exception ex)
            {

                throw new Exceptions.DegreeException($"Degree Update Failed! {ex.Message}");
            }
        }
    }
}
