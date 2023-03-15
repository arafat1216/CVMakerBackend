using CVServices.Entities;
using CVServices.ServiceModels;

namespace CVServices.Mappings
{
    public class WorkExperienceProfile : AutoMapper.Profile
    {
        public WorkExperienceProfile()
        {
            CreateMap<WorkExperience, WorkExperienceDto>().ReverseMap();

            CreateMap<AddWorkExperienceDto, WorkExperience>();
        }
    }
}
