using CVMakerApiGateway.Models;

namespace CVMakerApiGateway.Contracts.Services
{
    public interface ISocialLinksService
    {
        Task<SocialLinkDto> GetSocialLinks(string userId);

        Task<SocialLinkDto> UpdateSocialLinks(SocialLinkDto socialLink);
    }
}
