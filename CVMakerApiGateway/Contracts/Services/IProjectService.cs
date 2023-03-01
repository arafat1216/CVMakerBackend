using CVMakerApiGateway.Models;

namespace CVMakerApiGateway.Contracts.Services
{
    public interface IProjectService
    {
        Task<List<ProjectDto>> GetAllProjects(string userId);
        Task<ProjectDto> GetProject(int projectId);
        Task<ProjectDto> AddProject(AddProjectDto addProjectRequest);
        Task<ProjectDto> UpdateProject(ProjectDto updateProjectRequest);
        Task DeleteProject(int projectId);
    }
}
