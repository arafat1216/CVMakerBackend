using CVMakerApiGateway.Models;

namespace CVMakerApiGateway.Contracts.Services
{
    public interface ISkillService
    {
        Task<List<SkillDto>> GetAllSkills(string userId);
        Task<SkillDto> GetSkill(int skillId);
        Task<SkillDto> AddSkill(AddSkillDto addskillRequest);
        Task<SkillDto> UpdateSkill(SkillDto updateSkillRequest);
        Task DeleteSkill(int skillId);

    }
}
