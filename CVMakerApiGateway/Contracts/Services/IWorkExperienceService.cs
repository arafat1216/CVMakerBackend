using CVMakerApiGateway.Models;

namespace CVMakerApiGateway.Contracts.Services
{
    public interface IWorkExperienceService
    {
        Task<List<WorkExperienceDto>> GetAllWorkExperiences(string userId);
        Task<WorkExperienceDto> GetWorkExperience(int workExperienceId);
        Task<WorkExperienceDto> AddWorkExperience(AddWorkExperienceDto addWorkExperienceRequest);
        Task<WorkExperienceDto> UpdateWorkExperience(WorkExperienceDto updateWorkExperienceRequest);
        Task DeleteWorkExperience(int workExperienceId);
    }
}
