using CVServices.Contracts.Persistence;
using CVServices.Entities;
using CVServices.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CVServices.Infrastructure.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly CVContext context;
        private readonly DbSet<Profile> db;

        public ProfileRepository(CVContext context)
        {
            this.context = context;
            this.db = context.Set<Profile>();
        }

        public async Task<Profile> CreateProfileAsync(Profile profile)
        {
            await db.AddAsync(profile);

            await SaveChanges();

            return profile;
        }

        public async Task<Profile?> GetProfileAsync(string userId)
        {
            return await db.Where(u => u.UserId == userId).FirstOrDefaultAsync();
        }

        public async Task<bool> ProfileExists(string userId)
        {
            return await db.AnyAsync(u => u.UserId == userId);
        }

        public async Task SaveChanges()
        {
            await context.SaveChangesAsync();
        }

        public async Task<Profile> UpdateProfileAsync(Profile profile)
        {
            db.Update(profile);

            await SaveChanges();

            return profile;
        }
    }
}
