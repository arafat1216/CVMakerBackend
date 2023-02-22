using AutoMapper;
using CVMakerApiGateway.Models;
using CVMakerApiGateway.ViewModels;

namespace CVMakerApiGateway.Mappings
{
    public class SocialLinksProfile : Profile
    {
        public SocialLinksProfile()
        {
            CreateMap<SocialLinkViewModel, SocialLinkDto>();
        }
    }
}
