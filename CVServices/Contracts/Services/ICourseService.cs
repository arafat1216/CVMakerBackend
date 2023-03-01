using CVServices.ServiceModels;

namespace CVServices.Contracts.Services
{
    public interface ICourseService
    {
        Task<CourseDto> AddCourse(AddCourseDto addCourseRequest);
        Task DeleteCourse(int courseId);
        Task<List<CourseDto>> GetAllCourses(string userId);
        Task<CourseDto> GetCourseById(int courseId);
        Task<CourseDto> UpdateCourse(CourseDto updateCourseRequest);
    }
}
