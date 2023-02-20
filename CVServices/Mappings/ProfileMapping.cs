using AutoMapper;
using CVServices.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVServices.Mappings
{
    public class ProfileMapping : Profile
    {
        public ProfileMapping()
        {
            CreateMap<CVServices.Entities.Profile, ProfileDto>().ReverseMap();
        }
    }
}
