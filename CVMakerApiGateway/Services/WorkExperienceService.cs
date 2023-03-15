using CVMakerApiGateway.Contracts.Services;
using CVMakerApiGateway.Models;

namespace CVMakerApiGateway.Services
{
    public class WorkExperienceService : IWorkExperienceService
    {
        private readonly HttpClient client;

        public WorkExperienceService(HttpClient client)
        {
            this.client = client;
        }
        public async Task<WorkExperienceDto> AddWorkExperience(AddWorkExperienceDto addWorkExperienceRequest)
        {
            var response = await client.PostAsJsonAsync("/api/WorkExperiences", addWorkExperienceRequest);

            return await response.Content.ReadAsAsync<WorkExperienceDto>();
        }

        public async Task DeleteWorkExperience(int workExperienceId)
        {
            try
            {
                var response = await client.DeleteAsync($"/api/WorkExperiences/{workExperienceId}");

                if (!response.IsSuccessStatusCode)
                {
                    var errorDescription = await response.Content.ReadAsAsync<ErrorDto>();

                    var exception = new BadHttpRequestException(errorDescription.Message, (int)response.StatusCode);

                    throw exception;
                }
            }
            catch (Exception ex)
            {

                throw new Exceptions.WorkExperienceException($"WorkExperience Delete Failed! {ex.Message}");
            }
        }

        public async Task<List<WorkExperienceDto>> GetAllWorkExperiences(string userId)
        {
            var response = await client.GetAsync($"/api/WorkExperiences?userid={userId}");

            return await response.Content.ReadAsAsync<List<WorkExperienceDto>>();
        }

        public async Task<WorkExperienceDto> GetWorkExperience(int workExperienceId)
        {
            try
            {
                var response = await client.GetAsync($"/api/WorkExperiences/{workExperienceId}");

                if (!response.IsSuccessStatusCode)
                {
                    var errorDescription = await response.Content.ReadAsAsync<ErrorDto>();

                    var exception = new BadHttpRequestException(errorDescription.Message, (int)response.StatusCode);

                    throw exception;
                }

                return await response.Content.ReadAsAsync<WorkExperienceDto>();
            }
            catch (Exception ex)
            {

                throw new Exceptions.WorkExperienceException($"{ex.Message}");
            }
        }

        public async Task<WorkExperienceDto> UpdateWorkExperience(WorkExperienceDto updateWorkExperienceRequest)
        {
            try
            {
                var response = await client.PutAsJsonAsync($"/api/WorkExperiences/{updateWorkExperienceRequest.Id}", updateWorkExperienceRequest);

                if (!response.IsSuccessStatusCode)
                {
                    var errorDescription = await response.Content.ReadAsAsync<ErrorDto>();

                    var exception = new BadHttpRequestException(errorDescription.Message, (int)response.StatusCode);

                    throw exception;
                }

                return await response.Content.ReadAsAsync<WorkExperienceDto>();
            }
            catch (Exception ex)
            {

                throw new Exceptions.WorkExperienceException($"WorkExperience Update Failed! {ex.Message}");
            }
        }
    }
}
