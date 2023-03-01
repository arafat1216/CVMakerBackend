using CVServices.Entities;
using CVServices.ServiceModels;

namespace CVServices.Mappings
{
    public class CourseProfile : AutoMapper.Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, CourseDto>().ReverseMap();

            CreateMap<AddCourseDto, Course>();
        }
    }
}
