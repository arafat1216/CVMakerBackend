using CVServices.ServiceModels;

namespace CVServices.Contracts.Services
{
    public interface ISkillService
    {
        Task<SkillDto> AddSkill(AddSkillDto addSkillRequest);
        Task DeleteSkill(int skillId);
        Task<List<SkillDto>> GetAllSkills(string userId);
        Task<SkillDto> GetSkillById(int skillId);
        Task<SkillDto> UpdateSkill(SkillDto updateSkillRequest);
    }
}
