using CVServices.ServiceModels;

namespace CVServices.Contracts.Services
{
    public interface IProfileService
    {
        Task<ProfileDto> GetProfile(string userId);
        Task<ProfileDto> UpdateProfile(ProfileDto profile);
    }
}
