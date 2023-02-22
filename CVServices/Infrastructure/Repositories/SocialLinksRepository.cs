using CVServices.Contracts.Persistence;
using CVServices.Entities;
using CVServices.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CVServices.Infrastructure.Repositories
{
    public class SocialLinksRepository : ISocialLinksRepository
    {
        private readonly CVContext context;
        private readonly DbSet<SocialLink> db;

        public SocialLinksRepository(CVContext context)
        {
            this.context = context;
            this.db = context.Set<SocialLink>();
        }
        public async Task<SocialLink> CreateSocialLinksAsync(SocialLink socialLink)
        {
            await db.AddAsync(socialLink);

            await SaveChanges();

            return socialLink;
        }

        public async Task<SocialLink?> GetSocialLinksAsync(string userId)
        {
            return await db.Where(u => u.UserId == userId).FirstOrDefaultAsync();
        }

        public async Task SaveChanges()
        {
            await context.SaveChangesAsync();   
        }

        public async Task<bool> SocialLinksExists(string userId)
        {
            return await db.AnyAsync(u => u.UserId == userId);
        }

        public async Task<SocialLink> UpdateSocialLinksAsync(SocialLink socialLink)
        {
            db.Update(socialLink);

            await SaveChanges();

            return socialLink;
        }
    }
}
