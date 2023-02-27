using CVServices.Contracts.Persistence;
using CVServices.Entities;
using CVServices.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CVServices.Infrastructure.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private readonly CVContext context;
        private readonly DbSet<Skill> db;

        public SkillRepository(CVContext context)
        {
            this.context = context;
            db = context.Set<Skill>();
        }
        public async Task<Skill> AddSkillAsync(Skill skill)
        {
            await db.AddAsync(skill);

            await SaveChanges();

            return skill;
        }

        public async Task DeleteSkillAsync(Skill skill)
        {
            db.Remove(skill);

            await SaveChanges();
        }

        public async Task<List<Skill>> GetAllSkillsAsync(string userId)
        {
            return await db.Where(u => u.UserId == userId).ToListAsync();
        }

        public async Task<Skill?> GetSkillByIdAsync(int skillId)
        {
            return await db.Where(u => u.Id == skillId).FirstOrDefaultAsync();
        }

        public async Task SaveChanges()
        {
            await context.SaveChangesAsync();
        }

        public async Task<bool> SkillExistsAsync(int skillId)
        {
            return await db.AnyAsync(u => u.Id == skillId);
        }

        public async Task<Skill> UpdateSkillAsync(Skill skill)
        {
            db.Update(skill);

            await SaveChanges();

            return skill;
        }
    }
}
