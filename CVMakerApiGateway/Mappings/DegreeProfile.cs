using AutoMapper;
using CVMakerApiGateway.Models;
using CVMakerApiGateway.ViewModels;

namespace CVMakerApiGateway.Mappings
{
    public class DegreeProfile : Profile
    {
        public DegreeProfile()
        {
            CreateMap<DegreeViewModel, AddDegreeDto>();

            CreateMap<DegreeViewModel, DegreeDto>();
        }
    }
}
