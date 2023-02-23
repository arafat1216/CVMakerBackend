using CVServices.Entities;
using CVServices.ServiceModels;

namespace CVServices.Mappings
{
    public class SummaryProfile : AutoMapper.Profile
    {
        public SummaryProfile()
        {
            CreateMap<Summary, SummaryDto>().ReverseMap();
        }
    }
}
