using AutoMapper;
using CVMakerApiGateway.Models;
using CVMakerApiGateway.ViewModels;

namespace CVMakerApiGateway.Mappings
{
    public class ProfileMapping : Profile
    {
        public ProfileMapping()
        {
            CreateMap<ProfileViewModel, ProfileDto>();

            CreateMap<CVMakerApiGateway.Models.ProfileDto, Common.Models.ProfileDto>();
        }
    }
}
