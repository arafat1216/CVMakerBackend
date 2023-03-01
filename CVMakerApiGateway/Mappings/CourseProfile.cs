using AutoMapper;
using CVMakerApiGateway.Models;
using CVMakerApiGateway.ViewModels;

namespace CVMakerApiGateway.Mappings
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<CourseViewModel, AddCourseDto>();

            CreateMap<CourseViewModel, CourseDto>();
        }
    }
}
