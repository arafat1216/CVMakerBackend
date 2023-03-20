using AutoMapper;
using CVMakerApiGateway.Models;
using CVMakerApiGateway.ViewModels;

namespace CVMakerApiGateway.Mappings
{
    public class WorkExperienceProfile : Profile
    {
        public WorkExperienceProfile()
        {
            CreateMap<WorkExperienceViewModel, AddWorkExperienceDto>();

            CreateMap<WorkExperienceViewModel, WorkExperienceDto>();

            CreateMap<CVMakerApiGateway.Models.WorkExperienceWithTasksDto, Common.Models.WorkExperienceDto>();
        }
    }
}
