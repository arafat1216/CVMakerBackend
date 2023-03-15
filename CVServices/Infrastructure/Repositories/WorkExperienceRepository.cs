using CVServices.Contracts.Persistence;
using CVServices.Entities;
using CVServices.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CVServices.Infrastructure.Repositories
{
    public class WorkExperienceRepository : IWorkExperienceRepository
    {
        private readonly CVContext context;
        private readonly DbSet<WorkExperience> db;

        public WorkExperienceRepository(CVContext context)
        {
            this.context = context;
            db = context.Set<WorkExperience>();
        }
        public async Task<WorkExperience> AddWorkExperienceAsync(WorkExperience workExperience)
        {
            await db.AddAsync(workExperience);

            await SaveChanges();

            return workExperience;
        }

        public async Task DeleteWorkExperienceAsync(WorkExperience workExperience)
        {
            db.Remove(workExperience);

            await SaveChanges();
        }

        public async Task<List<WorkExperience>> GetAllWorkExperiencesAsync(string userId)
        {
            return await db.Where(w => w.UserId == userId).ToListAsync();
        }

        public async Task<WorkExperience?> GetWorkExperienceByIdAsync(int workExperienceId)
        {
            return await db.Where(w => w.Id == workExperienceId).FirstOrDefaultAsync();
        }

        public async Task SaveChanges()
        {
            await context.SaveChangesAsync();
        }

        public async Task<WorkExperience> UpdateWorkExperienceAsync(WorkExperience workExperience)
        {
            db.Update(workExperience);

            await SaveChanges();

            return workExperience;
        }

        public async Task<bool> WorkExperienceExistsAsync(int workExperienceId)
        {
            return await db.AnyAsync(w => w.Id == workExperienceId);
        }
    }
}
