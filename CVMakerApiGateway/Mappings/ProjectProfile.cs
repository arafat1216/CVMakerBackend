using AutoMapper;
using CVMakerApiGateway.Models;
using CVMakerApiGateway.ViewModels;

namespace CVMakerApiGateway.Mappings
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<ProjectViewModel, AddProjectDto>();

            CreateMap<ProjectViewModel, ProjectDto>();

            CreateMap<CVMakerApiGateway.Models.ProjectDto, Common.Models.ProjectDto>();
        }
    }
}
