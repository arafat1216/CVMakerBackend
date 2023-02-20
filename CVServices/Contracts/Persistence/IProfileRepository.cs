using CVServices.Entities;

namespace CVServices.Contracts.Persistence
{
    public interface IProfileRepository
    {
        Task<Profile> CreateProfileAsync(Profile profile);
        Task<Profile?> GetProfileAsync(string userId);
        Task<bool> ProfileExists(string userId);
        Task<Profile> UpdateProfileAsync(Profile profile);
        Task SaveChanges();
    }
}
