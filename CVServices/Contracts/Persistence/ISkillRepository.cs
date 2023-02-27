using CVServices.Entities;

namespace CVServices.Contracts.Persistence
{
    public interface ISkillRepository
    {
        Task<Skill> AddSkillAsync(Skill skill);
        Task DeleteSkillAsync(Skill skill);
        Task<List<Skill>> GetAllSkillsAsync(string userId);
        Task<Skill?> GetSkillByIdAsync(int skillId);
        Task<bool> SkillExistsAsync(int skillId);
        Task SaveChanges();
        Task<Skill> UpdateSkillAsync(Skill skill);
    }
}
