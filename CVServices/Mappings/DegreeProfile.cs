using CVServices.Entities;
using CVServices.ServiceModels;

namespace CVServices.Mappings
{
    public class DegreeProfile : AutoMapper.Profile
    {
        public DegreeProfile()
        {
            CreateMap<Degree, DegreeDto>().ReverseMap();

            CreateMap<AddDegreeDto, Degree>();
        }
    }
}
