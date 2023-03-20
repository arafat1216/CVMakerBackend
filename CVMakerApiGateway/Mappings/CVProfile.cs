using AutoMapper;

namespace CVMakerApiGateway.Mappings
{
    public class CVProfile : Profile
    {
        public CVProfile()
        {
            CreateMap<CVMakerApiGateway.Models.CVDto, Common.Models.CVDto>();


        }
    }
}
