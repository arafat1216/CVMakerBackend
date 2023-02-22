using CVServices.Entities;

namespace CVServices.Contracts.Persistence
{
    public interface ISocialLinksRepository
    {
        Task<SocialLink> CreateSocialLinksAsync(SocialLink socialLink);
        Task<SocialLink?> GetSocialLinksAsync(string userId);
        Task<bool> SocialLinksExists(string userId);
        Task<SocialLink> UpdateSocialLinksAsync(SocialLink socialLink);
        Task SaveChanges();
    }
}
