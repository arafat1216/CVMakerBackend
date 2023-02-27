using AutoMapper;
using CVServices.Entities;
using CVServices.ServiceModels;

namespace CVServices.Mappings
{
    public class SkillProfile : AutoMapper.Profile
    {
        public SkillProfile()
        {
            CreateMap<Skill, SkillDto>().ReverseMap();

            CreateMap<AddSkillDto, Skill>();
        }
    }
}
