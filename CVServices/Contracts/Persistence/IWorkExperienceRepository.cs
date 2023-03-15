using CVServices.Entities;

namespace CVServices.Contracts.Persistence
{
    public interface IWorkExperienceRepository
    {
        Task<WorkExperience> AddWorkExperienceAsync(WorkExperience workExperience);
        Task DeleteWorkExperienceAsync(WorkExperience workExperience);
        Task<List<WorkExperience>> GetAllWorkExperiencesAsync(string userId);
        Task<WorkExperience?> GetWorkExperienceByIdAsync(int workExperienceId);
        Task SaveChanges();
        Task<WorkExperience> UpdateWorkExperienceAsync(WorkExperience workExperience);
        Task<bool> WorkExperienceExistsAsync(int workExperienceId);
    }
}
