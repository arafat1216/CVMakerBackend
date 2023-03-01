using CVServices.ServiceModels;

namespace CVServices.Contracts.Services
{
    public interface IProjectService
    {
        Task<ProjectDto> AddProject(AddProjectDto addProjectRequest);
        Task DeleteProject(int projectId);
        Task<List<ProjectDto>> GetAllProjects(string userId);
        Task<ProjectDto> GetProjectById(int projectId);
        Task<ProjectDto> UpdateProject(ProjectDto updateProjectRequest);
    }
}
