using CVServices.Contracts.Persistence;
using CVServices.Entities;
using CVServices.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CVServices.Infrastructure.Repositories
{
    public class DegreeRepository : IDegreeRepository
    {
        private readonly CVContext context;
        private readonly DbSet<Degree> db;

        public DegreeRepository(CVContext context)
        {
            this.context = context;
            db = context.Set<Degree>();
        }
        public async Task<Degree> AddDegreeAsync(Degree degree)
        {
            await db.AddAsync(degree);

            await SaveChanges();

            return degree;
        }

        public async Task<bool> DegreeExistsAsync(int degreeId)
        {
            return await db.AnyAsync(d => d.Id == degreeId);
        }

        public async Task DeleteDegreeAsync(Degree degree)
        {
            db.Remove(degree);

            await SaveChanges();

        }

        public async Task<List<Degree>> GetAllDegreesAsync(string userId)
        {
            return await db.Where(d => d.UserId == userId).ToListAsync();
        }

        public async Task<Degree?> GetDegreeByIdAsync(int degreeId)
        {
            return await db.Where(d => d.Id == degreeId).FirstOrDefaultAsync();
        }

        public async Task SaveChanges()
        {
            await context.SaveChangesAsync();
        }

        public async Task<Degree> UpdateDegreeAsync(Degree degree)
        {
            db.Update(degree);

            await SaveChanges();

            return degree;
        }
    }
}
