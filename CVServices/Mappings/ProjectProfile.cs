using CVServices.Entities;
using CVServices.ServiceModels;

namespace CVServices.Mappings
{
    public class ProjectProfile : AutoMapper.Profile
    {
        public ProjectProfile()
        {
            CreateMap<Project, ProjectDto>().ReverseMap();

            CreateMap<AddProjectDto, Project>();
        }
    }
}
