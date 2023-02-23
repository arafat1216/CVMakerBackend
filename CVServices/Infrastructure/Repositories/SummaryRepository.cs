using CVServices.Contracts.Persistence;
using CVServices.Entities;
using CVServices.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CVServices.Infrastructure.Repositories
{
    public class SummaryRepository : ISummaryRepository
    {
        private readonly CVContext context;
        private readonly DbSet<Summary> db;

        public SummaryRepository(CVContext context)
        {
            this.context = context;
            this.db = context.Set<Summary>();
        }
        public async Task<Summary> CreateSummaryAsync(Summary summary)
        {
            await db.AddAsync(summary);

            await SaveChanges();

            return summary;
        }

        public async Task<Summary?> GetSummaryAsync(string userId)
        {
            return await db.Where(u => u.UserId == userId).FirstOrDefaultAsync();
        }

        public async Task SaveChanges()
        {
            await context.SaveChangesAsync();
        }

        public async Task<bool> SummaryExists(string userId)
        {
            return await db.AnyAsync(u => u.UserId == userId);
        }

        public async Task<Summary> UpdateSummaryAsync(Summary summary)
        {
            db.Update(summary);

            await SaveChanges();

            return summary;
        }
    }
}
