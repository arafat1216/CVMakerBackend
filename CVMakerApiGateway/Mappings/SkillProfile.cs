using AutoMapper;
using CVMakerApiGateway.Models;
using CVMakerApiGateway.ViewModels;

namespace CVMakerApiGateway.Mappings
{
    public class SkillProfile : Profile
    {
        public SkillProfile()
        {
            CreateMap<SkillViewModel, AddSkillDto>();

            CreateMap<SkillViewModel, SkillDto>();

            CreateMap<CVMakerApiGateway.Models.SkillDto, Common.Models.SkillDto>();
        }
    }
}
