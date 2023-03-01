using CVServices.Entities;

namespace CVServices.Contracts.Persistence
{
    public interface IProjectRepository
    {
        Task<Project> AddProjectAsync(Project project);
        Task DeleteProjectAsync(Project project);
        Task<List<Project>> GetAllProjectsAsync(string userId);
        Task<Project?> GetProjectByIdAsync(int projectId);
        Task<bool> ProjectExistsAsync(int projectId);
        Task SaveChanges();
        Task<Project> UpdateProjectAsync(Project project);
    }
}
