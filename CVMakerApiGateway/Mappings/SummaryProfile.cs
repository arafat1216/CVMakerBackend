using AutoMapper;
using CVMakerApiGateway.Models;
using CVMakerApiGateway.ViewModels;

namespace CVMakerApiGateway.Mappings
{
    public class SummaryProfile : Profile
    {
        public SummaryProfile()
        {
            CreateMap<SummaryViewModel, SummaryDto>();

            CreateMap<CVMakerApiGateway.Models.SummaryDto, Common.Models.SummaryDto>();
        }
    }
}
