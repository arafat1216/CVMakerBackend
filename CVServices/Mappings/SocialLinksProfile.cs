
using CVServices.Entities;
using CVServices.ServiceModels;

namespace CVServices.Mappings
{
    public class SocialLinksProfile : AutoMapper.Profile
    {
        public SocialLinksProfile()
        {
            CreateMap<SocialLink, SocialLinkDto>().ReverseMap();
        }
    }
}
