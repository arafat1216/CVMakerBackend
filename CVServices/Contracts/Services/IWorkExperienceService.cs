using CVServices.ServiceModels;

namespace CVServices.Contracts.Services
{
    public interface IWorkExperienceService
    {
        Task<WorkExperienceDto> AddWorkExperience(AddWorkExperienceDto addWorkExperienceRequest);
        Task DeleteWorkExperience(int workExperieneId);
        Task<List<WorkExperienceDto>> GetAllWorkExperiences(string userId);
        Task<WorkExperienceDto> GetWorkExperienceById(int workExperieneId);
        Task<WorkExperienceDto> UpdateWorkExperience(WorkExperienceDto updateWorkExperienceRequest);
    }
}
