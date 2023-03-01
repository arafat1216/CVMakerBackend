using CVMakerApiGateway.Contracts.Services;
using CVMakerApiGateway.Models;

namespace CVMakerApiGateway.Services
{
    public class ProjectService : IProjectService
    {
        private readonly HttpClient client;

        public ProjectService(HttpClient client)
        {
            this.client = client;
        }
        public async Task<ProjectDto> AddProject(AddProjectDto addProjectRequest)
        {
            var response = await client.PostAsJsonAsync("/api/Projects", addProjectRequest);

            return await response.Content.ReadAsAsync<ProjectDto>();
        }

        public async Task DeleteProject(int projectId)
        {
            try
            {
                var response = await client.DeleteAsync($"/api/Projects/{projectId}");

                if (!response.IsSuccessStatusCode)
                {
                    var errorDescription = await response.Content.ReadAsAsync<ErrorDto>();

                    var exception = new BadHttpRequestException(errorDescription.Message, (int)response.StatusCode);

                    throw exception;
                }

            }
            catch (Exception ex)
            {

                throw new Exceptions.ProjectException($"Project Delete Failed! {ex.Message}");
            }
        }

        public async Task<List<ProjectDto>> GetAllProjects(string userId)
        {
            var response = await client.GetAsync($"/api/Projects?userId={userId}");

            return await response.Content.ReadAsAsync<List<ProjectDto>>();
        }

        public async Task<ProjectDto> GetProject(int projectId)
        {
            try
            {
                var response = await client.GetAsync($"/api/Projects/{projectId}");

                if (!response.IsSuccessStatusCode)
                {
                    var errorDescription = await response.Content.ReadAsAsync<ErrorDto>();

                    var exception = new BadHttpRequestException(errorDescription.Message, (int)response.StatusCode);

                    throw exception;
                }

                return await response.Content.ReadAsAsync<ProjectDto>();

            }
            catch (Exception ex)
            {

                throw new Exceptions.ProjectException($"{ex.Message}");
            }
        }

        public async Task<ProjectDto> UpdateProject(ProjectDto updateProjectRequest)
        {
            try
            {
                var response = await client.PutAsJsonAsync($"/api/Projects/{updateProjectRequest.Id}", updateProjectRequest);

                if (!response.IsSuccessStatusCode)
                {
                    var errorDescription = await response.Content.ReadAsAsync<ErrorDto>();

                    var exception = new BadHttpRequestException(errorDescription.Message, (int)response.StatusCode);

                    throw exception;
                }

                return await response.Content.ReadAsAsync<ProjectDto>();

            }
            catch (Exception ex)
            {

                throw new Exceptions.ProjectException($"Project Update Failed! {ex.Message}");
            }
        }
    }
}
