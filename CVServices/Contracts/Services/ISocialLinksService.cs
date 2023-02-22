using CVServices.ServiceModels;

namespace CVServices.Contracts.Services
{
    public interface ISocialLinksService
    {
        Task<SocialLinkDto> GetSocialLinks(string userId);
        Task<SocialLinkDto> UpdateSocialLinks(SocialLinkDto socialLinkDto);
    }
}
