using CVMakerApiGateway.Models;

namespace CVMakerApiGateway.Contracts.Services
{
    public interface ICourseService
    {
        Task<List<CourseDto>> GetAllCourses(string userId);
        Task<CourseDto> GetCourse(int courseId);
        Task<CourseDto> AddCourse(AddCourseDto addCourseRequest);
        Task<CourseDto> UpdateCourse(CourseDto updateCourseRequest);
        Task DeleteCourse(int courseId);
    }
}
